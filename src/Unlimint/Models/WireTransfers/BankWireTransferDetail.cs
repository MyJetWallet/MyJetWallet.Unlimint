using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace MyJetWallet.Unlimint.Models.WireTransfers
{
    /*
     {
  "data":{
    "trackingRef":"CIR2JYD6WT",
    "beneficiary":{
      "name":"CIRCLE INTERNET",
      "address1":"1 MAIN STREET",
      "address2":"SUITE 1"
    },
    "beneficiaryBank":{
      "name":"CRYPTO BANK",
      "swiftCode":"CRYPTO99",
      "routingNumber":"999999999",
      "accountNumber":"1000000001",
      "address":"1 MONEY STREET",
      "city":"NEW YORK",
      "postalCode":"10001",
      "country":"US"
    }
  }
}
     */
    [DataContract]
    public class BankWireTransferDetail
    {
        [JsonProperty("trackingRef"), DataMember(Order = 1)]
        public string TrackingRef { get; set; }

        [JsonProperty("beneficiary"), DataMember(Order = 2)]
        public BankWireTransferDetailBeneficiary Beneficiary { get; set; }

        [JsonProperty("beneficiaryBank"), DataMember(Order = 3)]
        public BankWireTransferDetailBeneficiaryBank BeneficiaryBank { get; set; }
    }
}
