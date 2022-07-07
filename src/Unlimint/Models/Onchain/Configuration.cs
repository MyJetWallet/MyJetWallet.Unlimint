using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Onchain
{
    [DataContract]
    public class Configuration
    {
        [JsonProperty("payments"), DataMember(Order = 1)]
        public PaymentsConfiguration PaymentsConfiguration { get; internal set; }
    }
}