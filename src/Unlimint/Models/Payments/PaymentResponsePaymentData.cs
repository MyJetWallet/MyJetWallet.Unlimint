using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

[DataContract]
public class PaymentResponsePaymentData
{
    [JsonProperty("action_code"), DataMember(Order = 1)]
    public string ActionCode  { get; set; }
    [JsonProperty("amount"), DataMember(Order = 2)]
    public decimal Amount  { get; set; }
    [JsonProperty("arn"), DataMember(Order = 3)]
    public string Arn  { get; set; }
    [JsonProperty("auth_code"), DataMember(Order = 4)]
    public string AuthCode  { get; set; }
    [JsonProperty("created"), DataMember(Order = 5)]
    public string Created  { get; set; }
    [JsonProperty("currency"), DataMember(Order = 6)]
    public string Currency  { get; set; }
    [JsonProperty("decline_code"), DataMember(Order = 7)]
    public string DeclineCode  { get; set; }
    [JsonProperty("decline_reason"), DataMember(Order = 8)]
    public string DeclineReason  { get; set; }
    [JsonProperty("extended_data"), DataMember(Order = 9)]
    public Dictionary<string, string> ExtendedData  { get; set; }
    [JsonProperty("id"), DataMember(Order = 10)]
    public string Id  { get; set; }
    [JsonProperty("installment_type"), DataMember(Order = 11)]
    public string InstallmentType  { get; set; }
    [JsonProperty("installments"), DataMember(Order = 12)]
    public string Installments  { get; set; }
    [JsonProperty("invalid_data"), DataMember(Order = 13)]
    public List<string> InvalidData  { get; set; }
    [JsonProperty("is_3d"), DataMember(Order = 14)]
    public bool Is3d  { get; set; }
    [JsonProperty("note"), DataMember(Order = 15)]
    public string Note  { get; set; }
    [JsonProperty("rrn"), DataMember(Order = 16)]
    public string Rrn  { get; set; }
}