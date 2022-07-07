using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.BusinessAccounts
{
    [DataContract]
    public class RecipientAddressInfo
    {
        [DataMember(Order = 1), JsonProperty("address")]
        public string Address { get; set; }

        [DataMember(Order = 2), JsonProperty("addressTag")]
        public string AddressTag { get; set; }

        [DataMember(Order = 3), JsonProperty("currency")]
        public string Currency { get; set; }

        [DataMember(Order = 4), JsonProperty("chain")]
        public string Chain { get; set; }

        [DataMember(Order = 5), JsonProperty("id")]
        public string Id{ get; set; }

        [DataMember(Order = 6), JsonProperty("description")]
        public string Description { get; set; }
    }
}
