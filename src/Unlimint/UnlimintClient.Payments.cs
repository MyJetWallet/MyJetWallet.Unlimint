using System;
using System.Globalization;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Payments;
using System.Linq;
using System.Security.Principal;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region Payments

        /// <summary>
        /// Create a payment.
        /// </summary>
        public WebCallResult<PaymentGatewayCreationResponse> CreatePayment(
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
            CancellationToken cancellationToken = default) =>
            CreatePaymentAsync(
                    merchantOrderId,
                     requestId,
                     email,
                     phoneNumber,
                     sessionId,
                     ipAddress,
                     amount,
                     currency,
                     sourceId,
                     generateToken,
                     threeDsChallengeIndicator,
                     description,
                     verificationUrlSuccess,
                     verificationUrlFailure,
                     verificationUrlCancel,
                     verificationUrlInProcess,
                     verificationUrlReturn,
                     time,
                     paymentMethod,
                     clientId,
                     cancellationToken )
                .Result;
        
        public async Task<WebCallResult<PaymentGatewayCreationResponse>> CreatePaymentAsync(
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
            bool useThreeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            string verificationUrlCancel,
            string verificationUrlInProcess,
            string verificationUrlReturn,
            DateTime time,
            string paymentMethod,
            string clientId,
            CancellationToken cancellationToken = default)
        {
            var data = new PaymentRequest
            {
                Request = new Request
                {
                    Id = requestId,
                    Time = time
                },
                Customer = new PaymentRequestCustomer
                {
                    Email = email,
                    Id = clientId,
                    Phone = phoneNumber,
                    Ip = ipAddress
                },
                MerchantOrder = new PaymentRequestMerchantOrder
                {
                    Description = description,
                    Id = merchantOrderId,
                },
                PaymentData = new PaymentRequestPaymentData
                {
                    Amount = amount.ToString(CultureInfo.InvariantCulture),
                    Currency = currency,
                    GenerateToken = generateToken,
                    Note = description,
                    ThreeDsChallengeIndicator = useThreeDsChallengeIndicator == false ? "01" : "04"
                },
                PaymentMethod = paymentMethod,
                ReturnUrls = new ReturnUrls()
                {
                    SuccessUrl = verificationUrlSuccess,
                    DeclineUrl = verificationUrlFailure,
                    CancelUrl = verificationUrlCancel,
                    InprocessUrl = verificationUrlInProcess,
                    ReturnUrl = verificationUrlReturn
                }
            };
            return await PostAsync<PaymentGatewayCreationResponse>($"{EndpointUrl}/payments", data, cancellationToken);
        }
        
        public async Task<WebCallResult<PaymentGatewayCreationResponse>> CreateBoletoPaymentAsync(
            string merchantOrderId,
            string requestId,
            string email,
            string phoneNumber,
            string sessionId,
            string ipAddress,
            decimal amount,
            string currency,
            string sourceId,
            string fullName,
            bool useThreeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            string verificationUrlCancel,
            string verificationUrlInProcess,
            string verificationUrlReturn,
            DateTime time,
            string clientId,
            string identity,
            string zip,
            CancellationToken cancellationToken = default)
        {
            var data = new PaymentRequest
            {
                Request = new Request
                {
                    Id = requestId,
                    Time = time
                },
                Customer = new PaymentRequestCustomer
                {
                    Email = email,
                    Id = clientId,
                    Phone = phoneNumber,
                    Ip = ipAddress,
                    FullName = fullName,
                    Identity = identity,
                    LivingAddress = new PaymentRequestLivingAddress
                    {
                        Address = "Rua Visconde de Porto Seguro 1238",
                        City = "Sao Paulo",
                        Country = "Brazil",
                        State = "SP",
                        Zip = zip
                    }
                },
                MerchantOrder = new PaymentRequestMerchantOrder
                {
                    Description = description,
                    Id = merchantOrderId,
                },
                PaymentData = new PaymentRequestPaymentData
                {
                    Amount = amount.ToString(CultureInfo.InvariantCulture),
                    Currency = currency,
                    Note = description,
                    ThreeDsChallengeIndicator = useThreeDsChallengeIndicator == false ? "01" : "04",
                    // InstallmentType = "IF",
                    // InstallmentAmount = amount
                },
                PaymentMethod = "BOLETO",
                ReturnUrls = new ReturnUrls()
                {
                    SuccessUrl = verificationUrlSuccess,
                    DeclineUrl = verificationUrlFailure,
                    CancelUrl = verificationUrlCancel,
                    InprocessUrl = verificationUrlInProcess,
                    ReturnUrl = verificationUrlReturn
                },
                
            };
            return await PostAsync<PaymentGatewayCreationResponse>($"{EndpointUrl}/payments", data, cancellationToken);
        }
        
        
        /// <summary>
        /// Create a payment.
        /// </summary>
        public WebCallResult<PaymentGatewayCreationResponse> CreatePaymentByCardToken (string merchantOrderId,
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
            CancellationToken cancellationToken = default) =>
            CreatePaymentByCardTokenAsync(
                    merchantOrderId,
                     requestId,
                     email,
                     phoneNumber,
                     sessionId,
                     ipAddress,
                     amount,
                     currency,
                     sourceId,
                     cardToken,
                     threeDsChallengeIndicator,
                     description,
                     verificationUrlSuccess,
                     verificationUrlFailure,
                     verificationUrlCancel,
                     verificationUrlInProcess,
                     verificationUrlReturn,
                     time,
                     paymentMethod,
                     clientId,
                     cancellationToken )
                .Result;
        
        public async Task<WebCallResult<PaymentGatewayCreationResponse>> CreatePaymentByCardTokenAsync(
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
            bool useThreeDsChallengeIndicator,
            string description,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            string verificationUrlCancel,
            string verificationUrlInProcess,
            string verificationUrlReturn,
            DateTime time,
            string paymentMethod,
            string clientId,
            CancellationToken cancellationToken = default)
        {
            var data = new PaymentRequest
            {
                Request = new Request
                {
                    Id = requestId,
                    Time = time
                },
                Customer = new PaymentRequestCustomer
                {
                    Email = email,
                    Id = clientId,
                    Phone = phoneNumber,
                    Ip = ipAddress
                },
                MerchantOrder = new PaymentRequestMerchantOrder
                {
                    Description = description,
                    Id = merchantOrderId,
                },
                CardAccount = new PaymentRequestCardAccount
                {
                    Token = cardToken
                },
                PaymentData = new PaymentRequestPaymentData
                {
                    Amount = amount.ToString(CultureInfo.InvariantCulture),
                    Currency = currency,
                    GenerateToken = false,
                    Note = description,
                    ThreeDsChallengeIndicator = useThreeDsChallengeIndicator == false ? "01" : "04"
                },
                PaymentMethod = paymentMethod,
                ReturnUrls = new ReturnUrls()
                {
                    SuccessUrl = verificationUrlSuccess,
                    DeclineUrl = verificationUrlFailure,
                    CancelUrl = verificationUrlCancel,
                    InprocessUrl = verificationUrlInProcess,
                    ReturnUrl = verificationUrlReturn
                }
            };

            return await PostAsync<PaymentGatewayCreationResponse>($"{EndpointUrl}/payments", data, cancellationToken);
        }

        
        /// <summary>
        /// Get a payment.
        /// </summary>
        /// <param name="paymentId">Unique identifier of the payment.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public WebCallResult<PaymentResponse> GetPaymentById(string paymentId, CancellationToken cancellationToken = default) =>
            GetPaymentByIdAsync(paymentId, cancellationToken).Result;

        public async Task<WebCallResult<PaymentResponse>> GetPaymentByIdAsync(string paymentId,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaymentResponse>($"{EndpointUrl}/payments/{paymentId}", cancellationToken);
        }

        public async Task<WebCallResult<PaymentDataResponse>> GetPaymentByMerchantOrderIdAsync(
            string merchantOrderId, string requestId,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaymentDataResponse>($"{EndpointUrl}/payments?merchant_order_id={merchantOrderId}&request_id={requestId}", 
                cancellationToken);
        }
    }

    #endregion
}