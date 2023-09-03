using BackSecurity.Dto.User;
using BackSecurity.Services.IServices;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackSecurity.Services.Common.ICommon;
using BackSecurity.Dto.Authentication;
using AppTrabajadores.Dto.Authentication;
using BackSecurity.Services.Common;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace BackSecurity.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;

        public UserService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string Login(string user, string pass)
        {
            Console.WriteLine("here "+user+" "+pass);
            if (user == "admin" && pass == "admin")
            {
                Console.WriteLine("generar ");
                return GenerarToken(user, pass,1);;
            }
            return null;

        }

       
        public string GenerarToken(string user, string pass, int account)
        {
            JwtSecurityToken jwtToken = new 
                        (null,
                        null,
                        CreateClaims(user, account),
                        null,
                        expires: DateTime.Now.AddDays(1).ToLocalTime());
            string token = new JwtSecurityTokenHandler()
                        .WriteToken(jwtToken);
            return token;
        }
        private List<Claim> CreateClaims(string user, int account)
        {
            List<Claim> claims = new()
            {
                new Claim("usuario", user),
                new Claim("account", account.ToString())
            };
            return claims;
        }
        public bool  Create(User user){
            return false;
        }
    }
}
