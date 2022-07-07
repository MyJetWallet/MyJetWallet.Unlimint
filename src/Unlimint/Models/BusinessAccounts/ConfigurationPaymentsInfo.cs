#nullable enable
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.BusinessAccounts
{
    [DataContract]
    public class ConfigurationPaymentsInfo
    {
        [JsonProperty("masterWalletId"), DataMember(Order = 1)]
        public string MasterWalletId { get; set; }
    }
}