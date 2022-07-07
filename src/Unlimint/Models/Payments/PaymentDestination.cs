using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments
{
    [DataContract]
    public class PaymentDestination
    {
        [JsonProperty("type"), DataMember(Order = 1)]
        public string Type { get; set; }

        [JsonProperty("address"), DataMember(Order = 2)]
        public string Address { get; set; }

        [JsonProperty("addressTag"), DataMember(Order = 3)]
        public string AddressTag { get; set; }

        [JsonProperty("chain"), DataMember(Order = 4)]
        public string Chain { get; set; }
    }
}