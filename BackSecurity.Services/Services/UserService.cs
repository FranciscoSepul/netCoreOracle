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
using Newtonsoft.Json;

namespace BackSecurity.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly IHttpService _httpService;
        public string GetAllUsers = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/usuario";
        public string InsertUsers = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/usuario/";

        public UserService(IConfiguration configuration, IHttpService httpService)
        {
            _config = configuration;
            _httpService = httpService;
        }

        public string Login(string user, string pass)
        {
            try
            {
                Root userItem = _httpService.RequestJson<Root>(GetAllUsers, HttpMethod.Get);
                Item item = userItem.items.Where(x => x.nom_usuario == user && x.clave == pass).FirstOrDefault();
                if (item != null && item.nom_usuario == user)
                {
                    return GenerarToken(item); ;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }


        }
        public string GenerarToken(Item item)
        {
            JwtSecurityToken jwtToken = new
                        (null,
                        null,
                        CreateClaims(item),
                        null,
                        expires: DateTime.Now.AddDays(1).ToLocalTime());
            string token = new JwtSecurityTokenHandler()
                        .WriteToken(jwtToken);
            return token;
        }
        private static List<Claim> CreateClaims(Item item)
        {
            List<Claim> claims = new()
            {
                new Claim("id_usuario", item.id_usuario.ToString()),
                new Claim("run_usuario", item.run_usuario),
                new Claim("nom_usuario", item.nom_usuario.ToString()),
                new Claim("cuenta", item.cuenta.ToString()),
                new Claim("tipo_contrato", item.tipo_contrato.ToString()),
                new Claim("fono_usuario", item.fono_usuario.ToString()),
                new Claim("nacionalidad", item.nacionalidad.ToString())
            };
            return claims;
        }
        public bool Create(UserInsert user)
        {
            try
            {
                user.clave ="12345";
                user.id_usuario = Users().count+100;
                Console.WriteLine("en insert 2");
                Item item = _httpService.RequestJson<Item>(InsertUsers, HttpMethod.Post,JsonConvert.SerializeObject(user));
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("en error");
                return false;
            }

        }
        public Root Users()
        {
            try
            {
                Root userItem = _httpService.RequestJson<Root>(GetAllUsers, HttpMethod.Get);
                return userItem;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
         public Item GetWorker (string UserName)
        {
            try
            {
                Root userItem = _httpService.RequestJson<Root>(GetAllUsers, HttpMethod.Get);
                Item user = userItem.items.Where(x => x.nom_usuario == UserName).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

    }
}
