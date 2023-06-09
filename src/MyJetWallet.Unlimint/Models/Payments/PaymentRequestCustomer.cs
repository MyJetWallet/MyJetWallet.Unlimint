using Destructurama.Attributed;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestCustomer
{
    [JsonProperty("birth_date", NullValueHandling = NullValueHandling.Ignore)] public string BirthDate { get; set; }
    [JsonProperty("document_type", NullValueHandling = NullValueHandling.Ignore)] public string DocumentType { get; set; }
    [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)] public string Email { get; set; }
    
    [LogMasked(ShowFirst = 1, ShowLast = 1, PreserveLength = true)]
    [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)] public string FirstName { get; set; }
    
    [LogMasked(ShowFirst = 1, ShowLast = 1, PreserveLength = true)]
    [JsonProperty("full_name", NullValueHandling = NullValueHandling.Ignore)] public string FullName { get; set; }
    [JsonProperty("home_phone", NullValueHandling = NullValueHandling.Ignore)] public string HomePhone { get; set; }
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)] public string Id { get; set; }
    [JsonProperty("identity", NullValueHandling = NullValueHandling.Ignore)] public string Identity { get; set; }
    [LogMasked(ShowFirst = 1, ShowLast = 1, PreserveLength = true)]
    [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)] public string LastName { get; set; }
    [JsonProperty("living_address", NullValueHandling = NullValueHandling.Ignore)] public PaymentRequestLivingAddress LivingAddress { get; set; }
    [JsonProperty("locale", NullValueHandling = NullValueHandling.Ignore)] public string Locale { get; set; }
    [LogMasked(ShowFirst = 3, ShowLast = 3, PreserveLength = true)]
    [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)] public string Phone { get; set; }
    [LogMasked(ShowFirst = 3, ShowLast = 3, PreserveLength = true)]
    [JsonProperty("work_phone", NullValueHandling = NullValueHandling.Ignore)] public string WorkPhone { get; set; }
    [JsonProperty("ip", NullValueHandling = NullValueHandling.Ignore)] public string Ip { get; set; }
}