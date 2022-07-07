using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region PublicKey

        /// <summary>
        /// Retrieves an RSA public key to be used in encrypting data sent to the API. Your public keys change infrequently, so we encourage you to cache this response value locally for a duration of 24 hours or more.
        /// </summary>
        /// <returns>Public Key</returns>
        public WebCallResult<PublicKey>
            GetPublicKey(CancellationToken cancellationToken = default) => GetPublicKeyAsync(cancellationToken).Result;

        public async Task<WebCallResult<PublicKey>> GetPublicKeyAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PublicKey>($"{EndpointUrl}/encryption/public", cancellationToken);
        }

        #endregion
    }
}