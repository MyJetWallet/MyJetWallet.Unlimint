using System.Runtime.Serialization;
using MyJetWallet.Unlimint.Converters;
using MyJetWallet.Unlimint.Models.Payouts;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments
{
    [DataContract]
    public class PaymentInfo
    {
        [JsonProperty("id"), DataMember(Order = 1)]
        public string Id { get; set; }

        [JsonProperty("type"), DataMember(Order = 2)]
        public string Type { get; set; }

        [JsonProperty("merchantId"), DataMember(Order = 3)]
        public string MerchantId { get; set; }

        [JsonProperty("merchantWalletId"), DataMember(Order = 4)]
        public string MerchantWalletId { get; set; }

        [JsonProperty("amount"), DataMember(Order = 5)]
        public CircleAmount Amount { get; set; }

        [JsonProperty("source"), DataMember(Order = 6)]
        public PaymentSource Source { get; set; }

        [JsonProperty("description"), DataMember(Order = 7)]
        public string Description { get; set; }

        [JsonProperty("status"), JsonConverter(typeof(PaymentStatusConverter)), DataMember(Order = 8)]
        public PaymentStatus Status { get; set; }

        [JsonProperty("captured"), DataMember(Order = 9)]
        public bool Captured { get; set; }

        [JsonProperty("captureAmount"), DataMember(Order = 10)]
        public CircleAmount CaptureAmount { get; set; }

        [JsonProperty("captureDate"), DataMember(Order = 11)]
        public string CaptureDate { get; set; }

        [JsonProperty("fees"), DataMember(Order = 12)]
        public CircleAmount Fees { get; set; }

        [JsonProperty("trackingRef"), DataMember(Order = 13)]
        public string TrackingRef { get; set; }

        [JsonProperty("errorCode"), JsonConverter(typeof(PaymentErrorCodeConverter)), DataMember(Order = 14)]
        public PaymentErrorCode? ErrorCode { get; set; }

        [JsonProperty("metadata"), DataMember(Order = 15)]
        public Metadata Metadata { get; set; }

        [JsonProperty("riskEvaluation"), DataMember(Order = 16)]
        public RiskEvaluation RiskEvaluation { get; set; }

        [JsonProperty("createDate"), DataMember(Order = 17)]
        public string CreateDate { get; set; }

        [JsonProperty("updateDate"), DataMember(Order = 18)]
        public string UpdateDate { get; set; }

        [JsonProperty("transactionHash"), DataMember(Order = 19)]
        public string TransactionHash { get; set; }

        [JsonProperty("destination"), DataMember(Order = 20)]
        public PaymentDestination Destination { get; set; }

        [JsonProperty("requiredAction", NullValueHandling = NullValueHandling.Ignore), DataMember(Order = 21)]
        public RequiredAction RequiredAction { get; set; }
    }
}