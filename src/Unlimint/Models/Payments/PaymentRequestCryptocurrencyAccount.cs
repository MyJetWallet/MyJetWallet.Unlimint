using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestCryptocurrencyAccount
{
    [JsonProperty("rollback_address")] public string RollbackAddress { get; set; }
}