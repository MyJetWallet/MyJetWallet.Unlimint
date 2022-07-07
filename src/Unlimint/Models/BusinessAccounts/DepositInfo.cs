using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using MyJetWallet.Unlimint.Converters;

namespace MyJetWallet.Unlimint.Models.BusinessAccounts
{
    [DataContract]
    public class DepositInfo
    {
        [DataMember(Order = 1), JsonProperty("id")]
        public string Id { get; set; }

        [DataMember(Order = 2), JsonProperty("riskEvaluation")]
        public RiskEvaluation RiskEvaluation { get; set; }

        [DataMember(Order = 3), JsonProperty("destination")]
        public DepositDestination Destination { get; set; }

        [DataMember(Order = 4), JsonProperty("amount")]
        public Payouts.CircleAmount Amount { get; set; }

        [DataMember(Order = 5), JsonProperty("fee")]
        public Payouts.CircleAmount Fee { get; set; }

        [DataMember(Order = 6), JsonProperty("status")]
        [JsonConverter(typeof(DepositStatusConverter))]
        public DepositStatus Status { get; set; }

        [DataMember(Order = 7), JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        [DataMember(Order = 8), JsonProperty("updateDate")]
        public DateTime UpdateDate { get; set; }

    }
}
