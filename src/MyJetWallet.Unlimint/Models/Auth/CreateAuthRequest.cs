using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Auth
{
    public class CreateAuthRequest
    {
        [JsonProperty("grant_type")] public string GrantType { get; set; }
        [JsonProperty("terminal_code")] public string TerminalCode { get; set; }
        [JsonProperty("password")] public string Password { get; set; }
    }
}