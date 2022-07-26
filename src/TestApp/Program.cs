using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MyJetWallet.Unlimint;

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
                1000m, 
                "USD", 
                "jetwallet|-|5e1c37e3230144a48ccb13b9662fc491|-|SP-5e1c37e3230144a48ccb13b9662fc491", 
                true, 
                "01" == "04", 
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
            var paymentId = paymentDataInfo?.Data?.Payments
                .FirstOrDefault()?
                .PaymentData
                .Id;
            var paymentCardToken = paymentDataInfo?.Data?.Payments
                .FirstOrDefault()?
                .CardAccount
                .Token;
            var paymentInfo = await _client.GetPaymentByIdAsync(paymentId);
            
            // New payment with the same card
            requestId = Guid.NewGuid().ToString();
            merchantOrderId = Guid.NewGuid().ToString();
            var paymentSecond = await _client.CreatePaymentByCardTokenAsync(
                merchantOrderId, 
                requestId, 
                "yuriy.test.2022.07.15.001@mailinator.com",
                //"+359885989618", 
                null,
                "259f6226-4231-4936-8bf4-19f5cc900109", 
                "234.22.12.01", 
                1000m, 
                "USD", 
                "jetwallet|-|5e1c37e3230144a48ccb13b9662fc491|-|SP-5e1c37e3230144a48ccb13b9662fc491", 
                paymentCardToken,
                "01" == "04", 
                "jetwallet|-|5e1c37e3230144a48ccb13b9662fc491|-|SP-5e1c37e3230144a48ccb13b9662fc491", 
                "https://simple.app/circle/success", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?success=true", 
                "https://simple.app/circle/failure", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?failure=true",
                null,
                null,
                null,
                DateTime.UtcNow, 
                "BANKCARD",
                "CLIENT-5e1c37e3230144a48ccb13b9662fc491");
            var paymentSecondUrl = paymentSecond.Data.RedirectUrl;
            
            var paymentSecondDataInfo = await _client.GetPaymentByMerchantOrderIdAsync(
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