using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class EWalletAccountData
{
    [JsonProperty("bank_code")] 
    public string BankCode { get; set; }
}