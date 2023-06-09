using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestEWalletAccount
{
    [JsonProperty("bank_code")] public string BankCode { get; set; }
    [JsonProperty("creation_date")] public string CreationDate { get; set; }
    [JsonProperty("expiration_date")] public string ExpirationDate { get; set; }
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("verification_code")] public string VerificationCode { get; set; }
}