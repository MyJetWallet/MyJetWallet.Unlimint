using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments
{
    public class PaymentRequest
    {
        [JsonProperty("request")] 
        public Request Request { get; set; }
        
        [JsonProperty("card_account", NullValueHandling = NullValueHandling.Ignore)] 
        public PaymentRequestCardAccount CardAccount { get; set; }
        
        [JsonProperty("cryptocurrency_account", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentRequestCryptocurrencyAccount CryptocurrencyAccount { get; set; }
        
        [JsonProperty("customer")] 
        public PaymentRequestCustomer Customer { get; set; }
        
        [JsonProperty("ewallet_account", NullValueHandling = NullValueHandling.Ignore)] 
        public PaymentRequestEWalletAccount EwalletAccount { get; set; }
        
        [JsonProperty("merchant_order")] 
        public PaymentRequestMerchantOrder MerchantOrder { get; set; }
        
        [JsonProperty("payment_data")] 
        public PaymentRequestPaymentData PaymentData { get; set; }
        
        [JsonProperty("payment_method")] 
        public string PaymentMethod { get; set; }
        
        [JsonProperty("payment_methods", NullValueHandling = NullValueHandling.Ignore)] 
        public List<string> PaymentMethods { get; set; }
        
        [JsonProperty("return_urls", NullValueHandling = NullValueHandling.Ignore)] 
        public ReturnUrls ReturnUrls { get; set; }
    }
}