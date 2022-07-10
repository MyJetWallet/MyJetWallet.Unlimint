using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Auth
{
    public class AuthToken
    {
        [JsonProperty("token_type")] public string TokenType { get; internal set; }
        [JsonProperty("access_token")] public string AccessToken { get; internal set; }
        [JsonProperty("refresh_token")] public string RefreshToken { get; internal set; }
        [JsonProperty("expires_in")] public long ExpiresIn { get; internal set; }
        [JsonProperty("refresh_expires_in")] public long RefreshExpiresIn { get; internal set; }
    }
}