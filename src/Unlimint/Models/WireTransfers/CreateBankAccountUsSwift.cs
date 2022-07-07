using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.WireTransfers
{
    [DataContract]
    public class CreateBankAccountUsSwift
    {
        [JsonProperty("idempotencyKey"), DataMember(Order = 1)]
        public string IdempotencyKey { get; set; }

        [JsonProperty("accountNumber"), DataMember(Order = 2)]
        public string AccountNumber { get; set; }

        [JsonProperty("routingNumber"), DataMember(Order = 3)]
        public string RoutingNumber { get; set; }

        [JsonProperty("billingDetails"), DataMember(Order = 4)]
        public BillingDetails BillingDetails { get; set; }

        [JsonProperty("bankAddress"), DataMember(Order = 5)]
        public BankAddress BankAddress { get; set; }
    }
}
