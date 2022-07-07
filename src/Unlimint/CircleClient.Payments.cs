using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Payments;
using MyJetWallet.Unlimint.Models.Payouts;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region Payments

        /// <summary>
        /// Create a payment.
        /// </summary>
        /// <param name="idempotencyKey">Unique idempotency key. This key is utilized to ensure exactly-once execution of mutating requests.</param>
        /// <param name="keyId">Unique identifier of the public key used in encryption.</param>
        /// <param name="email">Email of the user</param>
        /// <param name="phoneNumber">Phone number of the user in E.164 format. We recommend using a library such as libphonenumber to parse and validate phone numbers.</param>
        /// <param name="sessionId">Hash of the session identifier; typically of the end user. This helps us make risk decisions and prevent fraud. IMPORTANT: Please hash the session identifier to prevent sending us actual session identifiers.</param>
        /// <param name="ipAddress">Single IPv4 or IPv6 address of user</param>
        /// <param name="amount">Magnitude of the amount, in units of the currency, with a ..</param>
        /// <param name="currency">Currency code.</param>
        /// <param name="verification">Indicates the verification method for this payment. 3D Secure is currently limited to the Sandbox environment.</param>
        /// <param name="sourceId">Unique identifier for the source.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="description">Description of the payment with length restriction of 240 characters.</param>
        /// /// <param name="encryptedData">PGP encrypted json string. The object format given here needs to be stringified and PGP encrypted before it is sent to the server, so encryptedData will end up as a string, rather than an object.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public WebCallResult<PaymentInfo> CreatePayment(string idempotencyKey, string keyId, string email,
            string phoneNumber, string sessionId,
            string ipAddress, string amount, string currency, string verification, string sourceId, string sourceType,
            string description, string encryptedData, string verificationUrlSuccess, string verificationUrlFailure, CancellationToken cancellationToken = default) =>
            CreatePaymentAsync(idempotencyKey,
                keyId, email, phoneNumber, sessionId, ipAddress, amount, currency, verification, sourceId, sourceType,
                description, encryptedData, verificationUrlSuccess, verificationUrlFailure, cancellationToken).Result;

        public async Task<WebCallResult<PaymentInfo>> CreatePaymentAsync(string idempotencyKey, string keyId,
            string email,
            string phoneNumber, string sessionId,
            string ipAddress, string amount, string currency, string verification, string sourceId, string sourceType,
            string description, string encryptedData, string verificationUrlSuccess, string verificationUrlFailure, CancellationToken cancellationToken = default)
        {
            var data = new CreatePaymentRequest()
            {
                IdempotencyKey = idempotencyKey,
                KeyId = keyId,
                Metadata = new Metadata
                {
                    Email = email,
                    PhoneNumber = phoneNumber,
                    SessionId = sessionId,
                    IpAddress = ipAddress
                },
                Amount = new CircleAmount
                {
                    Amount = amount,
                    Currency = currency
                },
                AutoCapture = true,
                Verification = verification,
                Source = new PaymentSource
                {
                    Id = sourceId,
                    Type = sourceType
                },
                Description = description,
                EncryptedData = encryptedData,
                VerificationFailureUrl = verificationUrlFailure,
                VerificationSuccessUrl = verificationUrlSuccess,
            };
            return await PostAsync<PaymentInfo>($"{EndpointUrl}/payments", data, cancellationToken);
        }

        /// <summary>
        /// Get a payment.
        /// </summary>
        /// <param name="id">Unique identifier of the payment.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public WebCallResult<PaymentInfo> GetPayment(string id, CancellationToken cancellationToken = default) =>
            GetPaymentAsync(id, cancellationToken).Result;

        public async Task<WebCallResult<PaymentInfo>> GetPaymentAsync(string id,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaymentInfo>($"{EndpointUrl}/payments/{id}", cancellationToken);
        }
    }

    #endregion
}