using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments
{
    [DataContract]
    public class PaymentGatewayCreationResponse
    {
        [JsonProperty("redirect_url"), DataMember(Order = 1)]
        public string RedirectUrl { get; set; }
        
        [JsonProperty("payment_data", NullValueHandling = NullValueHandling.Ignore), DataMember(Order = 2)]
        public PaymentGatewayResponsePaymentData PaymentData { get; set; }
    }
}
    