using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestCard
{
    [JsonProperty("acct_type", NullValueHandling = NullValueHandling.Ignore)] 
    [JsonConverter(typeof(Converters.AcctTypeEnumConverter))]
    public AcctTypeEnum AcctType { get; set; }
    
    [JsonProperty("expiration", NullValueHandling = NullValueHandling.Ignore)] 
    public string Expiration { get; set; }
    
    [JsonProperty("holder", NullValueHandling = NullValueHandling.Ignore)] 
    public string Holder { get; set; }
    
    [JsonProperty("pan", NullValueHandling = NullValueHandling.Ignore)] 
    public string Pan { get; set; }
    
    [JsonProperty("pin_code", NullValueHandling = NullValueHandling.Ignore)] 
    public string PinCode { get; set; }
    
    [JsonProperty("security_code", NullValueHandling = NullValueHandling.Ignore)] 
    public string SecurityCode { get; set; }
}