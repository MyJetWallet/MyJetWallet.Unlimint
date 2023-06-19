using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Payments;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region PaymentsAlternative

        public WebCallResult<PaymentGatewayCreationResponse> CreateAlternativePayment(
            string paymentMethod, string merchantOrderId,
            string requestId, decimal amount,
            string currency, bool useThreeDsChallengeIndicator, string description,
            string verificationUrlSuccess, string verificationUrlFailure, string verificationUrlCancel,
            string verificationUrlInProcess, string verificationUrlReturn, DateTime time,
            PaymentRequestCustomer customer, ShippingAddress shippingAddress = null,
            CancellationToken cancellationToken = default) =>
            CreateAlternativePaymentAsync(paymentMethod, merchantOrderId, requestId, amount,
                currency, useThreeDsChallengeIndicator,
                description, verificationUrlSuccess, verificationUrlFailure, verificationUrlCancel,
                verificationUrlInProcess, verificationUrlReturn, time, customer, shippingAddress = null,
                cancellationToken = default).Result;

        public async Task<WebCallResult<PaymentGatewayCreationResponse>> CreateAlternativePaymentAsync(
            string paymentMethod,
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
            ShippingAddress shippingAddress = null,
            CancellationToken cancellationToken = default)
        {
            var request = CreateAlternativePaymentRequest(
                paymentMethod,
                merchantOrderId,
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
                shippingAddress,
                cancellationToken);
            return await PostAsync<PaymentGatewayCreationResponse>($"{EndpointUrl}/payments", request,
                cancellationToken);
        }

        private PaymentRequest CreateAlternativePaymentRequest(
            string paymentMethod,
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
            ShippingAddress shippingAddress = null,
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
                    ShippingAddress = shippingAddress,
                },
                PaymentData = new PaymentRequestPaymentData
                {
                    Amount = amount.ToString(CultureInfo.InvariantCulture),
                    Currency = currency,
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
                },
                Customer = customer
            };
            return request;
        }

    }
    #endregion
}