using System.Runtime.Serialization;
using MyJetWallet.Unlimint.Enums;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

[DataContract]
public class DisputeInfoRequest
{
    [DataMember(Order = 1)]
    [JsonProperty("max_count")]
    public int MaxCount { get; set; }

    [DataMember(Order = 2)]
    [JsonProperty("offset")]
    public int Offset { get; set; }

    [DataMember(Order = 3)]
    [JsonProperty("reg_end_time")]
    public string RegistrationEndTime { get; set; }

    [DataMember(Order = 4)]
    [JsonProperty("reg_start_time")]
    public string RegistrationStartTime { get; set; }

    [DataMember(Order = 5)]
    [JsonProperty("sort_order")]
    public string SortOrder { get; set; }

    [DataMember(Order = 6)]
    [JsonProperty("request_id")]
    public string RequestId { get; set; }

    [DataMember(Order = 7)]
    [JsonProperty("type")]
    public DisputeType Type { get; set; }
}


