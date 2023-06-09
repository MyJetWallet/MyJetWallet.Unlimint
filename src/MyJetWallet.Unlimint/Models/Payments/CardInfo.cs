using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

[DataContract]
public class CardInfo
{
    [JsonProperty("bin"), DataMember(Order = 1)]
    public string Bin { get; set; }
    [JsonProperty("card_brand"), DataMember(Order = 2)]
    public string CardBrand { get; set; }
    [JsonProperty("card_issuer"), DataMember(Order = 3)]
    public string CardIssuer { get; set; }
    [JsonProperty("card_type"), DataMember(Order = 4)]
    public string CardType { get; set; }
    [JsonProperty("country"), DataMember(Order = 5)]
    public string Country { get; set; }
}