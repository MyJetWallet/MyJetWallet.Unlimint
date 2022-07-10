using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestCard
{
    [JsonProperty("acct_type")] public AcctTypeEnum AcctType { get; set; }
    [JsonProperty("expiration")] public string Expiration { get; set; }
    [JsonProperty("holder")] public string Holder { get; set; }
    [JsonProperty("pan")] public string Pan { get; set; }
    [JsonProperty("pin_code")] public string PinCode { get; set; }
    [JsonProperty("security_code")] public string SecurityCode { get; set; }
}