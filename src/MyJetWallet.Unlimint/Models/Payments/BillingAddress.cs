using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class BillingAddress
{
    [JsonProperty("addr_line_1", NullValueHandling = NullValueHandling.Ignore)]
    public string AddrLine1 { get; set; }
    [JsonProperty("addr_line_2", NullValueHandling = NullValueHandling.Ignore)] 
    public string AddrLine2 { get; set; }
    [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)] 
    public string City { get; set; }
    [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)] 
    public string Country { get; set; }
    [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)] 
    public string State { get; set; }
    [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)] 
    public string Zip { get; set; }
}