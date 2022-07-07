using System;
using System.Text.Json;
using System.Threading.Tasks;
using MyJetWallet.Unlimint;

namespace TestApp
{
    static class Program
    {
        private static string _accessToken;
        private static IUnlimintClient _client;

        static async Task Main(string[] args)
        {
            _accessToken = Environment.GetEnvironmentVariable("CircleAccessToken");

            if (string.IsNullOrEmpty(_accessToken))
            {
                Console.WriteLine("AccessToken is empty. Please setup env variable");
                return;
            }

            _client = new UnlimintClient(_accessToken, CircleNetwork.Test);


            var card = await _client.GetCardAsync("");
            var payment = await _client.GetPaymentAsync("be42103b-b420-4d2e-96a4-805cdc94b7d7");
            var transfer = await _client.CreateBusinessTransferAsync(Guid.NewGuid().ToString(), "dd86f811-62e5-5aa8-bd02-b3b6958d5d7e", "10", "USD");

            //await TestPayouts();
            // await TestPublicKey();
            //await TestCards();
            //await TestBankAccounts();
        }

        private static async Task TestPublicKey()
        {
            var key = await _client.GetPublicKeyAsync();
            Console.WriteLine(JsonSerializer.Serialize(key, new JsonSerializerOptions()
            {
                WriteIndented = true
            }));
        }

        private static async Task TestCards()
        {
            var cards = await _client.GetListOfCardsAsync();
            Console.WriteLine(JsonSerializer.Serialize(cards, new JsonSerializerOptions()
            {
                WriteIndented = true
            }));

            //var card = await _client.GetCardAsync("1");
            //Console.WriteLine(JsonSerializer.Serialize(card, new JsonSerializerOptions()
            //{
            //    WriteIndented = true
            //}));
        }

        private static async Task TestBankAccounts()
        {
            //EXAMPLE FROM CIRCLE

            var details = await _client.ObtainBankWireTransferDetailsAsync("230c9646-53d5-4df2-9fe9-dc7131cadcb9");

            var bank1 = await _client.CreateBankAccountUsSwiftAsync(
                "6ae62bf2-bd71-49ce-a599-165ffcc33680",
                "123456789",
                "021000021",
                new MyJetWallet.Unlimint.Models.WireTransfers.BillingDetails
                {
                    City = "Boston",
                    Country = "US",
                    District = "MA",
                    Line1 = "1 Main Street",
                    Name = "John Smith",
                    PostalCode = "02201",
                },
                new MyJetWallet.Unlimint.Models.WireTransfers.BankAddress
                {
                    Country = "US",
                });

            Console.WriteLine(JsonSerializer.Serialize(bank1, new JsonSerializerOptions()
            {
                WriteIndented = true
            }));
        }

        private static async Task TestPayouts()
        {
            //EXAMPLE FROM CIRCLE

            var idempotenctId = Guid.NewGuid().ToString();//
            var payout = await _client.CreatePayoutAsync(idempotenctId, "100", "USD", "1000194444", "230c9646-53d5-4df2-9fe9-dc7131cadcb9", "wire", 
                "email.b@email.net");

            Console.WriteLine(JsonSerializer.Serialize(payout, new JsonSerializerOptions()
            {
                WriteIndented = true
            }));
        }
    }
}