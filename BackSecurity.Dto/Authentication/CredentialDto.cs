using Newtonsoft.Json;
using UAParser;

namespace BackSecurity.Dto.Authentication
{
    public class CredentialCommonAuth
    {
        [JsonProperty("user", Required = Required.DisallowNull)]
        public string User { get; set; }

        [JsonProperty("pass", Required = Required.DisallowNull)]
        public string Pass { get; set; }
    }


    public class CredentialDto
    {
        [JsonProperty("username", Required = Required.DisallowNull)]
        public string Username { get; set; }

        [JsonProperty("password", Required = Required.DisallowNull)]
        public string Password { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        private ClientInfo _clientInfo;

        public void SetAgent(string userAgent)
        {
            Parser parser = Parser.GetDefault();
            _clientInfo = parser.Parse(userAgent);
        }

        public string GetSystem()
        {
            return _clientInfo?.OS?.Family?? "UNKNOWN";
        }

        public string GetModel()
        {
            return _clientInfo?.Device?.Family?? "UNKNOWN";
        }

        public CredentialDto()
        {
        }

        public CredentialCommonAuth ToCommonAuth()
        {
            return new CredentialCommonAuth()
            {
                User = this.Username,
                Pass = this.Password
            };
        }
    }
}

