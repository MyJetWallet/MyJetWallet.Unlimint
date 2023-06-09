using System;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Auth;


namespace MyJetWallet.Unlimint
{
    public interface IUnlimintAuthClient
    {
        #region AuthToken

        WebCallResult<AuthToken> GetAuthorizationToken(
            CancellationToken cancellationToken = default);

        Task<WebCallResult<AuthToken>> GetAuthorizationTokenAsync(
            CancellationToken cancellationToken = default);

        #endregion
    }
}