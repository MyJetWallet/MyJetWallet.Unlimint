using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Auth;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region AuthToken
        
        public WebCallResult<AuthToken> GetAuthorizationToken(string terminalCode, string password,
            CancellationToken cancellationToken = default) => 
            GetAuthorizationTokenAsync(password, terminalCode, cancellationToken).Result;

        public async Task<WebCallResult<AuthToken>> GetAuthorizationTokenAsync(
            string terminalCode, string password,
            CancellationToken cancellationToken = default)
        {
            var data = new CreateAuthRequest()
            {
                Password = password,
                TerminalCode = terminalCode,
                GrantType = "password" // Should be password as stated in OAuth specification
            };
            return await PostAsync<AuthToken>($"{EndpointUrl}/auth/token", data, cancellationToken);
        }
        #endregion
    }
}