using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestLivingAddress
{
    [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
    public string Address { get; set; }
    [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
    public string City { get; set; }
    [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
    public string Country { get; set; }
    [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
    public string State { get; set; }
    [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
    public string Zip { get; set; }
}