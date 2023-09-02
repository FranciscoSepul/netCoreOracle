using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.User
{
    public class TokenDTO
    {
        public string Token { get; set; }

        public DateTime TokenExpiration { get; set; }

        public string Nombre { get; set; }

        public string RefreshToken { get; set; }
    }
}