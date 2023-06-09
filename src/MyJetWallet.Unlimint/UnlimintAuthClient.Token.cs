using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Auth;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintAuthClient
    {
        #region AuthToken
        
        public WebCallResult<AuthToken> GetAuthorizationToken(
            CancellationToken cancellationToken = default) => 
            GetAuthorizationTokenAsync(cancellationToken).Result;

        public async Task<WebCallResult<AuthToken>> GetAuthorizationTokenAsync(
            CancellationToken cancellationToken = default)
        {
            var data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("grant_type", "password"));
            data.Add(new KeyValuePair<string, string>("terminal_code", this.TerminalCode.SecureStringToString()));
            data.Add(new KeyValuePair<string, string>("password", this.Password.SecureStringToString()));

            return await PostAsync<AuthToken>($"{EndpointUrl}/auth/token", data, cancellationToken);
        }
        #endregion
    }
}