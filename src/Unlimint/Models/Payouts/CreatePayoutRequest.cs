using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payouts
{
    public class CreatePayoutRequest
    {
        [JsonProperty("idempotencyKey")] public string IdempotencyKey { get; set; }
        [JsonProperty("metadata")] public PayoutMetadata Metadata { get; set; }
        [JsonProperty("amount")] public CircleAmount Amount { get; set; }
        [JsonProperty("source")] public PayoutSource Source { get; set; }
        [JsonProperty("destination")] public PayoutDestination Destination { get; set; }
    }
}