using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestCustomer
{
    [JsonProperty("birth_date", NullValueHandling = NullValueHandling.Ignore)] public string BirthDate { get; set; }
    [JsonProperty("document_type", NullValueHandling = NullValueHandling.Ignore)] public string DocumentType { get; set; }
    [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)] public string Email { get; set; }
    [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)] public string FirstName { get; set; }
    [JsonProperty("full_name", NullValueHandling = NullValueHandling.Ignore)] public string FullName { get; set; }
    [JsonProperty("home_phone", NullValueHandling = NullValueHandling.Ignore)] public string HomePhone { get; set; }
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)] public string Id { get; set; }
    [JsonProperty("identity", NullValueHandling = NullValueHandling.Ignore)] public string Identity { get; set; }
    [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)] public string LastName { get; set; }
    [JsonProperty("living_address", NullValueHandling = NullValueHandling.Ignore)] public PaymentRequestLivingAddress LivingAddress { get; set; }
    [JsonProperty("locale", NullValueHandling = NullValueHandling.Ignore)] public string Locale { get; set; }
    [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)] public string Phone { get; set; }
    [JsonProperty("work_phone", NullValueHandling = NullValueHandling.Ignore)] public string WorkPhone { get; set; }
    [JsonProperty("ip", NullValueHandling = NullValueHandling.Ignore)] public string Ip { get; set; }
}