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
        #region PaymentsGateway

        public WebCallResult<PaymentGatewayCreationResponse> CreateGatewayBankCardPayment(
            string merchantOrderId,
            string requestId, decimal amount, string currency,
            bool generateToken, bool useThreeDsChallengeIndicator, string description, string verificationUrlSuccess,
            string verificationUrlFailure, string verificationUrlCancel, string verificationUrlInProcess,
            string verificationUrlReturn, DateTime time, PaymentRequestCustomer customer,
            PaymentRequestCardAccount cardAccount,
            CancellationToken cancellationToken = default) =>
            CreateGatewayBankCardPaymentAsync(
                    merchantOrderId, requestId, amount, currency, generateToken, useThreeDsChallengeIndicator, description,
                    verificationUrlSuccess, verificationUrlFailure, verificationUrlCancel, verificationUrlInProcess,
                    verificationUrlReturn, time, customer, cardAccount, cancellationToken = default)
                .Result;
        
      

        public async Task<WebCallResult<PaymentGatewayCreationResponse>> CreateGatewayBankCardPaymentAsync(
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
                    GenerateToken = generateToken,
                    Note = description,
                    ThreeDsChallengeIndicator = useThreeDsChallengeIndicator == false ? "01" : "04"
                },
                PaymentMethod = "BANKCARD",
                ReturnUrls = new ReturnUrls()
                {
                    SuccessUrl = verificationUrlSuccess,
                    DeclineUrl = verificationUrlFailure,
                    CancelUrl = verificationUrlCancel,
                    InprocessUrl = verificationUrlInProcess,
                    ReturnUrl = verificationUrlReturn
                },
                CardAccount = cardAccount
            };
            return await PostAsync<PaymentGatewayCreationResponse>($"{EndpointUrl}/payments", data, cancellationToken);
        }
        #endregion
    }
}