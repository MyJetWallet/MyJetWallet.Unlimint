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
            //await TestCardBin("UA");
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

            await TestAlternativeMethod("en", "BRL");
            //await TestAlternativeMethod("es", "BRL");
            //await TestAlternativeMethod("it", "BRL");
            //await TestAlternativeMethod("ru", "BRL");
            //
            //await TestAlternativeMethod("es", "MXN");
            //await TestAlternativeMethod("it", "MXN");
            //await TestAlternativeMethod("en", "MXN");
            //
            // await TestAlternativeMethod("es", "COP");
            // await TestAlternativeMethod("it", "COP");
            //await TestAlternativeMethod("en", "COP");

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
        }

        private static async Task TestPublicKey()
        {
            var key = await _authClient.GetAuthorizationTokenAsync();
            Console.WriteLine(JsonSerializer.Serialize(key, new JsonSerializerOptions()
            {
                WriteIndented = true
            }));
        }


        private static async Task TestAlternativeMethod(string locale, string currency)
        {
            var terminalcCode = Environment.GetEnvironmentVariable("UNLIMINT_TERMINAL_CODE_" + currency);
            var password = Environment.GetEnvironmentVariable("UNLIMINT_PASSWORD_" + currency);

            var authClient = new UnlimintAuthClient(terminalcCode, password, UnlimintNetwork.Main);
            var client = new UnlimintClient(null, UnlimintNetwork.Main);

            var token = await authClient.GetAuthorizationTokenAsync();
            if (!token.Success || string.IsNullOrEmpty(token.Data?.AccessToken))
            {
                Console.WriteLine(token.Message);
            }

            client.SetAccessToken(token?.Data?.AccessToken);

            var requestId = Guid.NewGuid().ToString();
            var merchantOrderId = Guid.NewGuid().ToString();

            var paymentAlternativeResponse = await client.CreateAlternativePaymentAsync(
                "boleto",//"boleto",//"walmart",//,"7eleven",//"picpay",//"pix",//,"boleto",//"oxxo",
                merchantOrderId,
                requestId,
                10m,
                currency,
                true,
                "Simple.app order description",
                "https://webhook.site/995b283f-12e9-4aee-86c5-4e499a95c5ad?success=true", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?success=true", 
                "https://webhook.site/995b283f-12e9-4aee-86c5-4e499a95c5ad?failure=true", //https://webhook.site/6b936147-bee8-4468-86f2-c885af1735b3?failure=true",
                "https://webhook.site/995b283f-12e9-4aee-86c5-4e499a95c5ad?cancel=true",
                "https://webhook.site/995b283f-12e9-4aee-86c5-4e499a95c5ad?inproccess=true",
                "https://webhook.site/995b283f-12e9-4aee-86c5-4e499a95c5ad?return=true",
                DateTime.UtcNow,
                new PaymentRequestCustomer
                {
                    BirthDate = DateTime.UtcNow.AddYears(-33).ToString("yyyy-MM-dd"),
                    DocumentType = null,
                    Email = "yuriy.test.2022.07.15.001@gmail.com",
                    FirstName = "Yuriy",
                    FullName = "Yuriy Test",
                    //HomePhone = null,
                    Id = "5e1c37e3230144a48ccb13b9662fc491",
                    Identity = "625.258.535-12",
                    LastName = "Test",
                    LivingAddress = new PaymentRequestLivingAddress()
                    {
                        Address =  "Avenida Buritis Area Institucional",
                        City = "Parauapebas",
                        Country = "BR",
                        State = "State of Para",
                        Zip = "68515-000"
                    },
                    Locale = locale,
                    Phone = "+359885989618",
                    //WorkPhone = null,
                    Ip = "123.123.123.123"
                },
                new ShippingAddress
                {
                    AddrLine1 =  "Avenida Buritis Area Institucional",
                    AddrLine2 = "Lt. 01 e 02, 336 - Cidade Jardim",
                    City = "Parauapebas",
                    Country = "BR",
                    Phone = null, 
                    State = "State of Para",
                    Zip = "68515-000"
                }
                //,cancellationToken
                
            );


            if (!paymentAlternativeResponse.Success)
            {
                Console.WriteLine(paymentAlternativeResponse.Message);
            }

            var paymentAlternativeResponseUrl = paymentAlternativeResponse.Data.RedirectUrl;

            var paymentAlternativeInfo = await client.GetPaymentByMerchantOrderIdAsync(
                merchantOrderId, requestId);
        }


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
            var encrytedData = "{\"signature\":\"MEQCIEO0T092Z9oEJ0+V2CQZFWQJm1z36+2uWvVqSNId6gQ5AiAu2YJxJwU24f0YDgc4a3wiuYInLKuflGpdv0wy7LdRfQ\\u003d\\u003d\",\"intermediateSigningKey\":{\"signedKey\":\"{\\\"keyValue\\\":\\\"MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAENPkHqn2gv0uf0f5qn+aYln3B6/1Cbk1LAjpATRiWA3YubH367LsjQeyNPmkcVU8BT6zYeTz7cpJfDqLC1z9PuA\\\\u003d\\\\u003d\\\",\\\"keyExpiration\\\":\\\"1678212392159\\\"}\",\"signatures\":[\"MEYCIQD3HUpdfagS2qPmdkQPgWM7GC2D+gGrz/6xRNbgBUKG+wIhAI6Gnll8lJZqrw7E4opn0f3w/tsi41ofnmbw9Lr26G0q\"]},\"protocolVersion\":\"ECv2\",\"signedMessage\":\"{\\\"encryptedMessage\\\":\\\"dG2jHa19p0OAhsbmUxd4BEGmrTBTJvYpVDnsy1gBIDG4gOGHgkbwM1IKsCIDKXX+zlg5yKlK7ckws2BrEirXFxDHawCWtLo4lb74KpuKtRK4OuZ24JC4slmJQ+vqh/WDSnAhIiSLe8zE6WXAGdfJlge90S8bBZaZDvrCQcyKDRTEzFEOsXL0Jx5hx0P18GoWuAo7gsBuKktXgULTaOQ4jtSy4dnChdGPFdS/g6uPyQgziDtmxE4/0VQui4DQ7mAdXIvDkq1qIj2Pt43Arm41Pb72YEXxixEc2DQD5afQuZ8H2m4MTupsp7665VwSjdWFCAXzWu3L44gxBayiiNGs1eLMi1yaAN612UPoBzTULPuged0w+tPduCMiL+71FrxtKxM+p8oHv7RJC54fMATWCracSuDQzq53oFuGR5VwWGKbyRZqjcNtmYgMa6hPhXUdT+j3l3wvilm3J7JDsLFNrbAaMVhyK4wAcKjCb0HlXPTAGnvMLJbSyVW2i8N/VlDscA3/8XqaldhGHE1KDKW6RPngSY4grd7s+HY1V5hRCeo9/AiotxZQ6fC4OINwxA//WMwAu3WnPSnM\\\",\\\"ephemeralPublicKey\\\":\\\"BHklJAVVlg0rKz61c3jO2iNe7BZv38JBuTIwQcx6PNtgdcLlIZ8QrySGClEErelGb7PJd4RcBU/UOmMvxl0TJRc\\\\u003d\\\",\\\"tag\\\":\\\"cYQvK4FW69WfVh/FbnoQbAOWCIeSZf598bfyronPXrI\\\\u003d\\\"}\"}";
            var base64Data = Base64Encode(encrytedData);
            //var base64Data = "eyJzaWduYXR1cmUiOiJNRVlDSVFDTzFiaktkZkR2cWpzMzA2Zi9aOERTZjB3QlloUkM4R2g2VHc3R3VrQ3pEQUloQUp0elNLRVdMcTRHcG5oakNiaXV1UDgzWVMwNHBZdWFWZW84OGxlWXArcW8iLCJpbnRlcm1lZGlhdGVTaWduaW5nS2V5Ijp7InNpZ25lZEtleSI6IntcImtleVZhbHVlXCI6XCJNRmt3RXdZSEtvWkl6ajBDQVFZSUtvWkl6ajBEQVFjRFFnQUVNNW5ReGI4UFEvSXR4S3VFRzFZNUVNSnRMcnp3UFYxRE9wa04yaXl5N25ab3pHcWxuUXBYS2dnMzRxbDRnY01vUEUzMm5Kc2FFWjNFMndicDNvcU9MQVxcdTAwM2RcXHUwMDNkXCIsXCJrZXlFeHBpcmF0aW9uXCI6XCIxNjc4MTIxMTEzMDY3XCJ9Iiwic2lnbmF0dXJlcyI6WyJNRVVDSVFEOTVLdkRlZFg4MmZHWXFLeWFSYkFjRmdHMlkzQ29FZjdwc0xKdVhJNXRiUUlnVEVQRUVXWlhSUXVmci93clk3bit6cnV5Mm1wWUdLTEFndUpCU0diS0NtRVx1MDAzZCJdfSwicHJvdG9jb2xWZXJzaW9uIjoiRUN2MiIsInNpZ25lZE1lc3NhZ2UiOiJ7XCJlbmNyeXB0ZWRNZXNzYWdlXCI6XCJVUFBRUjhVaFBaV2xjNUZDRFZxZUo3Nnc3M2ZaRGwyUmJySWFDM3VuRmR5SU5LMG13UkxsU3FERk5kdERCaEk0Z0txKyt6ZU43VFZRaTIzSjJ1ZDZkRXZrYzlKdHFhWVdvVDNpRmQ4NmJta1RyVGJsMEJUbjk3QnA1M3VjVGtESzNOZ1dtVDVidDlYNXgxVHhCdzZUaVk1em5taWdKM25DRnBDb2lPTXhZUGo0Tm1XWk9KZkYzdStINE9XOGpLMG1DOUNwOXE3bzVVY2NYc0UrcGdVaVA3ZjZhbFV6aWdhZE1SUDZtdFpQK3JhUk9nbjBOUXRkNHNXcHcxZXVpU3BrQldVRjZmczlOZUFHZFdYQWRmR1lDeFNrQWJiNnRHVlJpOXNLcW5zUjZEQktrV2VpL0lBQ2JwTmN4RTBOYkFxaDNya2hVUndVWjQ1L1p3N2ExNGZsNWNkTEtxRjBwbHY3eEp2R05sNEVidGFGdXJVdFVwZVVybU5tT2xjcU9VUi9WekZNNFpFeDhPT3NUU1ZxekpKSXBzU1JHRnZZUTV5dTNrcnJWVTRGWHE0eFJveGZTTThsdWVwZUxCSDlGQllsc2k2N1VLQ0JnaThJUVBFUDlZNktWdGhIYlVRcStFS0tabHFxdkxjMmJORHlHY0p5ek5pSG9ialhLT2o1VlU3ZmMrRHluaEN4U0ZXZGF1aDNEc1huOXN3Y0E2ZXZBMkQxYTNub00yS1plQk5qVzhCVEJ1R29yWWtNZ28rMSsyUFcxL0gvSjRUNG9lUy9cIixcImVwaGVtZXJhbFB1YmxpY0tleVwiOlwiQkl1SnhacVd6em02L2hhNzFmbXZaSGJ4UWlvQk5YVFF2MHF6SDRra1dZRUJ2cTlQYm5BTGRMZnVIeGNnVUZqVnNMRHRKUmxMN1g1T3M5bmNoNkdoWlgwXFx1MDAzZFwiLFwidGFnXCI6XCJQVWQxeGxMNFQ3UXdnMFJzbmFMM0NJU1NZN0w4SmtrbzdDYWRsU0JiL2lzXFx1MDAzZFwifSJ9=";
            var paymentResponse = 
                await client.CreateGatewayGooglepayPaymentAsync(
                    merchantOrderId,
                    requestId,
                1m,
                    currency,
                "non 3DS",
                    base64Data,
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
                    //Identity = "Test",
                    LastName = "Test",
                    Locale = locale,
                    Phone = "+359885989618",
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
            var terminalcCode = Environment.GetEnvironmentVariable("MyJetWallet-UnlimintSigner-Visa-" + currency +"-WalletId");
            var password = Environment.GetEnvironmentVariable("MyJetWallet-UnlimintSigner-Visa-" + currency + "-Password");

            var authClient = new UnlimintAuthClient(terminalcCode, password, UnlimintNetwork.Main);
            var client = new UnlimintClient(null, UnlimintNetwork.Main);

            var token = await authClient.GetAuthorizationTokenAsync();
            if (!token.Success || string.IsNullOrEmpty(token.Data?.AccessToken))
            {
                Console.WriteLine(token.Message);
            }

            client.SetAccessToken(token?.Data?.AccessToken);

            var bin = "53754188";
            var pan = "53545606";
            //var bin = "474503";
            //var pan = "47450340";
            
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
    }
}