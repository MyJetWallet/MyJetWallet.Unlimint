using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.WireTransfers
{
    [DataContract]
    public class BankWireTransferDetailBeneficiaryBank
    {
        [JsonProperty("name"), DataMember(Order = 1)]
        public string Name { get; set; }

        [JsonProperty("swiftCode"), DataMember(Order = 2)]
        public string SwiftCode { get; set; }

        [JsonProperty("routingNumber"), DataMember(Order = 3)]
        public string RoutingNumber { get; set; }

        [JsonProperty("accountNumber"), DataMember(Order = 4)]
        public string AccountNumber { get; set; }

        [JsonProperty("address"), DataMember(Order = 5)]
        public string Address { get; set; }

        [JsonProperty("city"), DataMember(Order = 6)]
        public string City { get; set; }

        [JsonProperty("postalCode"), DataMember(Order = 7)]
        public string PostalCode { get; set; }

        [JsonProperty("country"), DataMember(Order = 8)]
        public string Country { get; set; }
    }
}
