using MyJetWallet.Unlimint.Models.Payouts;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments
{
    public class CreateTransferRequest
    {
        [JsonProperty("idempotencyKey")] public string IdempotencyKey { get; set; }
        [JsonProperty("amount")] public CircleAmount Amount { get; set; }

        [JsonProperty("destination")] public CreateTransferDestination Destination { get; set; }
    }
}