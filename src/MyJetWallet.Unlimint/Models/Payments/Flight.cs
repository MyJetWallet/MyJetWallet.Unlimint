using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class Flight
{
    [JsonProperty("carrier_code")]
    public string CarrierCode { get; set; }
    [JsonProperty("destination_code")]
    public string DestinationCode { get; set; }
    [JsonProperty("fare_basis_code")]
    public string FareBasisCode { get; set; }
    [JsonProperty("index")]
    public int Index { get; set; }
    [JsonProperty("number")]
    public string Number { get; set; }
    [JsonProperty("service_class_code")]
    public int ServiceClassCode { get; set; }
    [JsonProperty("stop_over_code")]
    public string StopOverCode { get; set; }
}