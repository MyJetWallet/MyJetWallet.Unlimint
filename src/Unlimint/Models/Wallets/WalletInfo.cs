using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MyJetWallet.Unlimint.Models.Payouts;

namespace MyJetWallet.Unlimint.Models.Wallets
{
    [DataContract]
    public class WalletInfo
    {
        [DataMember(Order =1), JsonProperty("walletId")]
        public string WalletId { get; set; }

        [DataMember(Order = 2), JsonProperty("entityId")]
        public string EntityId { get; set; }

        [DataMember(Order = 3), JsonProperty("type")]
        public string Type { get; set; }

        [DataMember(Order = 4), JsonProperty("balances")]
        public CircleAmount[] Balances { get; set; }
    }
}
