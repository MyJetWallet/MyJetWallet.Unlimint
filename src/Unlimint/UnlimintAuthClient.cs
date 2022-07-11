using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintAuthClient : IDisposable, IUnlimintAuthClient
    {
        //TODO: Get production address
        public const string MainPublicApi = "https://cardpay.com/api";
        public const string TestPublicApi = "https://sandbox.cardpay.com/api";

        public static bool PrintPostApiCalls { get; set; } = false;
        public static bool PrintPutApiCalls { get; set; } = false;

        #region Properties

        public string EndpointUrl { get; private set; }

        public SecureString AccessToken { get; private set; }
        public SecureString TerminalCode { get; private set; }
        public SecureString Password { get; private set; }

        public bool ThrowThenErrorResponse { get; set; } = true;

        private HttpClient _httpClient;
        private DateTime _lastHttpSetupTime;
        private HttpClient _lastHttpClient;
        private readonly object _gate = new object();

        #endregion

        #region CTOR

        public UnlimintAuthClient(string terminalCode, string password, UnlimintNetwork network = UnlimintNetwork.Main)
        {
            this.EndpointUrl = network == UnlimintNetwork.Main ? MainPublicApi : TestPublicApi;
            this.SetTerminalCode(terminalCode);
            this.SetPassword(password);
        }
        #endregion

        #region Access Token

        public void SetPassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                this.Password = password.StringToSecureString();
            }
        }
        
        public void SetTerminalCode(string terminalCode)
        {
            if (!string.IsNullOrEmpty(terminalCode))
            {
                this.TerminalCode = terminalCode.StringToSecureString();
            }
        }
        #endregion

        #region Private Methods

        private HttpClient GetHttpClient()
        {
            lock (_gate)
            {
                if (_httpClient == null || (DateTime.UtcNow - _lastHttpSetupTime).TotalSeconds > 120)
                {
                    SetupHttpClient();
                }

                return _httpClient;
            }
        }

        private void SetupHttpClient()
        {
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };

            var client = new HttpClient(handler);

            client.BaseAddress = new Uri(this.EndpointUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Authorization =
            //     new AuthenticationHeaderValue("Bearer", this.AccessToken.SecureStringToString());

            _lastHttpClient?.Dispose();
            _lastHttpClient = _httpClient;
            _httpClient = client;
            _lastHttpSetupTime = DateTime.UtcNow;
        }

        private async Task<WebCallResult<T>> PostAsync<T>(string url, List<KeyValuePair<string, string>> data,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = GetHttpClient();
            var response = await client.PostAsync($"{url}", 
                new FormUrlEncodedContent(data),
                cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (PrintPostApiCalls)
            {
                Console.WriteLine($"POST: {url}\nBody: {data}\nResp: {content}");
            }

            // Return
            return this.EvaluateResponse<T>(response, content);
        }


        private WebCallResult<T> EvaluateResponse<T>(HttpResponseMessage response, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                ThrowErrorExceptionIfEnabled(HttpStatusCode.NotFound, "Empty Response");
                return new WebCallResult<T>(response, default, HttpStatusCode.NotFound, "Empty Response");
            }

            var obj = JsonConvert.DeserializeObject<T>(content);
            var objCallResult = new CallResult<T>(obj, (int)response.StatusCode, String.Empty);
            return new WebCallResult<T>(response, objCallResult);
            //return WebCallResult<T>(response, JsonConvert.DeserializeObject<CallResult<T>>(content));
        }

        private void ThrowErrorExceptionIfEnabled(HttpStatusCode code, string message)
        {
            if (ThrowThenErrorResponse)
            {
                throw new UnlimintException(code, message);
            }
        }

        #endregion

        public void Dispose()
        {
            _httpClient?.Dispose();
            _lastHttpClient?.Dispose();
            AccessToken?.Dispose();
        }
    }
}