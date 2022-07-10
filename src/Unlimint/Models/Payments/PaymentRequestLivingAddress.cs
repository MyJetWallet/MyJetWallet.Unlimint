using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestLivingAddress
{
    [JsonProperty("address")]
    public string Address { get; set; }
    [JsonProperty("city")]
    public string City { get; set; }
    [JsonProperty("country")]
    public string Country { get; set; }
    [JsonProperty("state")]
    public string State { get; set; }
    [JsonProperty("zip")]
    public string Zip { get; set; }
}