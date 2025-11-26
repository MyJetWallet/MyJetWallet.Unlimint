using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Banks;

[DataContract]
public class BanksResponse
{
    [JsonProperty("bank_list")]
    public List<Bank> Banks { get; set; }
}