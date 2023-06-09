using System.Collections.Generic;
using MyJetWallet.Unlimint.Base;
using MyJetWallet.Unlimint.Models;

namespace MyJetWallet.Unlimint.Converters
{
    public class RiskEvaluationTypeConverter : BaseConverter<RiskEvaluationType>
    {
        public RiskEvaluationTypeConverter() : this(true)
        {
        }

        public RiskEvaluationTypeConverter(bool quotes) : base(quotes)
        {
        }

        protected override List<KeyValuePair<RiskEvaluationType, string>> Mapping => new()
        {
            new KeyValuePair<RiskEvaluationType, string>(RiskEvaluationType.Approved, "approved"),
            new KeyValuePair<RiskEvaluationType, string>(RiskEvaluationType.Denied, "denied"),
            new KeyValuePair<RiskEvaluationType, string>(RiskEvaluationType.Review, "review"),
           
        };
    }
}