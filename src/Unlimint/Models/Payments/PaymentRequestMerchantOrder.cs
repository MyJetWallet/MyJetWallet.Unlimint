using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestMerchantOrder
{
    [JsonProperty("cryptocurrency_indicator")]
    public bool CryptocurrencyIndicator { get; set; }

    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("flights")] public Flights Flights { get; set; }
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("items")] public List<Item> Items { get; set; }
    [JsonProperty("shipping_address")] public ShippingAddress ShippingAddress { get; set; }
}