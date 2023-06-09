using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class TransactionResponseEWalletAccount
{
    [JsonProperty("holder")] private string Holder { get; set; }
    [JsonProperty("id")] private string Id { get; set; }
}