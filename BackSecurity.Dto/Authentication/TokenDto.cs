using System;
using Newtonsoft.Json;

namespace BackSecurity.Dto.Authentication
{
    public class TokenDto
    {
        public string AccessToken { get; set; }

        public DateTime Expire { get; set; }

        public string RefreshToken { get; set; }

        public string Username { get; set; }

        public string Fullname { get; set; }

        public TokenDto()
        {
        }
    }

    public class TokenDeviceDto : TokenDto
    {
        public int DeviceId { get; set; }

        public string Identifier { get; set; }

        public string AccessSecret { get; set; }
    }
}

