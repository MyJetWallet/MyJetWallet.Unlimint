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
    public partial class UnlimintClient : IDisposable, IUnlimintClient
    {
        //TODO: Get production address
        public const string MainPublicApi = "https://cardpay.com/api";
        public const string TestPublicApi = "https://sandbox.cardpay.com/api";

        public static bool PrintGetApiCalls { get; set; } = false;
        public static bool PrintPostApiCalls { get; set; } = false;
        public static bool PrintPutApiCalls { get; set; } = false;

        #region Properties

        public string EndpointUrl { get; private set; }

        public SecureString AccessToken { get; private set; }

        public bool ThrowThenErrorResponse { get; set; } = true;

        private HttpClient _httpClient;
        private DateTime _lastHttpSetupTime;
        private HttpClient _lastHttpClient;
        private readonly object _gate = new object();

        #endregion

        #region CTOR

        public UnlimintClient(string accessToken, UnlimintNetwork network = UnlimintNetwork.Main)
        {
            this.EndpointUrl = network == UnlimintNetwork.Main ? MainPublicApi : TestPublicApi;
            this.SetAccessToken(accessToken);
        }

        public UnlimintClient(string accessToken, string apiRootUrl)
        {
            if (string.IsNullOrEmpty(apiRootUrl))
                throw new ArgumentException("api url cannot be empty", nameof(apiRootUrl));

            if (apiRootUrl.Last() != '/')
                apiRootUrl += '/';

            this.EndpointUrl = apiRootUrl;
            this.SetAccessToken(accessToken);
        }

        #endregion

        #region Access Token

        public void SetAccessToken(string accessToken)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                this.AccessToken = accessToken.StringToSecureString();
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
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", this.AccessToken.SecureStringToString());

            _lastHttpClient?.Dispose();
            _lastHttpClient = _httpClient;
            _httpClient = client;
            _lastHttpSetupTime = DateTime.UtcNow;
        }

        private string ConvertToQueryString(Dictionary<string, object> nvc)
        {
            var array = nvc
                .Where(keyValue => keyValue.Value != null)
                .Select(keyValue =>
                    new KeyValuePair<string, string>(keyValue.Key, keyValue.Value.ConvertValueToString()))
                .Select(keyValue => $"{WebUtility.UrlEncode(keyValue.Key)}={WebUtility.UrlEncode(keyValue.Value)}")
                .ToArray();
            return array.Any() ? "?" + string.Join("&", array) : string.Empty;
        }

        private async Task<WebCallResult<T>> GetAsync<T>(string url,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = this.GetHttpClient();
            var response = await client.GetAsync($"{url}", cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (PrintGetApiCalls)
            {
                Console.WriteLine($"Get: {url}\nCode: {response.StatusCode}\nResp: {content}");
            }
            
            // Return
            return this.EvaluateResponse<T>(response, content);
        }

        private async Task<WebCallResult<T>> PostAsync<T>(string url, object obj = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = GetHttpClient();
            var data = JsonConvert.SerializeObject(obj ?? new object());
            var response = await client.PostAsync($"{url}", 
                new StringContent(data, Encoding.UTF8, "application/json"),
                cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (PrintPostApiCalls)
            {
                Console.WriteLine($"POST: {url}\nBody: {data}\nResp: {content}");
            }
            
            return this.EvaluateResponse<T>(response, content);
        }

        private async Task<WebCallResult<T>> PutAsync<T>(string url, object obj = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = GetHttpClient();
            var data = JsonConvert.SerializeObject(obj ?? new object());
            var response = await client.PutAsync($"{url}", 
                new StringContent(data, Encoding.UTF8, "application/json"),
                cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (PrintPutApiCalls)
            {
                Console.WriteLine($"PUT: {url}\nBody: {data}\nResp: {content}");
            }
            
            // Return
            return this.EvaluateResponse<T>(response, content);
        }

        private async Task<WebCallResult<T>> DeleteAsync<T>(string url, object obj = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = GetHttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{url}");
            var data = JsonConvert.SerializeObject(obj ?? new object());
            request.Content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

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
            
            var errorMessage = response.StatusCode == HttpStatusCode.OK ? string.Empty : content;
            var obj = response.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<T>(content) :  default;
            var objCallResult = new CallResult<T>(obj, (int)response.StatusCode, errorMessage);
            
            return new WebCallResult<T>(response, objCallResult);
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