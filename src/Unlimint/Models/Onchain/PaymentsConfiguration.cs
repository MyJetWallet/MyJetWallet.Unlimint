using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Onchain
{
    [DataContract]
    public class PaymentsConfiguration
    {
        [JsonProperty("masterWalletId"), DataMember(Order = 1)]
        public string MasterWalletId { get; internal set; }
    }
}