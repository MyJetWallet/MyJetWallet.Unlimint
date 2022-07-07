using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models.Payments;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.WireTransfers;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region WireTransfers

        /// <summary>
        /// Create a bank account for future wire transfers.
        /// </summary>
        /// <param name="idempotencyKey">Unique idempotency key. This key is utilized to ensure exactly-once execution of mutating requests.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public async Task<WebCallResult<BankAccountInfo>> CreateBankAccountUsSwiftAsync(
            string idempotencyKey,
            string accountNumber,
            string routingNumber,
            BillingDetails billingDetails,
            BankAddress bankAddress,
            CancellationToken cancellationToken = default)
        {
            var data = new CreateBankAccountUsSwift()
            {
                IdempotencyKey = idempotencyKey,
                AccountNumber = accountNumber,
                RoutingNumber = routingNumber,
                BankAddress = bankAddress,
                BillingDetails = billingDetails,
            };

            return await PostAsync<BankAccountInfo>($"{EndpointUrl}/banks/wires", data, cancellationToken);
        }

        public async Task<WebCallResult<BankAccountInfo>> CreateBankAccountSepaAsync(
            string idempotencyKey,
            string iban,
            BillingDetails billingDetails,
            BankAddress bankAddress,
            CancellationToken cancellationToken = default)
        {
            var data = new CreateBankAccountSepa()
            {
                IdempotencyKey = idempotencyKey,
                Iban = iban,
                BankAddress = bankAddress,
                BillingDetails = billingDetails,
            };

            return await PostAsync<BankAccountInfo>($"{EndpointUrl}/banks/wires", data, cancellationToken);
        }

        public async Task<WebCallResult<BankWireTransferDetail>> ObtainBankWireTransferDetailsAsync(
            string bankAccountId,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<BankWireTransferDetail>($"{EndpointUrl}/banks/wires/{bankAccountId}/instructions", cancellationToken);
        }

        #endregion
    }
}