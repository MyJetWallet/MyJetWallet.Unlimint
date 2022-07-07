using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using MyJetWallet.Unlimint.Converters;

namespace MyJetWallet.Unlimint.Models.Payouts
{
    [DataContract]
    public class PayoutInfo
    {
        [JsonProperty("id"), DataMember(Order = 1)]
        public string Id { get; set; }

        [JsonProperty("sourceWalletId"), DataMember(Order = 2)]
        public string SourceWalletId { get; set; }

        [JsonProperty("createDate"), DataMember(Order = 3)]
        public DateTime CreateDate { get; set; }

        [JsonProperty("updateDate"), DataMember(Order = 4)]
        public DateTime UpdateDate { get; set; }

        [JsonProperty("destination"), DataMember(Order = 5)]
        public PayoutDestination Destination { get; set; }

        [JsonProperty("amount"), DataMember(Order = 6)]
        public CircleAmount Amount { get; set; }

        [JsonProperty("status"), DataMember(Order = 7)]
        [JsonConverter(typeof(PayoutStatusConverter))]
        public PayoutStatus Status { get; set; }

        [JsonProperty("trackingRef"), DataMember(Order = 8)]
        public string TrackingRef { get; set; }

        [JsonProperty("error"), DataMember(Order = 9)]
        [JsonConverter(typeof(PayoutErrorCodeConverter))]
        public PayoutErrorCode? Error { get; set; }

        [JsonProperty("riskEvaluation"), DataMember(Order = 10)]
        public RiskEvaluation RiskEvaluation { get; set; }

        [JsonProperty("adjustments"), DataMember(Order = 11)]
        public PayoutAdjustments Adjustments { get; set; }

        [JsonProperty("fees"), DataMember(Order = 12)]
        public CircleAmount Fees { get; set; }

        [JsonProperty("externalRef"), DataMember(Order = 13)]
        public string ExternalRef { get; set; }

    }
}