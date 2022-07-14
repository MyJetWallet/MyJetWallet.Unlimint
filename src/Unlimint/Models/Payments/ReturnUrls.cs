using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class ReturnUrls
{
    [JsonProperty("cancel_url", NullValueHandling = NullValueHandling.Ignore)] 
    public string CancelUrl { get; set; }
    
    [JsonProperty("decline_url", NullValueHandling = NullValueHandling.Ignore)] 
    public string DeclineUrl { get; set; }
    
    [JsonProperty("inprocess_url", NullValueHandling = NullValueHandling.Ignore)] 
    public string InprocessUrl { get; set; }
    
    [JsonProperty("return_url", NullValueHandling = NullValueHandling.Ignore)] 
    public string ReturnUrl { get; set; }
    
    [JsonProperty("success_url", NullValueHandling = NullValueHandling.Ignore)] 
    public string SuccessUrl { get; set; }
}