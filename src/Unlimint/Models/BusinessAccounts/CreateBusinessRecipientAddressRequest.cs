using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments
{
    public class CreateBusinessRecipientAddressRequest
    {
        [JsonProperty("idempotencyKey")] public string IdempotencyKey { get; set; }

        [JsonProperty("currency")] public string Currency { get; set; }

        [JsonProperty("chain")] public string Chain { get; set; }

        [JsonProperty("address")] public string Address { get; set; }

        [JsonProperty("addressTag")] public string AddressTag { get; set; }

        [JsonProperty("description")] public string Description { get; set; }
    }
    
}