using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models.Auth
{
    [DataContract]
    public class AuthToken
    {
        [JsonProperty("token_type"), DataMember(Order = 1)] 
        public string TokenType { get; set; }
        
        [JsonProperty("access_token"), DataMember(Order = 2)] 
        public string AccessToken { get; set; }
        
        [JsonProperty("refresh_token"), DataMember(Order = 3)] 
        public string RefreshToken { get; set; }
        
        [JsonProperty("expires_in"), DataMember(Order = 4)] 
        public long ExpiresIn { get; set; }
        
        [JsonProperty("refresh_expires_in"), DataMember(Order = 5)] 
        public long RefreshExpiresIn { get; set; }
    }
}