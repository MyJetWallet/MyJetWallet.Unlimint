using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Payments;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;

namespace MyJetWallet.Unlimint
{
    public partial class UnlimintClient
    {
        #region PaymentsGatewayGooglepay

        public WebCallResult<PaymentGatewayCreationResponse> CreateGatewayGooglepayPayment(
            string merchantOrderId,
            string requestId, decimal amount, string currency, string description, 
            string appleEncryptedData, string verificationUrlSuccess,
            string verificationUrlFailure, string verificationUrlCancel, string verificationUrlInProcess,
            string verificationUrlReturn, DateTime time, PaymentRequestCustomer customer,
            CancellationToken cancellationToken = default) =>
            CreateGatewayGooglepayPaymentAsync(
                    merchantOrderId, requestId, amount, currency, description, appleEncryptedData,
                    verificationUrlSuccess, verificationUrlFailure, verificationUrlCancel, verificationUrlInProcess,
                    verificationUrlReturn, time, customer, cancellationToken = default)
                .Result;
        

        public async Task<WebCallResult<PaymentGatewayCreationResponse>> CreateGatewayGooglepayPaymentAsync(
            string merchantOrderId,
            string requestId,
            decimal amount,
            string currency,
            string description,
            string appleEncryptedData,
            string verificationUrlSuccess,
            string verificationUrlFailure,
            string verificationUrlCancel,
            string verificationUrlInProcess,
            string verificationUrlReturn,
            DateTime time,
            PaymentRequestCustomer customer,
            CancellationToken cancellationToken = default)
        {
            var data = new PaymentRequest
            {
                Request = new Request
                {
                    Id = requestId,
                    Time = time
                },
                Customer = customer,
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
                    EncryptedData = appleEncryptedData
                },
                PaymentMethod = "GOOGLEPAY",
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
        #endregion
    }
}