using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

[DataContract] 
public class PaymentResponse
{
    [JsonProperty("customer"), DataMember(Order = 1)]
    public PaymentRequestCustomer Customer { get; set; }
        
    [JsonProperty("payment_method"), DataMember(Order = 2)]
    public string PaymentMethod { get; set; }
        
    [JsonProperty("merchant_order"), DataMember(Order = 3)]
    public TransactionResponseMerchantOrder MerchantOrder { get; set; }
        
    [JsonProperty("payment_data"), DataMember(Order = 4)]
    public PaymentResponsePaymentData PaymentData { get; set; }
        
    [JsonProperty("card_account"), DataMember(Order = 5)]
    public PaymentResponseCardAccount CardAccount { get; set; }
}