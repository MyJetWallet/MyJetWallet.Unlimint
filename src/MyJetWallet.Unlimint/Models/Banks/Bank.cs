using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Banks;

public class Bank
{
    [JsonProperty("bank_code")]
    public string BankCode { get; set; }
    
    [JsonProperty("bank_name")]
    public string BankName { get; set; }
    
    [JsonProperty("country")]
    public string Country { get; set; }
    
    [JsonProperty("required_customer_iban")]
    public bool RequiredCustomerIban  { get; set; }
}