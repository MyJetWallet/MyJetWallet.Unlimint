using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Onchain
{
    [DataContract]
    public class BlockchainAddress
    {
        [JsonProperty("address"), DataMember(Order = 1)]
        public string Address { get; internal set; }

        [JsonProperty("addressTag"), DataMember(Order = 2)]
        public string AddressTag { get; internal set; }

        [JsonProperty("currency"), DataMember(Order = 3)]
        public string Currency { get; internal set; }

        [JsonProperty("chain"), DataMember(Order = 3)]
        public string Chain { get; internal set; }
    }
}