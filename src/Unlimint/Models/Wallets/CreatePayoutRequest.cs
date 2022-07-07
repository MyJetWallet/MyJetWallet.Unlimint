using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Wallets
{
    public class CreateWalletRequest
    {
        [JsonProperty("idempotencyKey")] public string IdempotencyKey { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
    }
}