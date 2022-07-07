using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Cards
{
    [DataContract]
    public class CardBillingDetails
    {
        [JsonProperty("name"), DataMember(Order = 1)]
        public string Name { get; internal set; }

        [JsonProperty("city"), DataMember(Order = 2)]
        public string City { get; internal set; }

        [JsonProperty("country"), DataMember(Order = 3)]
        public string Country { get; internal set; }

        [JsonProperty("line1"), DataMember(Order = 4)]
        public string Line1 { get; internal set; }

        [JsonProperty("line2"), DataMember(Order = 5)]
        public string Line2 { get; internal set; }

        [JsonProperty("district"), DataMember(Order = 6)]
        public string District { get; internal set; }

        [JsonProperty("postalCode"), DataMember(Order = 7)]
        public string PostalCode { get; internal set; }
    }
}