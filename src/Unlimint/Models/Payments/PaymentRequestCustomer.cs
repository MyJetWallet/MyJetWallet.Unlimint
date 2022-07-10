using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Payments;

public class PaymentRequestCustomer
{
    [JsonProperty("birth_date")] public string BirthDate { get; set; }
    [JsonProperty("document_type")] public string DocumentType { get; set; }
    [JsonProperty("email")] public string Email { get; set; }
    [JsonProperty("first_name")] public string FirstName { get; set; }
    [JsonProperty("full_name")] public string FullName { get; set; }
    [JsonProperty("home_phone")] public string HomePhone { get; set; }
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("identity")] public string Identity { get; set; }
    [JsonProperty("last_name")] public string LastName { get; set; }
    [JsonProperty("living_address")] public PaymentRequestLivingAddress LivingAddress { get; set; }
    [JsonProperty("locale")] public string Locale { get; set; }
    [JsonProperty("phone")] public string Phone { get; set; }
    [JsonProperty("work_phone")] public string WorkPhone { get; set; }
    [JsonProperty("ip")] public string Ip { get; set; }
}