using MyJetWallet.Unlimint.Converters;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestPaymentData
{
    [JsonProperty("amount")] 
    public string Amount { get; set; }
    
    // [JsonProperty("authentication_request", NullValueHandling = NullValueHandling.Ignore)]
    // public bool AuthenticationRequest { get; set; }
    
    [JsonProperty("currency")] 
    public string Currency { get; set; }
    
    [JsonProperty("dynamic_descriptor", NullValueHandling = NullValueHandling.Ignore)] 
    public string DynamicDescriptor { get; set; }
    
    [JsonProperty("encrypted_data", NullValueHandling = NullValueHandling.Ignore)] 
    public string EncryptedData { get; set; }
    
    [JsonProperty("generate_token", NullValueHandling = NullValueHandling.Ignore)] 
    public bool GenerateToken { get; set; }

    // [JsonProperty("installment_amount", NullValueHandling = NullValueHandling.Ignore)] 
    // public decimal? InstallmentAmount { get; set; }
    //
    // [JsonProperty("installment_type", NullValueHandling = NullValueHandling.Ignore)] 
    // public string InstallmentType { get; set; }
    //
    // [JsonProperty("installments", NullValueHandling = NullValueHandling.Ignore)] 
    // public int Installments { get; set; }
    
    [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)] 
    public string Note { get; set; }
    
    //[JsonProperty("preauth", NullValueHandling = NullValueHandling.Ignore)] 
    //public bool Preauth { get; set; }
    
    [JsonProperty("three_ds_challenge_indicator", NullValueHandling = NullValueHandling.Ignore)]
    public string ThreeDsChallengeIndicator { get; set; }
    
    [JsonProperty("trans_type", NullValueHandling = NullValueHandling.Ignore)] 
    [JsonConverter(typeof(TransTypeEnumConverter))]
    public TransTypeEnum? TransType { get; set; }
}