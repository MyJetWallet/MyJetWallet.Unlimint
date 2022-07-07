using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.WireTransfers
{
    [DataContract]
    public class BankWireTransferDetailBeneficiary
    {
        [JsonProperty("name"), DataMember(Order = 1)]
        public string Name { get; set; }

        [JsonProperty("address1"), DataMember(Order = 2)]
        public string Address1 { get; set; }

        [JsonProperty("address2"), DataMember(Order = 3)]
        public string Address2 { get; set; }

    }
}
