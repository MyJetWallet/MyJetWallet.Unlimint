using System;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class Request
{
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("time")] public DateTime Time { get; set; }
}