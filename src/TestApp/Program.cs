using System;
using System.Collections.Generic;
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
            await TestAlternativeMethodInBpl("es", "BRL");
            await TestAlternativeMethodInBpl("it", "BRL");
            await TestAlternativeMethodInBpl("ru", "BRL");

            await TestAlternativeMethodInBpl("es", "MXN");
            await TestAlternativeMethodInBpl("it", "MXN");
            await TestAlternativeMethodInBpl("ru", "MXN");

            await TestAlternativeMethodInBpl("es", "COP");
            await TestAlternativeMethodInBpl("it", "COP");
            await TestAlternativeMethodInBpl("ru", "COP");
            
            
            //TODO: Remove credentials
            var terminalcCode = Environment.GetEnvironmentVariable("UNLIMINT_TERMINAL_CODE");
            var password = Environment.GetEnvironmentVariable("UNLIMINT_PASSWORD");

            _authClient = new UnlimintAuthClient(terminalcCode, password, UnlimintNetwork.Test);
            _client = new UnlimintClient(null, UnlimintNetwork.Test);
            var token = await _authClient.GetAuthorizationTokenAsync();
            if (!token.Success || string.IsNullOrEmpty(token.Data?.AccessToken))
            {
                Console.WriteLine(token.Message);
            }

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
            // var paymentFirst = await _client.CreatePaymentAsync(
            //     merchantOrderId, 
            //     requestId, 
            //     "yuriy.test.2022.07.15.001@mailinator.com",
            //     //"+359885989618", 
            //     null,
            //     "259f6226-4231-4936-8bf4-19f5cc900109", 
            //     "234.22.12.01", 
            //     100m, 
            //     "USD", 
            //     "jetwallet|-|5e1c37e3230144a48ccb13b9662fc491|-|SP-5e1c37e3230144a48ccb13b9662fc491", 
            //     true, 
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
            //
            // var paymentFirstUrl = paymentFirst.Data.RedirectUrl;
            // var paymentDataInfo = await _client.GetPaymentByMerchantOrderIdAsync(
            //     merchantOrderId, requestId);
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
        }

        private static async Task TestPublicKey()
        {
            var key = await _authClient.GetAuthorizationTokenAsync();
             Console.WriteLine(JsonSerializer.Serialize(key, new JsonSerializerOptions()
             {
                 WriteIndented = true
             }));
        }
        
        
        private static async Task TestAlternativeMethodInBpl(string locale, string currency)
        {
            var terminalcCode = Environment.GetEnvironmentVariable("UNLIMINT_TERMINAL_CODE_" + currency);
            var password = Environment.GetEnvironmentVariable("UNLIMINT_PASSWORD_" + currency);
            
            var authClient = new UnlimintAuthClient(terminalcCode, password, UnlimintNetwork.Test);
            var client = new UnlimintClient(null, UnlimintNetwork.Test);
            
            var token = await authClient.GetAuthorizationTokenAsync();
            if (!token.Success || string.IsNullOrEmpty(token.Data?.AccessToken))
            {
                Console.WriteLine(token.Message);
            }
            client.SetAccessToken(token?.Data?.AccessToken);
            
            var requestId = Guid.NewGuid().ToString();
            var merchantOrderId = Guid.NewGuid().ToString();
            
            var paymentAlternativeResponse = await client.CreateAlternativePaymentAsync(
                new List<string>(){"DAVIVIENDA", "BALOTO", "BOLETO","WALMART", "COMERCIALMEXICANA"},
                merchantOrderId, 
                requestId, 
                10m, 
                currency, 
                true, 
                "Simple.app order description", 
                "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?success=true", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?success=true", 
                "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?failure=true", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?failure=true",
                "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?cancel=true",
                "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?inproccess=true",
                "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?return=true",
                DateTime.UtcNow, 
                new PaymentRequestCustomer
                {
                    BirthDate = DateTime.UtcNow.AddYears(-33).ToString("yyyy-MM-dd"),
                    DocumentType = null,
                    Email = "yuriy.test.2022.07.15.001@mailinator.com",
                    FirstName = "Yuriy",
                    FullName = "Yuriy Test",
                    //HomePhone = null,
                    Id = "5e1c37e3230144a48ccb13b9662fc491",
                    Identity = "Test",
                    LastName = "Test",
                    LivingAddress = new PaymentRequestLivingAddress()
                    {
                        Address = "Rua Visconde de Porto Seguro 1238",
                        City = "Sao Paulo",
                        Country = "Brazil",
                        State = "SP",
                        Zip = "04642-000"
                    },
                    Locale = locale,
                    Phone = "+359885989618",
                    //WorkPhone = null,
                    Ip = "123.123.123.123"
                }//,cancellationToken
                );
            
            
            if (!paymentAlternativeResponse.Success)
            {
                Console.WriteLine(paymentAlternativeResponse.Message);
            }
            var paymentAlternativeResponseUrl = paymentAlternativeResponse.Data.RedirectUrl;
            
            var paymentAlternativeInfo = await client.GetPaymentByMerchantOrderIdAsync(
                merchantOrderId, requestId);
        }
        
    }
}