using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.Payouts
{
    [DataContract]
    public class PayoutAdjustments
    {
        [JsonProperty("fxCredit"), DataMember(Order = 1)]
        public CircleAmount FxCredit { get; set; }

        [JsonProperty("fxDebit"), DataMember(Order = 2)]
        public CircleAmount FxDebit { get; set; }
    }
}