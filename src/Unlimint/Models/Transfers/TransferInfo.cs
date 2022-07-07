using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Converters;
using MyJetWallet.Unlimint.Models.Payouts;

namespace MyJetWallet.Unlimint.Models.Transfers
{
    [DataContract]
    public class TransferInfo
    {
        [DataMember(Order = 1), JsonProperty("id")]
        public string Id { get; set; }

        [DataMember(Order = 2), JsonProperty("source")]
        public TransferSource Source { get; set; }

        [DataMember(Order = 3), JsonProperty("destination")]
        public TransferDestination Destination { get; set; }

        [DataMember(Order = 4), JsonProperty("amount")]
        public CircleAmount Amount { get; set; }

        [DataMember(Order = 5), JsonProperty("transactionHash")]
        public string TransactionHash { get; set; }

        [DataMember(Order = 6), JsonProperty("status")]
        [JsonConverter(typeof(TransferStatusConverter))]
        public TransferStatus Status { get; set; }

        [DataMember(Order = 6), JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        [DataMember(Order = 7), JsonProperty("errorCode")]
        [JsonConverter(typeof(TransferErrorCodeConverter))]
        public TransferErrorCode? errorCode { get; set; }

    }
}
