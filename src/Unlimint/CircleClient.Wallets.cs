using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models.Payments;
using MyJetWallet.Unlimint.Models.Payouts;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Wallets;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region Wallets

        public async Task<WebCallResult<WalletInfo>> CreateWalletAsync(string idempotencyKey, string description, 
            CancellationToken cancellationToken = default)
        {
            var data = new CreateWalletRequest()
            {
                IdempotencyKey = idempotencyKey,
                Description = description,
            };
            return await PostAsync<WalletInfo>($"{EndpointUrl}/wallets", data, cancellationToken);
        }

        public async Task<WebCallResult<WalletInfo>> GetWalletAsync(string id,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<WalletInfo>($"{EndpointUrl}/wallets/{id}", cancellationToken);
        }

        public async Task<WebCallResult<WalletInfo[]>> GetWalletsAsync(string pageAfter, int pageSize,
            CancellationToken cancellationToken = default)
        {
            var query = string.IsNullOrEmpty(pageAfter) ? "" : $"pageAfter={pageAfter}";
            return await GetAsync<WalletInfo[]>($"{EndpointUrl}/wallets?{query}&pageSize={pageSize}", cancellationToken);
        }
    }

    #endregion
}