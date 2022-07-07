using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.BusinessAccounts
{
    [DataContract]
    public class TransferSource
    {

        [JsonProperty("type"), DataMember(Order = 1)]
        public string Type { get; set; }

        [JsonProperty("chain"), DataMember(Order = 2)]
        public string Chain { get; set; }

        [JsonProperty("id"), DataMember(Order = 3)]
        public string Id { get; set; }
    }
}