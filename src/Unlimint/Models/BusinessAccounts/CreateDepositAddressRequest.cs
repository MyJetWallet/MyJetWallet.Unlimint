using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments
{
    public class CreateDepositAddressRequest
    {
        [JsonProperty("idempotencyKey")] public string IdempotencyKey { get; set; }
        [JsonProperty("currency")] public string Currency { get; set; }
        [JsonProperty("chain")] public string Chain { get; set; }
    }
    
}