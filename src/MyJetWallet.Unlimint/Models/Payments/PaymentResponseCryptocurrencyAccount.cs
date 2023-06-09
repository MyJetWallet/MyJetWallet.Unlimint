using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentResponseCryptocurrencyAccount
{
    [JsonProperty("crypto_address")] private string CryptoAddress { get; set; }

    [JsonProperty("crypto_transaction_id")]
    private string CryptoTransactionId { get; set; }

    [JsonProperty("prc_amount")] private decimal PrcAmount { get; set; }
    [JsonProperty("prc_currency")] private string PrcCurrency { get; set; }
}