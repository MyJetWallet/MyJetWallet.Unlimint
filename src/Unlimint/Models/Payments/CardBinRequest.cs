using Destructurama.Attributed;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class CardBinRequest
{
    [LogMasked(ShowFirst = 6, ShowLast = 4, PreserveLength = true)]
    [JsonProperty("bin", NullValueHandling = NullValueHandling.Ignore)]
    public string Bin { get; set; }
}