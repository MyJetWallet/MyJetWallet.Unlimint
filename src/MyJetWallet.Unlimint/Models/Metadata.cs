﻿using System.Runtime.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace MyJetWallet.Unlimint.Models
{
    [DataContract]
    public class Metadata
    {
        [JsonProperty("email"), DataMember(Order = 1)]
        public string Email { get; set; }

        [JsonProperty("phoneNumber"), DataMember(Order = 2)]
        public string PhoneNumber { get; set; }

        [JsonProperty("sessionId"), DataMember(Order = 3)]
        public string SessionId { get; set; }

        [JsonProperty("ipAddress"), DataMember(Order = 4)]
        public string IpAddress { get; set; }
        
        [JsonProperty("clientId"), DataMember(Order = 5)]
        [CanBeNull]
        public string ClientId { get; set; }
    }
}