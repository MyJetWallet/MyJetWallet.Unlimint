using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payouts
{
    [DataContract]
    public class CircleAmount
    {
        [JsonProperty("amount"), DataMember(Order = 1)]
        public string Amount { get; set; }

        [JsonProperty("currency"), DataMember(Order = 2)]
        public string Currency { get; set; }
    }
}