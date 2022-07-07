#nullable enable
using System;
using System.Runtime.Serialization;
using MyJetWallet.Unlimint.Converters;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Cards
{
    [DataContract]
    public class CardInfo
    {
        [JsonProperty("id"), DataMember(Order = 1)]
        public string Id { get; internal set; }

        [JsonProperty("status"), JsonConverter(typeof(CardStatusConverter)), DataMember(Order = 2)]
        public CardStatus Status { get; internal set; }

        [JsonProperty("billingDetails"), DataMember(Order = 3)]
        public CardBillingDetails BillingDetails { get; internal set; }

        [JsonProperty("expMonth"), DataMember(Order = 4)]
        public int ExpMonth { get; internal set; }

        [JsonProperty("expYear"), DataMember(Order = 5)]
        public int ExpYear { get; internal set; }

        [JsonProperty("network"), DataMember(Order = 6)]
        public string Network { get; internal set; }

        [JsonProperty("last4"), DataMember(Order = 7)]
        public string Last4 { get; internal set; }

        [JsonProperty("bin"), DataMember(Order = 8)]
        public string Bin { get; internal set; }

        [JsonProperty("issuerCountry"), DataMember(Order = 9)]
        public string IssuerCountry { get; internal set; }

        [JsonProperty("fundingType"), JsonConverter(typeof(CardFundingTypeConverter)), DataMember(Order = 10)]
        public CardFundingType FundingType { get; internal set; }

        [JsonProperty("fingerprint"), DataMember(Order = 11)]
        public string Fingerprint { get; internal set; }

        [JsonProperty("errorCode"), JsonConverter(typeof(CardVerificationErrorConverter)), DataMember(Order = 12)]
        public CardVerificationError? ErrorCode { get; internal set; }

        [JsonProperty("verification"), DataMember(Order = 13)]
        public CardVerification Verification { get; internal set; }

        [JsonProperty("riskEvaluation"), DataMember(Order = 14)]
        public RiskEvaluation RiskEvaluation { get; internal set; }

        [JsonProperty("metadata"), DataMember(Order = 15)]
        public Metadata Metadata { get; internal set; }

        [JsonProperty("createDate"), DataMember(Order = 16)]
        public DateTime CreateDate { get; internal set; }

        [JsonProperty("updateDate"), DataMember(Order = 17)]
        public DateTime UpdateDate { get; internal set; }
    }
}