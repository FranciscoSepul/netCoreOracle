using System;
using System.Text.Json.Serialization;

namespace BackSecurity.Dto.Authentication
{
    public class TokenResponse
    {

        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("exception")]
        public string Exception { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("isCanceled")]
        public bool IsCanceled { get; set; }

        [JsonPropertyName("isCompleted")]
        public bool IsCompleted { get; set; }

        [JsonPropertyName("isCompletedSuccessfully")]
        public bool IsCompletedSuccess { get; set; }

        [JsonPropertyName("creationOptions")]
        public int CreationOptions { get; set; }

        [JsonPropertyName("asyncState")]
        public string AsyncState { get; set; }

        [JsonPropertyName("isFaulted")]
        public string IsFaulted { get; set; }

        public TokenResponse()
        {
        }
    }

    public class AuthResponse
    {

        [JsonPropertyName("token")]
        public TokenResponse Token { get; set; }

        public AuthResponse()
        {
        }
    }
}

