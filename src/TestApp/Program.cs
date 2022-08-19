using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MyJetWallet.Unlimint;
using MyJetWallet.Unlimint.Models;
using MyJetWallet.Unlimint.Models.Payments;

namespace TestApp
{
    static class Program
    {

        private static UnlimintAuthClient _authClient;
        private static UnlimintClient _client;

        static async Task Main(string[] args)
        {
            //TODO: Remove credentials
            var terminalcCode = Environment.GetEnvironmentVariable("UNLIMINT_TERMINAL_CODE");
            var password = Environment.GetEnvironmentVariable("UNLIMINT_PASSWORD");
            
            _authClient = new UnlimintAuthClient(terminalcCode, password, UnlimintNetwork.Test);
            _client = new UnlimintClient(null, UnlimintNetwork.Test);
            var token = await _authClient.GetAuthorizationTokenAsync();
            _client.SetAccessToken(token?.Data?.AccessToken);

            
            var paymentInf1 = await _client.GetPaymentByIdAsync("13391885");
            var paymentInf2 = await _client.GetPaymentByIdAsync("13391861");
            var paymentInf3 = await _client.GetPaymentByIdAsync("13391879");
            var paymentInf4 = await _client.GetPaymentByIdAsync("13391877");
            var paymentInf5 = await _client.GetPaymentByIdAsync("13427293");
            var paymentInf6 = await _client.GetPaymentByIdAsync("13455113");
            
            
            //
            // var paymentDataInfo2 = await _client.GetPaymentByMerchantOrderIdAsync(
            //     "879f1aa2-8145-4651-a6ef-bffa411ca741", "13391861");
            //
            var requestId = Guid.NewGuid().ToString();
            var merchantOrderId = Guid.NewGuid().ToString();
            var paymentFirst = await _client.CreatePaymentAsync(
                merchantOrderId, 
                requestId, 
                "yuriy.test.2022.07.15.001@mailinator.com",
                //"+359885989618", 
                null,
                "259f6226-4231-4936-8bf4-19f5cc900109", 
                "234.22.12.01", 
                100m, 
                "USD", 
                "jetwallet|-|5e1c37e3230144a48ccb13b9662fc491|-|SP-5e1c37e3230144a48ccb13b9662fc491", 
                true, 
                true, 
                "jetwallet|-|5e1c37e3230144a48ccb13b9662fc491|-|SP-5e1c37e3230144a48ccb13b9662fc491", 
                "https://simple.app/circle/success", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?success=true", 
                "https://simple.app/circle/failure", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?failure=true",
                null,
                null,
                null,
                DateTime.UtcNow, 
                "BANKCARD",
                "CLIENT-5e1c37e3230144a48ccb13b9662fc491");
            
            var paymentFirstUrl = paymentFirst.Data.RedirectUrl;
            var paymentDataInfo = await _client.GetPaymentByMerchantOrderIdAsync(
                merchantOrderId, requestId);
            // var paymentId = paymentDataInfo?.Data?.Payments
            //     .FirstOrDefault()?
            //     .PaymentData
            //     .Id;
            // var paymentCardToken = paymentDataInfo?.Data?.Payments
            //     .FirstOrDefault()?
            //     .CardAccount
            //     .Token;
            // var paymentInfo = await _client.GetPaymentByIdAsync(paymentId);
            //
            // // New payment with the same card
            // requestId = Guid.NewGuid().ToString();
            // merchantOrderId = Guid.NewGuid().ToString();
            // var paymentSecond = await _client.CreatePaymentByCardTokenAsync(
            //     merchantOrderId, 
            //     requestId, 
            //     "yuriy.test.2022.07.15.001@mailinator.com",
            //     //"+359885989618", 
            //     null,
            //     "259f6226-4231-4936-8bf4-19f5cc900109", 
            //     "234.22.12.01", 
            //     555m, 
            //     "USD", 
            //     "jetwallet|-|5e1c37e3230144a48ccb13b9662fc491|-|SP-5e1c37e3230144a48ccb13b9662fc491", 
            //     paymentCardToken,
            //     true, 
            //     "jetwallet|-|5e1c37e3230144a48ccb13b9662fc491|-|SP-5e1c37e3230144a48ccb13b9662fc491", 
            //     "https://simple.app/circle/success", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?success=true", 
            //     "https://simple.app/circle/failure", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?failure=true",
            //     null,
            //     null,
            //     null,
            //     DateTime.UtcNow, 
            //     "BANKCARD",
            //     "CLIENT-5e1c37e3230144a48ccb13b9662fc491");
            // var paymentSecondUrl = paymentSecond.Data.RedirectUrl;
            
            // var paymentSecondDataInfo = await _client.GetPaymentByMerchantOrderIdAsync(
            //     merchantOrderId, requestId);
            //
            //
            
            requestId = Guid.NewGuid().ToString();
            merchantOrderId = Guid.NewGuid().ToString();
            await TestBoletoMethod(
                merchantOrderId, 
                requestId, 
                "yuriy.test.2022.07.15.001@mailinator.com",
                "+359885989618", 
                "259f6226-4231-4936-8bf4-19f5cc900109", 
                "234.22.12.01", 
                10m, 
                "EUR",
                "Yuriy Test",
                true, 
                "Simple.app order description", 
                "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?success=true", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?success=true", 
                "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?failure=true", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?failure=true",
                "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?cancel=true",
                "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?inproccess=true",
                "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?return=true",
                DateTime.UtcNow, 
                "CLIENT-5e1c37e3230144a48ccb13b9662fc491",
                "31130088910", 
                "04642-000");
        }

        private static async Task TestBoletoMethod(string merchantOrderId,
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
            var paymentFirstBoleto = await _client.CreateAlternativePaymentAsync(
                PaymentAlternativeType.Boleto,
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
                new PaymentRequestCustomer
                {
                    //BirthDate = null,
                    //DocumentType = null,
                    Email = email,
                    //FirstName = null,
                    FullName = fullName,
                    //HomePhone = null,
                    Id = clientId,
                    Identity = identity,
                    //LastName = null,
                    LivingAddress = new PaymentRequestLivingAddress()
                    {
                        Zip = zip
                    },
                    //Locale = null,
                    //Phone = null,
                    //WorkPhone = null,
                    Ip = ipAddress
                },
                cancellationToken);
            
            var paymentFirstBoletoUrl = paymentFirstBoleto.Data.RedirectUrl;
            
            var paymentFirstBoletoDataInfo = await _client.GetPaymentByMerchantOrderIdAsync(
                merchantOrderId, requestId);
        }
        
        private static async Task TestPublicKey()
        {
            var key = await _authClient.GetAuthorizationTokenAsync();
             Console.WriteLine(JsonSerializer.Serialize(key, new JsonSerializerOptions()
             {
                 WriteIndented = true
             }));
        }
    }
}