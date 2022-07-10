using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments
{
    [DataContract]
    public class PaymentResponse
    {
        [JsonProperty("redirect_url"), DataMember(Order = 1)]
        public string RedirectUrl { get; set; }
    }
}