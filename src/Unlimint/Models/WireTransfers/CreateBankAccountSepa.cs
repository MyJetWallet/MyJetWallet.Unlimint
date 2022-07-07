using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.WireTransfers
{
    [DataContract]
    public class CreateBankAccountSepa
    {
        [JsonProperty("idempotencyKey"), DataMember(Order = 1)]
        public string IdempotencyKey { get; set; }

        [JsonProperty("iban"), DataMember(Order = 2)]
        public string Iban { get; set; }

        [JsonProperty("billingDetails"), DataMember(Order = 3)]
        public BillingDetails BillingDetails { get; set; }

        [JsonProperty("bankAddress"), DataMember(Order = 4)]
        public BankAddress BankAddress { get; set; }
    }
}
