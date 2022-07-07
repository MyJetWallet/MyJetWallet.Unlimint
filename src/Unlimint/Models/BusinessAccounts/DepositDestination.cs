using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.BusinessAccounts
{
    [DataContract]
    public class DepositDestination
    {
        [JsonProperty("id"), DataMember(Order = 1)]
        public string Id { get; set; }

        [JsonProperty("type"), DataMember(Order = 2)]
        public string Type { get; set; }
    }
}
