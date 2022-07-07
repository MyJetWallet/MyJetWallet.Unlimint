using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Transfers
{
    [DataContract]
    public class TransferDestination
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore), DataMember(Order = 1)]
        public string Id{ get; set; }

        [JsonProperty("type"), DataMember(Order = 2)]
        public string Type { get; set; }

        [JsonProperty("address"), DataMember(Order = 3)]
        public string Address { get; set; }

        [JsonProperty("addressTag"), DataMember(Order = 4)]
        public string AddressTag { get; set; }

        [JsonProperty("chain"), DataMember(Order = 5)]
        public string Chain { get; set; }
    }
}