using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models.Payments;
using MyJetWallet.Unlimint.Models.Payouts;
using MyJetWallet.Unlimint.Models.Wallets;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.ChargeBacks;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region Chargebacks

        public async Task<WebCallResult<Chargeback[]>> GetChargebacksAsync(string pageAfter, int pageSize,
            CancellationToken cancellationToken = default)
        {
            var query = string.IsNullOrEmpty(pageAfter) ? "" : $"pageAfter={pageAfter}";
            return await GetAsync<Chargeback[]>($"{EndpointUrl}/chargebacks?{query}&pageSize={pageSize}", cancellationToken);
        }
    }

    #endregion
}