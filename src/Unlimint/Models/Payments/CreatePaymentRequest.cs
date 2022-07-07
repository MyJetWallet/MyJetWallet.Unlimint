using MyJetWallet.Unlimint.Models.Payouts;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments
{
    public class CreatePaymentRequest
    {
        [JsonProperty("idempotencyKey")] public string IdempotencyKey { get; set; }
        [JsonProperty("keyId")] public string KeyId { get; set; }
        [JsonProperty("metadata")] public Metadata Metadata { get; set; }
        [JsonProperty("amount")] public CircleAmount Amount { get; set; }
        [JsonProperty("autoCapture")] public bool AutoCapture { get; set; }
        [JsonProperty("verification")] public string Verification { get; set; }

        [JsonProperty("verificationSuccessUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string VerificationSuccessUrl { get; set; }

        [JsonProperty("verificationFailureUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string VerificationFailureUrl { get; set; }

        [JsonProperty("source")] public PaymentSource Source { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("encryptedData")] public string EncryptedData { get; set; }
    }
}