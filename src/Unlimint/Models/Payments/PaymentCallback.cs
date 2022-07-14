using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments
{
    public class PaymentCallback
    {
        [JsonProperty("callback_time", NullValueHandling = NullValueHandling.Ignore)]
        public string CallbackTime { get; set; }

        [JsonProperty("card_account", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentResponseCardAccount CardAccount { get; set; }

        [JsonProperty("cryptocurrency_account", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentResponseCryptocurrencyAccount CryptocurrencyAccount { get; set; }

        [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentRequestCustomer Customer { get; set; }

        [JsonProperty("ewallet_account", NullValueHandling = NullValueHandling.Ignore)]
        public TransactionResponseEWalletAccount EwalletAccount { get; set; }

        [JsonProperty("merchant_order", NullValueHandling = NullValueHandling.Ignore)]
        public TransactionResponseMerchantOrder MerchantOrder { get; set; }

        [JsonProperty("payment_data", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentResponsePaymentData PaymentData { get; set; }

        [JsonProperty("payment_method", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentMethod { get; set; }
    }
}