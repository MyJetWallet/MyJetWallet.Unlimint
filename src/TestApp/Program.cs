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
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestApp
{
    static class Program
    {
        private static UnlimintAuthClient _authClient;
        private static UnlimintClient _client;

        static async Task Main(string[] args)
        {
            //await TestCardBin("US", "USD");
            //await TestGooglepayMethod("US", "USD");

            //await TestProdBankMethod("DE", "EUR");

            //await TestGatewayMethod("es", "EUR");
            // await TestGatewayMethod("es", "EUR");
            // await TestGatewayMethod("es", "EUR");
            // await TestGatewayMethod("es", "EUR");
            //
            //await TestAlternativeMethod("es", "USD");
            // await TestAlternativeMethod("it", "USD");
            //await TestAlternativeMethod("ru", "USD");

            //await TestAlternativeMethod("es", "BRL");
            // await TestAlternativeMethod("it", "BRL");
            // await TestAlternativeMethod("ru", "BRL");
            //
            //await TestAlternativeMethod("es", "MXN");
            //await TestAlternativeMethod("it", "MXN");
            // await TestAlternativeMethod("ru", "MXN");
            //
            // await TestAlternativeMethod("es", "COP");
            // await TestAlternativeMethod("it", "COP");
            // await TestAlternativeMethod("ru", "COP");

            // var terminalcCode = Environment.GetEnvironmentVariable("MyJetWallet-UnlimintSigner-DirectBankingEu-EUR-WalletId");
            // var password = Environment.GetEnvironmentVariable("MyJetWallet-UnlimintSigner-DirectBankingEu-EUR-Password");

            // _authClient = new UnlimintAuthClient(terminalcCode, password, UnlimintNetwork.Main);
            // _client = new UnlimintClient(null, UnlimintNetwork.Main);
            // var token = await _authClient.GetAuthorizationTokenAsync();
            // if (!token.Success || string.IsNullOrEmpty(token.Data?.AccessToken))
            // {
            //     Console.WriteLine(token.Message);
            // }
            //
            // _client.SetAccessToken(token?.Data?.AccessToken);

            // var paymentInf0 = await _client.GetPaymentByIdAsync("13502609");
            //
            // var paymentInf1 = await _client.GetPaymentByIdAsync("13391885");
            // var paymentInf2 = await _client.GetPaymentByIdAsync("13391861");
            // var paymentInf3 = await _client.GetPaymentByIdAsync("13391879");
            // var paymentInf4 = await _client.GetPaymentByIdAsync("13391877");
            // var paymentInf5 = await _client.GetPaymentByIdAsync("13427293");
            // var paymentInf6 = await _client.GetPaymentByIdAsync("13455113");
            //

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

            // await TestGetBanksProd("OPENBANKING", "EUR", null);
            // await TestGetBanksProd("OPENBANKING", "EUR", "GB");
        }

        private static async Task TestPublicKey()
        {
            var key = await _authClient.GetAuthorizationTokenAsync();
            Console.WriteLine(JsonSerializer.Serialize(key, new JsonSerializerOptions()
            {
                WriteIndented = true
            }));
        }


        // private static async Task TestAlternativeMethod(string locale, string currency)
        // {
        //     var terminalcCode = Environment.GetEnvironmentVariable("UNLIMINT_TERMINAL_CODE_" + currency);
        //     var password = Environment.GetEnvironmentVariable("UNLIMINT_PASSWORD_" + currency);
        //
        //     var authClient = new UnlimintAuthClient(terminalcCode, password, UnlimintNetwork.Main);
        //     var client = new UnlimintClient(null, UnlimintNetwork.Main);
        //
        //     var token = await authClient.GetAuthorizationTokenAsync();
        //     if (!token.Success || string.IsNullOrEmpty(token.Data?.AccessToken))
        //     {
        //         Console.WriteLine(token.Message);
        //     }
        //
        //     client.SetAccessToken(token?.Data?.AccessToken);
        //
        //     var requestId = Guid.NewGuid().ToString();
        //     var merchantOrderId = Guid.NewGuid().ToString();
        //
        //     var paymentAlternativeResponse = await client.CreateAlternativePaymentAsync(
        //         string.Empty,
        //         new List<string>(),
        //         merchantOrderId,
        //         requestId,
        //         10m,
        //         currency,
        //         true,
        //         "Simple.app order description",
        //         "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?success=true", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?success=true", 
        //         "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?failure=true", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?failure=true",
        //         "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?cancel=true",
        //         "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?inproccess=true",
        //         "https://webhook.site/ed3ecb08-f6dc-4b72-ac8e-3345b1edd98c?return=true",
        //         DateTime.UtcNow,
        //         new PaymentRequestCustomer
        //         {
        //             BirthDate = DateTime.UtcNow.AddYears(-33).ToString("yyyy-MM-dd"),
        //             DocumentType = null,
        //             Email = "yuriy.test.2022.07.15.001@mailinator.com",
        //             FirstName = "Yuriy",
        //             FullName = "Yuriy Test",
        //             //HomePhone = null,
        //             Id = "5e1c37e3230144a48ccb13b9662fc491",
        //             Identity = "Test",
        //             LastName = "Test",
        //             LivingAddress = new PaymentRequestLivingAddress()
        //             {
        //                 Address = "Rua Visconde de Porto Seguro 1238",
        //                 City = "Sao Paulo",
        //                 Country = "Brazil",
        //                 State = "SP",
        //                 Zip = "04642-000"
        //             },
        //             Locale = locale,
        //             Phone = "+359885989618",
        //             //WorkPhone = null,
        //             Ip = "123.123.123.123"
        //         } //,cancellationToken
        //     );
        //
        //
        //     if (!paymentAlternativeResponse.Success)
        //     {
        //         Console.WriteLine(paymentAlternativeResponse.Message);
        //     }
        //
        //     var paymentAlternativeResponseUrl = paymentAlternativeResponse.Data.RedirectUrl;
        //
        //     var paymentAlternativeInfo = await client.GetPaymentByMerchantOrderIdAsync(
        //         merchantOrderId, requestId);
        // }


        private static async Task TestGatewayMethod(string locale, string currency)
        {
            var terminalcCode = Environment.GetEnvironmentVariable("UNLIMINT_TERMINAL_CODE_GW_" + currency);
            var password = Environment.GetEnvironmentVariable("UNLIMINT_PASSWORD_GW_" + currency);

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

            var paymentResponse = await client
                .CreateGatewayBankCardPaymentAsync(
                    merchantOrderId,
                    requestId,
                    10.12m,
                    currency,
                    true,
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
                            // City = "Sao Paulo",
                            // Country = "Brazil",
                            // State = "SP",
                            // Zip = "04642-000"
                        },
                        Locale = locale,
                        Phone = "+359885989618",
                        //WorkPhone = null,
                        Ip = "123.123.123.123"
                    },
                    new PaymentRequestCardAccount
                    {
                        BillingAddress = new BillingAddress
                        {
                            AddrLine1 = "Rua Visconde de Porto Seguro 1238",
                            City = "Varna",
                            Country = "BGR",
                            //State = "SP",
                            Zip = "9000",
                        },
                        Card = new PaymentRequestCard
                        {
                            AcctType = AcctTypeEnum.NotApplicable,
                            Expiration = "02/2023",
                            Holder = "TEST",
                            Pan = "4000000000000002",
                            //PinCode = null,
                            SecurityCode = "123"
                        },
                        //EncryptedCardData = null,
                        //Token = null
                    }
                    //,cancellationToken
                );


            if (!paymentResponse.Success)
            {
                Console.WriteLine(paymentResponse.Message);
            }
            else
            {
                var paymentResponseUrl = paymentResponse.Data.RedirectUrl;

                var paymentInfo = await client.GetPaymentByIdAsync(
                    paymentResponse.Data.PaymentData.Id);

                var paymentAlternativeInfo = await client.GetPaymentByMerchantOrderIdAsync(
                    merchantOrderId, requestId);
            }
        }

        private static async Task TestProdBankMethod(string locale, string currency)
        {
            var terminalcCode =
                Environment.GetEnvironmentVariable("MyJetWallet-UnlimintSigner-DirectBankingEu-EUR-WalletId");
            var password =
                Environment.GetEnvironmentVariable("MyJetWallet-UnlimintSigner-DirectBankingEu-EUR-Password");

            var authClient = new UnlimintAuthClient(terminalcCode, password, UnlimintNetwork.Main);
            var client = new UnlimintClient(null, UnlimintNetwork.Main);

            var token = await authClient.GetAuthorizationTokenAsync();
            if (!token.Success || string.IsNullOrEmpty(token.Data?.AccessToken))
            {
                Console.WriteLine(token.Message);
            }

            client.SetAccessToken(token?.Data?.AccessToken);

            var requestId = Guid.NewGuid().ToString("N");
            var merchantOrderId = Guid.NewGuid().ToString("N");
            try
            {
                var paymentFirst = await client.CreatePaymentAsync(
                    merchantOrderId,
                    requestId,
                    "yuriy.test.2022.07.15.001@mailinator.com",
                    //"+359885989618", 
                    null,
                    "259f6226-4231-4936-8bf4-19f5cc900109",
                    "234.22.12.01",
                    100m,
                    currency,
                    "jetwallet|-|5e1c37e3230144a48ccb13b9662fc491|-|SP-5e1c37e3230144a48ccb13b9662fc491",
                    true,
                    true,
                    null,
                    "jetwallet|-|5e1c37e3230144a48ccb13b9662fc491|-|SP-5e1c37e3230144a48ccb13b9662fc491",
                    "https://simple.app/circle/success", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?success=true", 
                    "https://simple.app/circle/failure", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?failure=true",
                    null,
                    null,
                    null,
                    DateTime.UtcNow,
                    "DIRECTBANKINGEU",
                    "CLIENT-5e1c37e3230144a48ccb13b9662fc491");

                if (!paymentFirst.Success)
                {
                    Console.WriteLine(paymentFirst.Message);
                }

                var paymentFirstResponseUrl = paymentFirst.Data.RedirectUrl;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            var paymentFirstInfo = await client.GetPaymentByMerchantOrderIdAsync(
                merchantOrderId, requestId);
        }
        
        
        private static async Task TestGooglepayMethod(string locale, string currency)
        {
            var terminalcCode = Environment.GetEnvironmentVariable("MyJetWallet-UnlimintSigner-Googlepay-" + currency +"-WalletId");
            var password = Environment.GetEnvironmentVariable("MyJetWallet-UnlimintSigner-Googlepay-" + currency + "-Password");

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
            //var encrytedData = "{\"signature\":\"MEUCIGE2lqzSMTFjCjNK8xkmOV2wTHRobEJouD9bKX/mOU05AiEA6fL3Cl+e6LCrtcxa3FqtFV1qdkebwh0TGoxn9SRCmr0\\u003d\",\"intermediateSigningKey\":{\"signedKey\":\"{\\\"keyValue\\\":\\\"MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEoo1+38SkcLa8iEpL68zMw1qdhF/qUyJVuQXETO34XVh+/2vQv3g6c7C2oTzxXBCwA7vCiBMowaU8hzfnaRO6aQ\\\\u003d\\\\u003d\\\",\\\"keyExpiration\\\":\\\"1666849559604\\\"}\",\"signatures\":[\"MEUCIDaYfD+XhPw0sihdOuZWKy90hCpYlXTZGw57h9IuKYzXAiEA++N/pwD4KgaG+nvRSk/RWqWBTVok0DwbcfCKtJcd8O0\\u003d\"]},\"protocolVersion\":\"ECv2\",\"signedMessage\":\"{\\\"encryptedMessage\\\":\\\"k78lqEB7rhMCa6OSvDKanRVL97GLsBRDmayt0P7lcDJ9yc+tW5h55PQidM+T50Mox8fIZF6uf4sBcak3faSEtH0JrYOrjiqo+/aqR2oDy5OIHeF4S4tOXjYcz5cAXWBp9kQe4zpnQ0Oz2Pv8zcw40l3hnHehAC4iTFAIABuFYiJJshZfnQkHt0JZHBxvBmj75/dOassRem0VJjvxXz/RFgtLZLPm3A6yw0chDvN+YcbsgBVrJAnfrAox5u2IQfO0MC8pSfRhnKW4ZvasZb29LJAofNOEOXH929AA65WQ/OiS+f4Fofng/qnvFZBxswjC2Q8uIAnZhsDveBJdnb9Dl5sF6Ui/6UxOGENh2Co3o0l/odFaG4Sw+paU4XQeLS4z8QEO7+nEmTPyHAz4U3bMqtDAdP4GWovNG2r/ABR+bcEDUhloRQeOFQqHPW7uofTD/spketegSQW66UJWcnoLsuGFgh4nK8zBifRrePnu0hAr9qYZCgbdkHjw/JNdSO749hD3Bb0LO2Ine2ZQ8sMNsh8F1xakn4cgVTsVjOiQ0nQmmdzVdOM4pOYuMj7O8dYkZ0usRg0fD1wV\\\",\\\"ephemeralPublicKey\\\":\\\"BF4WwdJDM05iwqB5IeFM6ChPsM2M31zwVxPY5cgaMTJKi/l0qDvreWqps/7WqnTqABHKLwq08Hcz90nU+Y2Z7fI\\\\u003d\\\",\\\"tag\\\":\\\"/1bc8yjdhQV9RKMYM+2oG3QUecl469N4hZ0sNVvC/nI\\\\u003d\\\"}\"}\n";
            //var encrytedData = "{\"signature\":\"MEYCIQDzxhFXnEZ+mbuhK2MQEqw7Gm0v5GiPXovl/3pn6zoziQIhAKwH2pfaT+uJHB0OG1vyRSlMNg9syvL6PPjHz9k8DOY1\",\"intermediateSigningKey\":{\"signedKey\":\"{\\\"keyValue\\\":\\\"MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAE6/VAKK0Cd/EjN/EdkEwGPzciAhTST4LiAFLbEvGSn216YMBVobVJZSxaXSzpBW0xuc3cx3QEKxnlTXUnTsbfhw\\\\u003d\\\\u003d\\\",\\\"keyExpiration\\\":\\\"1675316308611\\\"}\",\"signatures\":[\"MEYCIQDvjAJoDWre1RRx+qbX4qK4XqFGD4xENRpwcp0fO6bTBgIhAIQcOPP1LqX/UmYRXcOxPTRj/TGyJN2WNmHaQiwyIjjH\"]},\"protocolVersion\":\"ECv2\",\"signedMessage\":\"{\\\"encryptedMessage\\\":\\\"5tex/0jgKM3pa7Np6FXKR7ESNDjIObbimwdwaxyke5r+9mLXIPBy1k6Ozi6L+1ed+yA+t/ClWbbGM2Edw70jdLwGp3IoPyGuSfHcMBzaflmIMph8wUoBeSyTcWeyHRRC8DueYH6s+O4X1VSZHcio7d5uMWvbnF7XzIqLPTfOrxSz77Y/Se5WDxt+whwTs9BM//nSXm3EecJyjgozeKL2iJBVjyYLJaI4A1IN5LFGu/E1iN6SklmWZBZAATI8CerrpiURzJTU3nQp+rtzuHoBq7EyAZPO3J2Btfrk3Wo06a7EuyPt8KReWe99jShf594EK01qjxAtXJiCSvysmOuv9ps7kT/DEAD0Ds4/rx9Wj4do2aTQPFrygJnx0Fm8dl8tQw7uqMpVzwNbu/Nz0kBX7VHPFddoE7vD0PynVOfA2LW4TZ2+zSswhUKS8P//Gyq1n6SRCRCP4MHa69KiSdKAPQXlB1PM+998KKaU8/aBT1od5aQHz9SL8zL1y/6TBWwjKc8T/GCjtpH3FBSxMmMchkNA0gSivmOQGleCR2vBDyxoxuo+H4jpWuud3kozP18OPvNCygVIY30r\\\",\\\"ephemeralPublicKey\\\":\\\"BFGZrB3qaXWNBBBoMVQ9ggqi+HV1mCE4OfWPD7WgUTpk0bkXvasl4Wi5jrYCtJOkgyOAFqOkUMeWxbc3ZFb32NQ\\\\u003d\\\",\\\"tag\\\":\\\"KZCVUG1HU1ZF26U1kuXfc3ZRXHAWB8EUkUH6NwJBnyA\\\\u003d\\\"}\"}\n";
            var encrytedData = "{\"signature\":\"MEYCIQDCakUiCkI/Jsw5qtC1cl/oSpqJ+gHbheujgiESTnTBUgIhAPNxsDMUdxLzcFEbaWB6TluR3ynOO6tMzHRyLlPX87I7\",\"intermediateSigningKey\":{\"signedKey\":\"{\\\"keyValue\\\":\\\"MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAE5ZJkQXOD7lvagKvzL/oweOQSEUGREsDzdkmnOezeihhrdbyZJx6v0hU7mKXfYdggkyuy3xw39rJGDoYeQcAZhA\\\\u003d\\\\u003d\\\",\\\"keyExpiration\\\":\\\"1675731041334\\\"}\",\"signatures\":[\"MEYCIQCGzHAYx5fyca3DzLSst+Bz+uzEZi7VaEM+EP1SsoUj9gIhAI4uJQjmKC78fxGWRVyrwTV6r11WM4IhlFP441j5+QrS\"]},\"protocolVersion\":\"ECv2\",\"signedMessage\":\"{\\\"encryptedMessage\\\":\\\"BkP9uu1YgTPZ0EgGxp5wubSjgC7tukmf3jfM75uPOpIT0q90BLhAHOHDkN1aE8+RN2nMsIZVXzLCZgwzTDMOUd3a0yUlphjUh31bInumeHkZ2i4oj+PdFLm8jqsT5+priMrVEI1NntTYz+9+85f7TfIZ4+M/UtRhOJmdwvKa7tKxAf4KvXt5lC8FSSHWNCLfcQV88GEwqmaX+KqPk5aTQuQjYb5hqZsnD5xvqaiWjbuNm1PB8npPDOrVkRB1WYUJnNOla2OaR8X0dlsmNj4c/QoaHoz7GMHmc7QmLEryyUgmdNTq4tKirvSoshvCUhEeLlpwMnUWlp10vlZuIt1KdGLEO456V/fC1rOgJ1fU36/TdAHGAOWShdp0Rix5s13OJKSwyWQFWdWogkJ028wjWYyObpzs9bNJ50IZgGChlt9BRKY7v5CEnTpmXFdiF8SYDx/o9fod8s5oG52Hl1kavVfpM7Pqt3sYlthL2oBRfJreTJCrpzLry4EzUs23jflkFxUGDBf1IRkcw2kl+C08H5chOoIcsptgmGzas/omQLVYjetuCwTiAvmPJtaopTIPNi4BgioCV0Sy\\\",\\\"ephemeralPublicKey\\\":\\\"BA0yKJSjViIP4hYz+j+EwSeX4/bkziBUOLp1aCfkKfWNkdHHQ+bSXo2mFhmca5KYjB6G6IL068ECUctv61Vk0Ts\\\\u003d\\\",\\\"tag\\\":\\\"hiaMY5Jtum/G9RqrTLIpvOhbSBmpkNCEPZHEQkqDBXc\\\\u003d\\\"}\"}";
            var base64Data = Base64Encode(encrytedData);
            
            var paymentResponse = 
                await client.CreateGatewayGooglepayPaymentAsync(
                    merchantOrderId,
                requestId,
                10m,
                currency,
                "BUY 0.00001 BTC FOR 10 USD",
                    Base64Encode(encrytedData),
                "https://webhook.site/5f279c4c-e91f-4c3a-906c-8a38cc54e926?success=true", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?success=true", 
                "https://webhook.site/5f279c4c-e91f-4c3a-906c-8a38cc54e926?failure=true", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?failure=true",
                "https://webhook.site/5f279c4c-e91f-4c3a-906c-8a38cc54e926?cancel=true",
                "https://webhook.site/5f279c4c-e91f-4c3a-906c-8a38cc54e926?inproccess=true",
                "https://webhook.site/5f279c4c-e91f-4c3a-906c-8a38cc54e926?return=true",
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
                } //,cancellationToken
            );


            if (!paymentResponse.Success)
            {
                Console.WriteLine(paymentResponse.Message);
            }

            var paymentResponseUrl = paymentResponse.Data.RedirectUrl;

            var paymentInfo = await client.GetPaymentByMerchantOrderIdAsync(
                merchantOrderId, requestId);
        }
        
        public static string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        
        private static async Task TestCardBin(string locale, string currency)
        {
            var terminalcCode = Environment.GetEnvironmentVariable("MyJetWallet-UnlimintSigner-Googlepay-" + currency +"-WalletId");
            var password = Environment.GetEnvironmentVariable("MyJetWallet-UnlimintSigner-Googlepay-" + currency + "-Password");

            var authClient = new UnlimintAuthClient(terminalcCode, password, UnlimintNetwork.Test);
            var client = new UnlimintClient(null, UnlimintNetwork.Test);

            var token = await authClient.GetAuthorizationTokenAsync();
            if (!token.Success || string.IsNullOrEmpty(token.Data?.AccessToken))
            {
                Console.WriteLine(token.Message);
            }

            client.SetAccessToken(token?.Data?.AccessToken);

            //var bin = "535456";
            //var pan = "53545606";
            //var bin = "474503";
            var pan = "47450340";
            
            var bin = "341142";
            var cardResponse = 
                await client.GetCardInfoAsync(new CardBinRequest(){Bin = bin});
            if (!cardResponse.Success)
            {
                Console.WriteLine(cardResponse.Message);
            }

            var card1 = JsonConvert.SerializeObject(cardResponse.Data[0]);
            
            cardResponse = 
                await client.GetCardInfoAsync(new CardBinRequest(){Bin = pan});
            if (!cardResponse.Success)
            {
                Console.WriteLine(cardResponse.Message);
            }
            
            var card2 = JsonConvert.SerializeObject(cardResponse.Data[0]);
        }

        private static async Task TestGetBanksProd(string method, string currency, string country)
        {
            var terminalCode = Environment.GetEnvironmentVariable("UNLIMINT_TERMINAL_CODE_GW_" + currency);
            var password = Environment.GetEnvironmentVariable("UNLIMINT_PASSWORD_GW_" + currency);
            
            var authClient = new UnlimintAuthClient(terminalCode, password);
            var token = await authClient.GetAuthorizationTokenAsync();
            
            if (!token.Success || string.IsNullOrEmpty(token.Data?.AccessToken))
            {
                throw new Exception(token.Message);
            }
            
            var client = new UnlimintClient(token?.Data?.AccessToken);
            
            var banks = await client.GetBanksAsync(method, currency, country);
            
            Console.WriteLine("Banks=" + banks.Data.Banks.Count);
        }
    }
}