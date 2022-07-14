using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestMerchantOrder
{
    // [JsonProperty("cryptocurrency_indicator", NullValueHandling = NullValueHandling.Ignore)]
    // public bool CryptocurrencyIndicator { get; set; }

    [JsonProperty("description")] 
    public string Description { get; set; }
    
    [JsonProperty("flights", NullValueHandling = NullValueHandling.Ignore)] 
    public Flights Flights { get; set; }
    
    [JsonProperty("id")] 
    public string Id { get; set; }
    
    [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)] 
    public List<Item> Items { get; set; }
    
    [JsonProperty("shipping_address", NullValueHandling = NullValueHandling.Ignore)] 
    public ShippingAddress ShippingAddress { get; set; }
}