using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

[DataContract]
public class PaymentGatewayResponsePaymentData 
{
    [JsonProperty("id"), DataMember(Order = 1)]
    public string Id  { get; set; }
    
    [JsonProperty("separate_auth"), DataMember(Order = 2)]
    public bool SeparateAuth { get; set; }
}