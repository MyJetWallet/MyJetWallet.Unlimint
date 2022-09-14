using Destructurama.Attributed;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestCard
{
    [JsonProperty("acct_type", NullValueHandling = NullValueHandling.Ignore)] 
    [JsonConverter(typeof(Converters.AcctTypeEnumConverter))]
    public AcctTypeEnum AcctType { get; set; }
    
    [JsonProperty("expiration", NullValueHandling = NullValueHandling.Ignore)] 
    public string Expiration { get; set; }
    
    [LogMasked(ShowFirst = 1, ShowLast = 1, PreserveLength = true)]
    [JsonProperty("holder", NullValueHandling = NullValueHandling.Ignore)] 
    public string Holder { get; set; }
    
    [LogMasked(ShowFirst = 6, ShowLast = 4, PreserveLength = true)]
    [JsonProperty("pan", NullValueHandling = NullValueHandling.Ignore)] 
    public string Pan { get; set; }
    
    [LogMasked(PreserveLength = true)]
    [JsonProperty("pin_code", NullValueHandling = NullValueHandling.Ignore)] 
    public string PinCode { get; set; }
    
    [LogMasked(PreserveLength = true)]
    [JsonProperty("security_code", NullValueHandling = NullValueHandling.Ignore)] 
    public string SecurityCode { get; set; }
}