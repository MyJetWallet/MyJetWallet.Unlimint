using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestCardAccount
{
    [JsonProperty("billing_address")] public BillingAddress BillingAddress { get; set; }
    [JsonProperty("card")] public PaymentRequestCard Card { get; set; }
    [JsonProperty("encrypted_card_data")] public string EncryptedCardData { get; set; }
    [JsonProperty("token")] public string Token { get; set; }
}