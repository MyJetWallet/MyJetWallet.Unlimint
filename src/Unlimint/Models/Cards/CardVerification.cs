using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Cards
{
    [DataContract]
    public class CardVerification
    {
        [JsonProperty("avs"), DataMember(Order = 1)]
        public string Avs { get; internal set; }

        [JsonProperty("cvv"), DataMember(Order = 2)]
        public string Cvv { get; internal set; }
    }
}