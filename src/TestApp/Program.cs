using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MyJetWallet.Unlimint;

namespace TestApp
{
    static class Program
    {

        private static IUnlimintAuthClient _authClient;
        private static IUnlimintClient _client;

        static async Task Main(string[] args)
        {
            var terminalcCode = "XXX";
            var password = "***";
            
            _authClient = new UnlimintAuthClient(terminalcCode, password, UnlimintNetwork.Test);
            var token = await _authClient.GetAuthorizationTokenAsync();
                
            _client = new UnlimintClient(token?.Data?.AccessToken, UnlimintNetwork.Test);
            var paymentId = Guid.NewGuid().ToString();
            var merchantOrderId = Guid.NewGuid().ToString();
            var payment = await _client.CreatePaymentAsync(
                merchantOrderId, 
                paymentId, 
                "yuriy.2022.07.10.001@mailinator.com",
                "+359885989618", 
                "session-id", 
                "234.22.12.01", 
                12.35m, 
                "USD", 
                null, 
                null, 
                null, 
                "yuriy-test-payment", 
                null, 
                "https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?success=true", 
                "https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?failure=true", 
                DateTime.UtcNow, 
                "BANKCARD",
                "CLIENT-936147-bee8-4468-86f2");
 

            var paymentInfo = await _client.GetPaymentAsync(paymentId);
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