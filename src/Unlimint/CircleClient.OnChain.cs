using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Onchain;
using MyJetWallet.Unlimint.Models.Payments;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        /// <summary>
        /// Retrieves general configuration information.
        /// </summary>
        /// <returns></returns>
        public WebCallResult<Configuration> GetConfiguration(CancellationToken cancellationToken = default) =>
            GetConfigurationAsync(cancellationToken).Result;

        public async Task<WebCallResult<Configuration>> GetConfigurationAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Configuration>($"{EndpointUrl}/configuration", cancellationToken);
        }

        /// <summary>
        /// Generates a new blockchain address for a wallet for a given currency/chain pair.
        /// Circle may reuse addresses on blockchains that support reuse. For example, if you're requesting two addresses for depositing USD and ETH, both on Ethereum, you may see the same Ethereum address returned.
        /// Depositing cryptocurrency to a generated address will credit the associated wallet with the value of the deposit.
        /// </summary>
        /// <param name="id">Unique id of a wallet.</param>
        /// <param name="idempotencyKey">Unique idempotency key. This key is utilized to ensure exactly-once execution of mutating requests.</param>
        /// <param name="currency">A currency associated with a balance or address. CUSDC is currently only supported in the Sandbox environment.</param>
        /// <param name="chain">A blockchain that a given currency is available on.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public WebCallResult<BlockchainAddress> GenerateAddress(string id, string idempotencyKey, string currency,
            string chain, CancellationToken cancellationToken = default) =>
            GenerateAddressAsync(id, idempotencyKey, currency, chain, cancellationToken).Result;

        public async Task<WebCallResult<BlockchainAddress>> GenerateAddressAsync(string id, string idempotencyKey,
            string currency, string chain, CancellationToken cancellationToken = default)
        {
            var data = new
            {
                idempotencyKey,
                currency,
                chain
            };
            return await PostAsync<BlockchainAddress>($"{EndpointUrl}/wallets/{id}/addresses", data, cancellationToken);
        }

        /// <summary>
        /// Get a transfer.
        /// </summary>
        /// <param name="id">Unique identifier of the transfer.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public WebCallResult<PaymentInfo> GetTransfer(string id, CancellationToken cancellationToken = default) =>
            GetTransferAsync(id, cancellationToken).Result;

        public async Task<WebCallResult<PaymentInfo>> GetTransferAsync(string id,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaymentInfo>($"{EndpointUrl}/transfers/{id}", cancellationToken);
        }

        /// <summary>
        /// Create a transfer.
        /// </summary>
        /// <param name="idempotencyKey">Unique idempotency key. This key is utilized to ensure exactly-once execution of mutating requests.</param>
        /// <param name="sourceId">Unique identifier for the source.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="dstType"></param>
        /// <param name="dstAddress">The blockchain address.</param>
        /// <param name="dstAddressTag">The secondary identifier for a blockchain address. An example of this is the memo field on the Stellar network, which can be text, id, or hash format.</param>
        /// <param name="dstChain">A blockchain that a given currency is available on.</param>
        /// <param name="amount">Magnitude of the amount, in units of the currency, with a ..</param>
        /// <param name="currency">Currency code.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public WebCallResult<PaymentInfo> CreateTransfer(string idempotencyKey, string sourceId, string sourceType,
            string dstType,
            string dstAddress, string dstAddressTag, string dstChain, string amount, string currency,
            CancellationToken cancellationToken = default) => CreateTransferAsync(idempotencyKey, sourceId, sourceType,
            dstType, dstAddress, dstAddressTag, dstChain, amount, currency, cancellationToken).Result;

        public async Task<WebCallResult<PaymentInfo>> CreateTransferAsync(string idempotencyKey, string sourceId,
            string sourceType, string dstType, string dstAddress,
            string dstAddressTag, string dstChain, string amount, string currency,
            CancellationToken cancellationToken = default)
        {
            var data = new
            {
                idempotencyKey,
                source = new
                {
                    type = sourceType,
                    id = sourceId
                },
                destination = new
                {
                    type = dstType,
                    address = dstAddress,
                    addressTag = dstAddressTag,
                    chain = dstChain
                },
                amount = new
                {
                    amount,
                    currency
                }
            };
            return await PostAsync<PaymentInfo>($"{EndpointUrl}/transfers", data, cancellationToken);
        }
    }
}