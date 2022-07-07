using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Subscriptions
{
    [DataContract]
    public class SubscriptionDetails
    {
        [JsonProperty("url"), DataMember(Order = 1)]
        public string Url { get; internal set; }

        [JsonProperty("status"), DataMember(Order = 2)]
        public string Status { get; internal set; }
    }
}