using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.Payouts
{
    [DataContract]
    public class PayoutMetadata
    {

        [JsonProperty("beneficiaryEmail"), DataMember(Order = 1)]
        public string BeneficiaryEmail { get; set; }
    }
}