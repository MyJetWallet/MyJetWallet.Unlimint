using System;
using System.Collections.Generic;
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
        /// <param name="requestId">Unique identifier of the public key used in encryption.</param>
        /// <param name="email">Email of the user</param>
        /// <param name="phoneNumber">Phone number of the user in E.164 format. We recommend using a library such as libphonenumber to parse and validate phone numbers.</param>
        /// <param name="sessionId">Hash of the session identifier; typically of the end user. This helps us make risk decisions and prevent fraud. IMPORTANT: Please hash the session identifier to prevent sending us actual session identifiers.</param>
        /// <param name="ipAddress">Single IPv4 or IPv6 address of user</param>
        /// <param name="amount">Magnitude of the amount, in units of the currency, with a ..</param>
        /// <param name="currency">Currency code.</param>
        /// <param name="sourceId">Unique identifier for the source.</param>
        /// <param name="generateToken"></param>
        /// <param name="threeDsChallengeIndicator"></param>
        /// <param name="description">Description of the payment with length restriction of 240 characters.</param>
        /// <param name="verificationUrlSuccess"></param>
        /// <param name="verificationUrlFailure"></param>
        /// <param name="verificationUrlCancel"></param>
        /// <param name="verificationUrlInProcess"></param>
        /// <param name="verificationUrlReturn"></param>
        /// <param name="time"></param>
        /// <param name="paymentMethod"></param>
        /// <param name="clientId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        WebCallResult<PaymentGatewayCreationResponse> CreatePayment(string merchantOrderId,
            string requestId,
            string email,
            string phoneNumber,
            string sessionId,
            string ipAddress,
            decimal amount,
            string currency,
            string sourceId,
            bool generateToken,
            bool threeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            string verificationUrlCancel,
            string verificationUrlInProcess,
            string verificationUrlReturn,
            DateTime time,
            string paymentMethod,
            string clientId,
            CancellationToken cancellationToken = default);

        Task<WebCallResult<PaymentGatewayCreationResponse>> CreatePaymentAsync(
            string merchantOrderId,
            string requestId,
            string email,
            string phoneNumber,
            string sessionId,
            string ipAddress,
            decimal amount,
            string currency,
            string sourceId,
            bool generateToken,
            bool threeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            string verificationUrlCancel,
            string verificationUrlInProcess,
            string verificationUrlReturn,
            DateTime time,
            string paymentMethod,
            string clientId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a payment.
        /// </summary>
        /// <param name="merchantOrderId">Unique idempotency key. This key is utilized to ensure exactly-once execution of mutating requests.</param>
        /// <param name="requestId">Unique identifier of the public key used in encryption.</param>
        /// <param name="email">Email of the user</param>
        /// <param name="phoneNumber">Phone number of the user in E.164 format. We recommend using a library such as libphonenumber to parse and validate phone numbers.</param>
        /// <param name="sessionId">Hash of the session identifier; typically of the end user. This helps us make risk decisions and prevent fraud. IMPORTANT: Please hash the session identifier to prevent sending us actual session identifiers.</param>
        /// <param name="ipAddress">Single IPv4 or IPv6 address of user</param>
        /// <param name="amount">Magnitude of the amount, in units of the currency, with a ..</param>
        /// <param name="currency">Currency code.</param>
        /// <param name="sourceId">Unique identifier for the source.</param>
        /// <param name="cardToken"></param>
        /// <param name="threeDsChallengeIndicator"></param>
        /// <param name="description">Description of the payment with length restriction of 240 characters.</param>
        /// <param name="verificationUrlSuccess"></param>
        /// <param name="verificationUrlFailure"></param>
        /// <param name="verificationUrlCancel"></param>
        /// <param name="verificationUrlInProcess"></param>
        /// <param name="verificationUrlReturn"></param>
        /// <param name="time"></param>
        /// <param name="paymentMethod"></param>
        /// <param name="clientId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        WebCallResult<PaymentGatewayCreationResponse> CreatePaymentByCardToken(string merchantOrderId,
            string requestId,
            string email,
            string phoneNumber,
            string sessionId,
            string ipAddress,
            decimal amount,
            string currency,
            string sourceId,
            string cardToken,
            bool threeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            string verificationUrlCancel,
            string verificationUrlInProcess,
            string verificationUrlReturn,
            DateTime time,
            string paymentMethod,
            string clientId,
            CancellationToken cancellationToken = default);

        Task<WebCallResult<PaymentGatewayCreationResponse>> CreatePaymentByCardTokenAsync(
            string merchantOrderId,
            string requestId,
            string email,
            string phoneNumber,
            string sessionId,
            string ipAddress,
            decimal amount,
            string currency,
            string sourceId,
            string cardToken,
            bool threeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            string verificationUrlCancel,
            string verificationUrlInProcess,
            string verificationUrlReturn,
            DateTime time,
            string paymentMethod,
            string clientId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a payment.
        /// </summary>
        /// <param name="paymentAlternativeType"></param>
        /// <param name="merchantOrderId">Unique idempotency key. This key is utilized to ensure exactly-once execution of mutating requests.</param>
        /// <param name="requestId">Unique identifier of the public key used in encryption.</param>
        /// <param name="amount">Magnitude of the amount, in units of the currency, with a ..</param>
        /// <param name="currency">Currency code.</param>
        /// <param name="useThreeDsChallengeIndicator"></param>
        /// <param name="description">Description of the payment with length restriction of 240 characters.</param>
        /// <param name="verificationUrlSuccess"></param>
        /// <param name="verificationUrlFailure"></param>
        /// <param name="verificationUrlCancel"></param>
        /// <param name="verificationUrlInProcess"></param>
        /// <param name="verificationUrlReturn"></param>
        /// <param name="time"></param>
        /// <param name="livingAddress"></param>
        /// <param name="customer"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="email">Email of the user</param>
        /// <param name="phoneNumber">Phone number of the user in E.164 format. We recommend using a library such as libphonenumber to parse and validate phone numbers.</param>
        /// <param name="sourceId">Unique identifier for the source.</param>
        /// <param name="cardToken"></param>
        /// <param name="threeDsChallengeIndicator"></param>
        /// <param name="paymentMethod"></param>
        /// <returns></returns>
        WebCallResult<PaymentGatewayCreationResponse> CreateAlternativePayment(
            List<string> alternativeMethods,
            string merchantOrderId,
            string requestId,
            decimal amount,
            string currency,
            bool useThreeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            string verificationUrlCancel,
            string verificationUrlInProcess,
            string verificationUrlReturn,
            DateTime time,
            PaymentRequestCustomer customer,
            CancellationToken cancellationToken = default);
        
        Task<WebCallResult<PaymentGatewayCreationResponse>> CreateAlternativePaymentAsync(
            List<string> alternativeMethods,
            string merchantOrderId,
            string requestId,
            decimal amount,
            string currency,
            bool useThreeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            string verificationUrlCancel,
            string verificationUrlInProcess,
            string verificationUrlReturn,
            DateTime time,
            PaymentRequestCustomer customer,
            CancellationToken cancellationToken = default);


        /// <summary>
        /// Create a payment.
        /// </summary>
        /// <param name="merchantOrderId">Unique idempotency key. This key is utilized to ensure exactly-once execution of mutating requests.</param>
        /// <param name="requestId">Unique identifier of the public key used in encryption.</param>
        /// <param name="email">Email of the user</param>
        /// <param name="phoneNumber">Phone number of the user in E.164 format. We recommend using a library such as libphonenumber to parse and validate phone numbers.</param>
        /// <param name="sessionId">Hash of the session identifier; typically of the end user. This helps us make risk decisions and prevent fraud. IMPORTANT: Please hash the session identifier to prevent sending us actual session identifiers.</param>
        /// <param name="ipAddress">Single IPv4 or IPv6 address of user</param>
        /// <param name="amount">Magnitude of the amount, in units of the currency, with a ..</param>
        /// <param name="currency">Currency code.</param>
        /// <param name="sourceId">Unique identifier for the source.</param>
        /// <param name="generateToken"></param>
        /// <param name="threeDsChallengeIndicator"></param>
        /// <param name="useThreeDsChallengeIndicator"></param>
        /// <param name="description">Description of the payment with length restriction of 240 characters.</param>
        /// <param name="verificationUrlSuccess"></param>
        /// <param name="verificationUrlFailure"></param>
        /// <param name="verificationUrlCancel"></param>
        /// <param name="verificationUrlInProcess"></param>
        /// <param name="verificationUrlReturn"></param>
        /// <param name="time"></param>
        /// <param name="paymentMethod"></param>
        /// <param name="clientId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        WebCallResult<PaymentGatewayCreationResponse> CreateGatewayBankCardPayment(string merchantOrderId,
                    string requestId,
                    decimal amount,
                    string currency,
                    bool generateToken,
                    bool useThreeDsChallengeIndicator,
                    string description,
                    string verificationUrlSuccess,
                    string verificationUrlFailure,
                    string verificationUrlCancel,
                    string verificationUrlInProcess,
                    string verificationUrlReturn,
                    DateTime time,
                    PaymentRequestCustomer customer,
                    PaymentRequestCardAccount cardAccount,
                    CancellationToken cancellationToken = default);

        Task<WebCallResult<PaymentGatewayCreationResponse>> CreateGatewayBankCardPaymentAsync(
            string merchantOrderId,
            string requestId,
            decimal amount,
            string currency,
            bool generateToken,
            bool useThreeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            string verificationUrlCancel,
            string verificationUrlInProcess,
            string verificationUrlReturn,
            DateTime time,
            PaymentRequestCustomer customer,
            PaymentRequestCardAccount cardAccount,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a payment.
        /// </summary>
        /// <param name="id">Unique identifier of the payment.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        WebCallResult<PaymentResponse> GetPaymentById(
            string id,
            CancellationToken cancellationToken = default);

        Task<WebCallResult<PaymentResponse>> GetPaymentByIdAsync(
            string id,
            CancellationToken cancellationToken = default);

        Task<WebCallResult<PaymentDataResponse>> GetPaymentByMerchantOrderIdAsync(string merchantOrderId,
            string requestId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}