using System;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Payments;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region Payments

        /// <summary>
        /// Create a payment.
        /// </summary>
        public WebCallResult<PaymentResponse> CreatePayment(
            string idempotencyKey, 
            string keyId,
            string email,
            string phoneNumber, string sessionId,
            string ipAddress, decimal amount, string currency, string verification, string sourceId, string sourceType,
            string description, string encryptedData, string verificationUrlSuccess, string verificationUrlFailure, 
            DateTime time, string paymentMethod, CancellationToken cancellationToken = default) =>
            CreatePaymentAsync(idempotencyKey,
                keyId, email, phoneNumber, sessionId, ipAddress, amount, currency, verification, sourceId, sourceType,
                description, encryptedData, verificationUrlSuccess, verificationUrlFailure, time, paymentMethod, cancellationToken).Result;
        
        public async Task<WebCallResult<PaymentResponse>> CreatePaymentAsync(
            string idempotencyKey, 
            string keyId,
            string email,
            string phoneNumber, 
            string sessionId,
            string ipAddress, 
            decimal amount, 
            string currency, 
            string verification, 
            string sourceId, 
            string sourceType,
            string description, 
            string encryptedData, 
            string verificationUrlSuccess, 
            string verificationUrlFailure, 
            DateTime time, 
            string paymentMethod,
            CancellationToken cancellationToken = default)
        {
            var data = new PaymentRequest
            {
                Request = new Request
                {
                    Id = keyId,
                    Time = time
                },
                Customer = new PaymentRequestCustomer
                {
                    //BirthDate = null,
                    //DocumentType = null,
                    Email = email,
                    //FirstName = null,
                    //FullName = null,
                    //HomePhone = null,
                    //Id = null,
                    //Identity = null,
                    //LastName = null,
                    //LivingAddress = null,
                    //Locale = null,
                    Phone = phoneNumber,
                    //WorkPhone = null,
                    Ip = ipAddress
                },
                MerchantOrder = new PaymentRequestMerchantOrder
                {
                    //CryptocurrencyIndicator = false,
                    Description = description,
                    //Flights = null,
                    Id = idempotencyKey,
                    //Items = null,
                    //ShippingAddress = null
                },
                PaymentData = new PaymentRequestPaymentData
                {
                    Amount = amount,
                    //AuthenticationRequest = false,
                    Currency = currency,
                    //DynamicDescriptor = null,
                    //EncryptedData = null,
                    //GenerateToken = false,
                    //InstallmentAmount = 0,
                    //InstallmentType = null,
                    //Installments = 0,
                    //Note = description,
                    //Preauth = false,
                    //ThreeDsChallengeIndicator = null,
                    //TransType = (TransTypeEnum)0
                },
                PaymentMethod = paymentMethod,
                //PaymentMethods = null,
                ReturnUrls = new ReturnUrls()
                {
                    SuccessUrl = verificationUrlSuccess,
                    DeclineUrl = verificationUrlFailure
                }
            };
            return await PostAsync<PaymentResponse>($"{EndpointUrl}/payments", data, cancellationToken);
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