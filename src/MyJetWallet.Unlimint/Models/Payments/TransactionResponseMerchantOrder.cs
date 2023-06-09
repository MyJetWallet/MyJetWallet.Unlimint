using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

[DataContract]
public class TransactionResponseMerchantOrder
{
    [JsonProperty("id"), DataMember(Order = 1)]
    public string Id { get; set; }
}