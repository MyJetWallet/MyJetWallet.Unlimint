using System;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Payments;


namespace MyJetWallet.Unlimint
{
    public interface IUnlimintClient
    {
        #region Payments

        /// <summary>
        /// Create a payment.
        /// </summary>
        /// <param name="merchantOrderId">Unique idempotency key. This key is utilized to ensure exactly-once execution of mutating requests.</param>
        /// <param name="paymentId">Unique identifier of the public key used in encryption.</param>
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
        /// <param name="encryptedData">PGP encrypted json string. The object format given here needs to be stringified and PGP encrypted before it is sent to the server, so encryptedData will end up as a string, rather than an object.</param>
        /// <param name="verificationUrlSuccess"></param>
        /// <param name="verificationUrlFailure"></param>
        /// <param name="time"></param>
        /// <param name="paymentMethod"></param>
        /// <param name="clientId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        WebCallResult<PaymentGatewayCreationResponse> CreatePayment(
            string merchantOrderId, 
            string paymentId,
            string email,
            string phoneNumber,
            string sessionId,
            string ipAddress,
            decimal amount,
            string currency,
            string sourceId,
            bool generateToken,
            string threeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            DateTime time,
            string paymentMethod,
            string clientId,
            CancellationToken cancellationToken = default);

        Task<WebCallResult<PaymentGatewayCreationResponse>> CreatePaymentAsync(
            string merchantOrderId, 
            string paymentId,
            string email,
            string phoneNumber,
            string sessionId,
            string ipAddress,
            decimal amount,
            string currency,
            string sourceId,
            bool generateToken,
            string threeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            DateTime time,
            string paymentMethod,
            string clientId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a payment.
        /// </summary>
        /// <param name="id">Unique identifier of the payment.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        WebCallResult<PaymentDataResponse> GetPayment(
            string id,
            CancellationToken cancellationToken = default);

        Task<WebCallResult<PaymentDataResponse>> GetPaymentAsync(
            string id,
            CancellationToken cancellationToken = default);

        #endregion


    }
}