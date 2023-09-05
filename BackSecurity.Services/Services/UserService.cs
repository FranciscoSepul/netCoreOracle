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
using System.Net.Http;

namespace BackSecurity.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly IHttpService _httpService;
        public string getAllUsers = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/usuario";

        public UserService(IConfiguration configuration, IHttpService httpService)
        {
            _config = configuration;
            _httpService = httpService;
        }

        public string Login(string user, string pass)
        {
            Console.WriteLine("here " + user + " " + pass);

            if (user == "admin" && pass == "admin")
            {
                Console.WriteLine("generar ");
                return GenerarToken(user, pass, 1); ;
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
        private static List<Claim> CreateClaims(string user, int account)
        {
            List<Claim> claims = new()
            {
                new Claim("usuario", user),
                new Claim("account", account.ToString())
            };
            return claims;
        }
        public bool Create(User user)
        {
            return false;
        }

        public Root Users()
        {
            try
            {
                Root userItem = _httpService.RequestJson<Root>(getAllUsers, HttpMethod.Get);
                return userItem;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
