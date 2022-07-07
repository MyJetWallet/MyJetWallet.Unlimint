using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Transfers;
[DataContract]
public class Address
{
    [JsonProperty("line1"), DataMember(Order = 1)]
    public string Line1 { get; set; }

    [JsonProperty("line2"), DataMember(Order = 2)]
    public string Line2 { get; set; }

    [JsonProperty("city"), DataMember(Order = 3)]
    public string City { get; set; }
        
    [JsonProperty("district"), DataMember(Order = 4)]
    public string District { get; set; }
        
    [JsonProperty("country"), DataMember(Order = 5)]
    public string Country { get; set; }
        
    [JsonProperty("postalCode"), DataMember(Order = 6)]
    public string PostalCode { get; set; }
}