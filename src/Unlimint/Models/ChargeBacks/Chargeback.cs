using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Converters;

namespace MyJetWallet.Unlimint.Models.ChargeBacks
{
    [DataContract]
    public class Chargeback
    {
        [DataMember(Order = 1), JsonProperty("id")]
        public string Id { get; set; }

        [DataMember(Order = 2), JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [DataMember(Order = 3), JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        [DataMember(Order = 4), JsonProperty("history")]
        public ChargebackHistory[] History { get; set; }

        [DataMember(Order = 5), JsonProperty("reasonCode")]
        public string ReasonCode { get; set; }

        [DataMember(Order = 6), JsonProperty("category")]
        [JsonConverter(typeof(ChargeBackCategoryConverter))]
        public ChargeBackCategory Category { get; set; }

    }
}
