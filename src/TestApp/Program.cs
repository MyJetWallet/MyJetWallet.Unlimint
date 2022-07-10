using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MyJetWallet.Unlimint;

namespace TestApp
{
    static class Program
    {
        private static string _accessToken;
        private static IUnlimintClient _client;

        static async Task Main(string[] args)
        {
            _accessToken = Environment.GetEnvironmentVariable("UnlimintAccessToken");

            if (string.IsNullOrEmpty(_accessToken))
            {
                Console.WriteLine("AccessToken is empty. Please setup env variable");
                return;
            }

            _client = new UnlimintClient(_accessToken, UnlimintNetwork.Test);
            //var token = await _client.GetAuthorizationTokenAsync("FpK2cy143POj", "18397");
            var token = await _client.CreatePaymentAsync(
                Guid.NewGuid().ToString(), 
                "key-id-" + Guid.NewGuid().ToString(), 
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
                "BANKCARD");
 

            var payment = await _client.GetPaymentAsync("be42103b-b420-4d2e-96a4-805cdc94b7d7");

            //await TestPublicKey();
        }

        private static async Task TestPublicKey()
        {
            var terminalcCode = "18397";
            var password = "FpK2cy143POj";
            var key = await _client.GetAuthorizationTokenAsync(terminalcCode, password);
             Console.WriteLine(JsonSerializer.Serialize(key, new JsonSerializerOptions()
             {
                 WriteIndented = true
             }));
        }
    }
}