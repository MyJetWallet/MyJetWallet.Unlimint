using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments
{
    [DataContract]
    public class RequiredAction
    {
        [JsonProperty("type"), DataMember(Order = 1)]
        public string Type { get; set; }

        [JsonProperty("redirect_url"), DataMember(Order = 2)]
        public string RedirectUrl { get; set; }
    }
}