using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

[DataContract]
public class PaymentDataResponse
{
    [JsonProperty("data"), DataMember(Order = 1)]
    public PaymentResponse[] Payments { get; set; }
}