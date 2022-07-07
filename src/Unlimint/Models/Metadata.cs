using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models
{
    [DataContract]
    public class Metadata
    {
        [JsonProperty("email"), DataMember(Order = 1)]
        public string Email { get; internal set; }

        [JsonProperty("phoneNumber"), DataMember(Order = 2)]
        public string PhoneNumber { get; internal set; }

        [JsonProperty("sessionId"), DataMember(Order = 3)]
        public string SessionId { get; internal set; }

        [JsonProperty("ipAddress"), DataMember(Order = 4)]
        public string IpAddress { get; internal set; }
    }
}