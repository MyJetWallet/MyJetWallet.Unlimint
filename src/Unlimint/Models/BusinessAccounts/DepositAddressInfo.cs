using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.BusinessAccounts
{
    [DataContract]
    public class DepositAddressInfo
    {
        [DataMember(Order = 1), JsonProperty("address")]
        public string Address { get; set; }

        [DataMember(Order = 2), JsonProperty("addressTag")]
        public string AddressTag { get; set; }

        [DataMember(Order = 3), JsonProperty("currency")]
        public string Currency { get; set; }

        [DataMember(Order = 4), JsonProperty("chain")]
        public string Chain { get; set; }
    }
}
