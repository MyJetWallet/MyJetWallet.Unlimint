using Destructurama.Attributed;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class CardBinRequest
{
    [JsonProperty("bin", NullValueHandling = NullValueHandling.Ignore)]
    public string Bin { get; set; }
}