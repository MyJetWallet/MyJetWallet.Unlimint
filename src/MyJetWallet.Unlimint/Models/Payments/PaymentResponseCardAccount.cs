using System.Runtime.Serialization;
using MyJetWallet.Unlimint.Converters;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

[DataContract]
public class PaymentResponseCardAccount
{
    [JsonProperty("acct_type"), DataMember(Order = 1)]
    [JsonConverter(typeof(AcctTypeEnumConverter))]
    public AcctTypeEnum AcctType { get; set; }
    
    [JsonProperty("expiration"), DataMember(Order = 2)]
    public string Expiration { get; set; }
    
    [JsonProperty("holder"), DataMember(Order = 3)]
    public string Holder { get; set; }
    
    [JsonProperty("issuing_country_code"), DataMember(Order = 4)]
    public string IssuingCountryCode { get; set; }
    
    [JsonProperty("masked_pan"), DataMember(Order = 5)]
    public string MaskedPan { get; set; }
    
    [JsonProperty("token"), DataMember(Order = 6)]
    public string Token { get; set; }
}