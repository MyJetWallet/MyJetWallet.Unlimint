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
            string requestId, decimal amount,
            string currency, bool useThreeDsChallengeIndicator, string description,
            string verificationUrlSuccess, string verificationUrlFailure, string verificationUrlCancel,
            string verificationUrlInProcess, string verificationUrlReturn, DateTime time, 
            PaymentRequestCustomer customer, CancellationToken cancellationToken = default) =>
            CreateAlternativePaymentAsync(paymentAlternativeType, merchantOrderId, requestId, amount,
                currency, useThreeDsChallengeIndicator,
                description, verificationUrlSuccess, verificationUrlFailure, verificationUrlCancel,
                verificationUrlInProcess, verificationUrlReturn, time, customer, cancellationToken = default).Result;

        public async Task<WebCallResult<PaymentGatewayCreationResponse>> CreateAlternativePaymentAsync(
            PaymentAlternativeType paymentAlternativeType,
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
            CancellationToken cancellationToken = default)
        {
            PaymentRequest request = null;
            switch (paymentAlternativeType)
            {
                case PaymentAlternativeType.Boleto:
                    request = CreateBoletoPaymentRequestAsync(merchantOrderId,
                        requestId,
                        amount,
                        currency,
                        useThreeDsChallengeIndicator,
                        description,
                        verificationUrlSuccess,
                        verificationUrlFailure,
                        verificationUrlCancel,
                        verificationUrlInProcess,
                        verificationUrlReturn,
                        time, 
                        customer,
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
            CancellationToken cancellationToken = default)
        {
            var request = new PaymentRequest
            {
                Request = new Request
                {
                    Id = requestId,
                    Time = time
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
                Customer = customer
            };
            return request;
        }
    }
    #endregion
}