using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Cards
{
    public class UpdateCardRequest
    {
        [JsonProperty("keyId")] public string KeyId { get; internal set; }
        [JsonProperty("encryptedData")] public string EncryptedData { get; internal set; }
        [JsonProperty("expMonth")] public int ExpMonth { get; internal set; }
        [JsonProperty("expYear")] public int ExpYear { get; internal set; }
    }
}