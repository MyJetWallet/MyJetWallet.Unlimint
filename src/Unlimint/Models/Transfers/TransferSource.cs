using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Transfers
{
    [DataContract]
    public class TransferSource
    {
        [JsonProperty("identities"), DataMember(Order = 1)]
        public TransferIdentity[] Identities { get; set; }

        [JsonProperty("type"), DataMember(Order = 2)]
        public string Type { get; set; }

        [JsonProperty("chain"), DataMember(Order = 3)]
        public string Chain { get; set; }

        [JsonProperty("id"), DataMember(Order = 4)]
        public string Id { get; set; }
    }
}