using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestCardAccount
{
    [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)] 
    public BillingAddress BillingAddress { get; set; }
    
    [JsonProperty("card", NullValueHandling = NullValueHandling.Ignore)] 
    public PaymentRequestCard Card { get; set; }
    
    [JsonProperty("encrypted_card_data", NullValueHandling = NullValueHandling.Ignore)] 
    public string EncryptedCardData { get; set; }
    
    [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)] 
    public string Token { get; set; }
}