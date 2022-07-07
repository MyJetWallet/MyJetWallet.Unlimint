using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.WireTransfers
{
    [DataContract]
    public class BankAccountInfo
    {
        [JsonProperty("id"), DataMember(Order = 1)]
        public string Id { get; set; }

        [JsonProperty("status"), DataMember(Order = 2)]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public BankAccountStatus Status { get; set; }

        [JsonProperty("description"), DataMember(Order = 3)]
        public string Description { get; set; }

        [JsonProperty("trackingRef"), DataMember(Order = 4)]
        public string TrackingRef { get; set; }

        [JsonProperty("fingerprint"), DataMember(Order = 5)]
        public string Fingerprint { get; set; }

        [JsonProperty("billingDetails"), DataMember(Order = 6)]
        public BillingDetails BillingDetails { get; set; }

        [JsonProperty("bankAddress"), DataMember(Order = 7)]
        public BankAddress BankAddress { get; set; }

        [JsonProperty("createDate"), DataMember(Order = 8)]
        public DateTimeOffset CreateDate { get; set; }

        [JsonProperty("updateDate"), DataMember(Order = 9)]
        public DateTimeOffset UpdateDate { get; set; }

    }
}
