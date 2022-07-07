using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments
{
    [DataContract]
    public class PaymentSource
    {
        [JsonProperty("id"), DataMember(Order = 1)]
        public string Id { get; set; }

        [JsonProperty("type"), DataMember(Order = 2)]
        public string Type { get; set; }

        [JsonProperty("chain"), DataMember(Order = 3)]
        public string Chain { get; set; }
    }
}