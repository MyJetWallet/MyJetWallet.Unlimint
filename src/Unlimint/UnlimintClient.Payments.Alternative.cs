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

        public WebCallResult<PaymentGatewayCreationResponse> CreateAlternativePayment(
            PaymentAlternativeType paymentAlternativeType, string merchantOrderId,
            string requestId, string email, string phoneNumber, string sessionId, string ipAddress, decimal amount,
            string currency, string fullName, bool useThreeDsChallengeIndicator, string description,
            string verificationUrlSuccess, string verificationUrlFailure, string verificationUrlCancel,
            string verificationUrlInProcess, string verificationUrlReturn, DateTime time, string clientId,
            string identity,
            string zip, CancellationToken cancellationToken = default) =>
            CreateAlternativePaymentAsync(paymentAlternativeType, merchantOrderId, requestId, email, phoneNumber,
                sessionId,
                ipAddress, amount, currency, fullName, useThreeDsChallengeIndicator,
                description, verificationUrlSuccess, verificationUrlFailure, verificationUrlCancel,
                verificationUrlInProcess, verificationUrlReturn, time, clientId, identity,
                zip, cancellationToken = default).Result;

        public async Task<WebCallResult<PaymentGatewayCreationResponse>> CreateAlternativePaymentAsync(
            PaymentAlternativeType paymentAlternativeType,
            string merchantOrderId,
            string requestId,
            string email,
            string phoneNumber,
            string sessionId,
            string ipAddress,
            decimal amount,
            string currency,
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
            PaymentRequest request = null;
            switch (paymentAlternativeType)
            {
                case PaymentAlternativeType.Boleto:
                    request = CreateBoletoPaymentRequestAsync(merchantOrderId,
                        requestId,
                        email,
                        phoneNumber,
                        sessionId,
                        ipAddress,
                        amount,
                        currency,
                        fullName,
                        useThreeDsChallengeIndicator,
                        description,
                        verificationUrlSuccess,
                        verificationUrlFailure,
                        verificationUrlCancel,
                        verificationUrlInProcess,
                        verificationUrlReturn,
                        time, clientId,
                        identity,
                        zip,
                        cancellationToken);
                    break;
                default:
                    break;
            }

            return await PostAsync<PaymentGatewayCreationResponse>($"{EndpointUrl}/payments", request,
                cancellationToken);
        }

        private PaymentRequest CreateBoletoPaymentRequestAsync(
            string merchantOrderId,
            string requestId,
            string email,
            string phoneNumber,
            string sessionId,
            string ipAddress,
            decimal amount,
            string currency,
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
            var request = new PaymentRequest
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
                    ThreeDsChallengeIndicator = useThreeDsChallengeIndicator == false ? "01" : "04"
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
            return request;
        }
    }
    #endregion
}