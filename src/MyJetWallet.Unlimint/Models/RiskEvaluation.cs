using Newtonsoft.Json;
using System.Runtime.Serialization;
using MyJetWallet.Unlimint.Converters;

namespace MyJetWallet.Unlimint.Models
{
    [DataContract]
    public class RiskEvaluation
    {
        [JsonProperty("decision"), DataMember(Order = 1)]
        [JsonConverter(typeof(RiskEvaluationTypeConverter))]
        public RiskEvaluationType Decision { get; set; }

        [JsonProperty("reason"), DataMember(Order = 2)]
        public string Reason { get; set; }
    }
}