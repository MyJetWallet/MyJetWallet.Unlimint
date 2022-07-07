using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payouts
{
    [DataContract]
    public class PayoutDestination
    {
        [JsonProperty("type"), DataMember(Order = 1)]
        public string Type { get; set; }

        [JsonProperty("id"), DataMember(Order = 2)]
        public string Id { get; set; }
    }
}