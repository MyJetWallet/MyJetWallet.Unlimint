#nullable enable
using System.Runtime.Serialization;
using MyJetWallet.Unlimint.Converters;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.BusinessAccounts
{
    [DataContract]
    public class ConfigurationInfo
    {
        [JsonProperty("payments"), DataMember(Order = 1)]
        public ConfigurationPaymentsInfo Payments { get; set; }
    }
}