using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.WireTransfers
{
    [DataContract]
    public class BankAddress
    {
        [JsonProperty("bankName", NullValueHandling = NullValueHandling.Ignore), DataMember(Order = 1)]
        public string BankName { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore), DataMember(Order = 2)]
        public string City { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore), DataMember(Order = 3)]
        public string Country { get; set; }

        [JsonProperty("line1", NullValueHandling = NullValueHandling.Ignore), DataMember(Order = 4)]
        public string Line1 { get; set; }

        [JsonProperty("line2", NullValueHandling = NullValueHandling.Ignore), DataMember(Order = 5)]
        public string Line2 { get; set; }

        [JsonProperty("district", NullValueHandling = NullValueHandling.Ignore), DataMember(Order = 6)]
        public string District { get; set; }
    }
}
