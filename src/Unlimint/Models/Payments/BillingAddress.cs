using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class BillingAddress
{
    [JsonProperty("addr_line_1")] public string AddrLine1 { get; set; }
    [JsonProperty("addr_line_2")] public string AddrLine2 { get; set; }
    [JsonProperty("city")] public string City { get; set; }
    [JsonProperty("country")] public string Country { get; set; }
    [JsonProperty("state")] public string State { get; set; }
    [JsonProperty("zip")] public string Zip { get; set; }
}