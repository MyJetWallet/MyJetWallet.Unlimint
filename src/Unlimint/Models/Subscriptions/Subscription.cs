using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Subscriptions
{
    [DataContract]
    public class Subscription
    {
        [JsonProperty("id"), DataMember(Order = 1)]
        public string Id { get; internal set; }

        [JsonProperty("endpoint"), DataMember(Order = 2)]
        public string Endpoint { get; internal set; }

        [JsonProperty("subscriptionDetails"), DataMember(Order = 3)]
        public SubscriptionDetails[] Details { get; internal set; }
    }
}