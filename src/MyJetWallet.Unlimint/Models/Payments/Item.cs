using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class Item
{
    [JsonProperty("count")]
    public int Count { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("price")]
    public decimal Price { get; set; }
}