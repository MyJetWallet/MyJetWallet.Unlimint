using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payouts
{
    [DataContract]
    public class PayoutSource
    {
        [JsonProperty("id"), DataMember(Order = 1)]
        public string Id { get; set; }

        [JsonProperty("type"), DataMember(Order = 2)]
        public string Type { get; set; }

    }
}