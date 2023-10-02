using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

[DataContract]
public class DisputeInfos
{
    [DataMember(Order = 1)]
    [JsonProperty("data")]
    public DisputeInfo Data { get; set; }
    
    [DataMember(Order = 2)]
    [JsonProperty("has_more")]
    public bool HasMore { get; set; }
}

[DataContract]
public class DisputeInfo
{
    [DataMember(Order = 1)]
    [JsonProperty("card_account")]
    public DisputeResponseCardAccount CardAccount { get; set; }

    [DataMember(Order = 2)]
    [JsonProperty("customer")]
    public DisputeResponseCustomer Customer { get; set; }

    [DataMember(Order = 3)]
    [JsonProperty("dispute_data")]
    public DisputeResponseDisputeData DisputeData { get; set; }

    [DataMember(Order = 4)]
    [JsonProperty("merchant_order")]
    public DisputeResponseMerchantOrder MerchantOrder { get; set; }

    [DataMember(Order = 5)]
    [JsonProperty("payment_data")]
    public DisputeResponsePaymentData PaymentData { get; set; }
}

[DataContract]
public class DisputeResponseCardAccount
{
    [DataMember(Order = 1)]
    [JsonProperty("card")]
    public DisputeResponseCard Card { get; set; }
}

[DataContract]
public class DisputeResponseCard
{
    [DataMember(Order = 1)]
    [JsonProperty("card_brand")]
    public string CardBrand { get; set; }

    [DataMember(Order = 2)]
    [JsonProperty("masked_pan")]
    public string MaskedPan { get; set; }
}

[DataContract]
public class DisputeResponseCustomer
{
    [DataMember(Order = 1)]
    [JsonProperty("email")]
    public string Email { get; set; }
}

[DataContract]
public class DisputeResponseDisputeData
{
    [DataMember(Order = 1)]
    [JsonProperty("due_time")]
    public string DueTime { get; set; }

    [DataMember(Order = 2)]
    [JsonProperty("group_id")]
    public string GroupId { get; set; }

    [DataMember(Order = 3)]
    [JsonProperty("reason_code")]
    public string ReasonCode { get; set; }

    [DataMember(Order = 4)]
    [JsonProperty("reason_description")]
    public string ReasonDescription { get; set; }

    [DataMember(Order = 5)]
    [JsonProperty("reg_time")]
    public string RegTime { get; set; }

    [DataMember(Order = 6)]
    [JsonProperty("result_time")]
    public string ResultTime { get; set; }

    [DataMember(Order = 7)]
    [JsonProperty("stage")]
    public string Stage { get; set; }

    [DataMember(Order = 8)]
    [JsonProperty("status")]
    public string Status { get; set; }

    [DataMember(Order = 9)]
    [JsonProperty("type")]
    public string Type { get; set; }
}

[DataContract]
public class DisputeResponseMerchantOrder
{
    [DataMember(Order = 1)]
    [JsonProperty("id")]
    public string Id { get; set; }

    [DataMember(Order = 2)]
    [JsonProperty("website_url")]
    public string WebsiteUrl { get; set; }
}

[DataContract]
public class DisputeResponsePaymentData
{
    [DataMember(Order = 1)]
    [JsonProperty("amount")]
    public string Amount { get; set; }

    [DataMember(Order = 2)]
    [JsonProperty("arn")]
    public string Arn { get; set; }

    [DataMember(Order = 3)]
    [JsonProperty("auth_code")]
    public string AuthCode { get; set; }

    [DataMember(Order = 4)]
    [JsonProperty("created")]
    public string Created { get; set; }

    [DataMember(Order = 5)]
    [JsonProperty("currency")]
    public string Currency { get; set; }

    [DataMember(Order = 6)]
    [JsonProperty("id")]
    public string Id { get; set; }
}
