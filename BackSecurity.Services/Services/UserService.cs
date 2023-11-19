using System.Diagnostics.Contracts;
using BackSecurity.Dto.User;
using BackSecurity.Services.IServices;
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
using BackSecurity.Dto.Funcion;
using BackSecurity.Dto.Trabajadores;
using BackSecurity.Dto.Company;


namespace BackSecurity.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly IHttpService _httpService;
        private readonly ICompanyService _company;
        public string GetAllUsers = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/usuario?limit=10000";
        public string InsertUsers = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/usuario/";
        public string UpdateUsers = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/usuario/";
        public string GetTypeById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/funcion/";
        public string GetListType = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/funcion/";
        public string _GetTrabajadoresById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/trabajadores/";

        public UserService(IConfiguration configuration, IHttpService httpService, ICompanyService company)
        {
            _config = configuration;
            _httpService = httpService;
            _company = company;
        }

        public string Login(string user, string pass)
        {
            try
            {
                Root userItem = _httpService.RequestJson<Root>(GetAllUsers, HttpMethod.Get);
                BackSecurity.Dto.User.Item item = userItem.items.Where(x => int.Parse(x.run_usuario.Trim()) == int.Parse(user.Trim()) && x.clave.Trim() == pass.Trim() && x.isdelete == 0).FirstOrDefault();
                if (item != null && item.run_usuario == user)
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

        public string GenerarToken(BackSecurity.Dto.User.Item item)
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
        private static List<Claim> CreateClaims(BackSecurity.Dto.User.Item item)
        {
            List<Claim> claims = new()
            {
                new Claim("id_usuario", item.id_usuario.ToString()),
                new Claim("run_usuario", item.run_usuario),
                new Claim("nom_usuario", item.nom_usuario.ToString()),
                new Claim("tipo_contrato", item.tipo_contrato.ToString()),
                new Claim("fono_usuario", item.fono_usuario.ToString()),
                new Claim("nacionalidad", item.nacionalidad.ToString())
            };
            return claims;
        }
        public bool Create(UserToInsert userToInsert)
        {
            try
            {
                UserInsert user = new();
                Root userItem = _httpService.RequestJson<Root>(GetAllUsers, HttpMethod.Get);
                user.id_usuario = userItem.items.Count + 1;

                string[] strings = userToInsert.nom_usuario.Split(' ');
                user.apellido = (strings.Length > 1) ? strings[1] : "";
                user.nom_usuario = strings[0];
                user.idempresa = userToInsert.id_empresa;
                string[] rut = userToInsert.run_usuario.Split('-');
                user.run_usuario = rut[0];
                user.clave = rut[0];
                user.dvrut = (rut.Count() > 1) ? rut[1] : " ";
                user.isdelete = 0;
                user.idtipocuenta = userToInsert.funcion;
                user.funcion = userToInsert.funcion;
                user.correo = userToInsert.correo;
                user.fono_usuario = userToInsert.fono_usuario;
                user.nacionalidad = userToInsert.nacionalidad;
                user.tipo_contrato = userToInsert.tipo_contrato;
                user.fechacreacion = DateTime.Now.Date.ToString().Split(' ').FirstOrDefault();
                BackSecurity.Dto.User.Item item = _httpService.RequestJson<BackSecurity.Dto.User.Item>(InsertUsers, HttpMethod.Post, JsonConvert.SerializeObject(user));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(UserUpdate user)
        {
            try
            {
                BackSecurity.Dto.User.Item useritem = GetWorker(user.run_usuario);
                useritem.nom_usuario = user.nom_usuario;
                useritem.idempresa = user.id_empresa;
                useritem.fono_usuario = user.fono_usuario;
                useritem.tipo_contrato = user.tipo_contrato;
                useritem.funcion = user.funcion.ToString();
                useritem.nacionalidad = user.nacionalidad;
                useritem.correo = user.correo;
                BackSecurity.Dto.User.Item item = _httpService.RequestJson<BackSecurity.Dto.User.Item>(UpdateUsers + useritem.id_usuario, HttpMethod.Put, JsonConvert.SerializeObject(useritem));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Users> Users()
        {
            try
            {
                Root userItem = _httpService.RequestJson<Root>(GetAllUsers, HttpMethod.Get);
                List<Company> companys =_company.CompanyList();
                List<Users> users = new();
                foreach (BackSecurity.Dto.User.Item item in userItem.items)
                {
                    Users user = new();
                    user.id_usuario = item.id_usuario;
                    user.run_usuario = item.run_usuario;
                    user.nom_usuario = item.nom_usuario;
                    user.tipo_contrato = item.tipo_contrato;
                    user.fono_usuario = item.fono_usuario;
                    user.nacionalidad = item.nacionalidad;
                    user.clave = item.clave;
                    user.tipocuenta = (item.idtipocuenta > 0) ? GetFunctionById(item.idtipocuenta).nom_fun : "";
                    user.empresa = (item.idempresa > 0) ? companys.Where(x => x.id_empresa == item.idempresa).FirstOrDefault().nom_empresa : "";
                    user.fechacreacion = item.fechacreacion;
                    user.isdelete = item.isdelete;
                    user.Eliminado = (item.isdelete != 0) ? "Desactivado" : "Activo";
                    user.funcion = item.funcion;
                    user.correo = item.correo;
                    user.apellido = item.apellido;
                    user.dvrut = item.dvrut;
                    user.haxColor = (item.isdelete != 0) ? "#FF0000" : "#00A653";
                    users.Add(user);
                }
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public BackSecurity.Dto.User.Item GetWorker(string UserName)
        {
            try
            {
                Root userItem = _httpService.RequestJson<Root>(GetAllUsers, HttpMethod.Get);
                BackSecurity.Dto.User.Item user = userItem.items.Where(x => x.run_usuario == UserName).FirstOrDefault();
                return user;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public BackSecurity.Dto.User.Item GetWorkerById(int UserId)
        {
            try
            {
                Root userItem = _httpService.RequestJson<Root>(GetAllUsers, HttpMethod.Get);
                BackSecurity.Dto.User.Item user = userItem.items.Where(x => x.id_usuario == UserId).FirstOrDefault();
                return user;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public Function GetFunctionById(int id)
        {
            Function function = _httpService.RequestJson<Function>(GetTypeById + id, HttpMethod.Get);
            return function;
        }

        public List<BackSecurity.Dto.Funcion.Item> ListFunction()
        {
            RootFunction function = _httpService.RequestJson<RootFunction>(GetListType, HttpMethod.Get);
            return function.items;
        }

        public bool Disable(UserDisable user)
        {
            try
            {
                BackSecurity.Dto.User.Item useritem = GetWorker(user.run_usuario);
                useritem.isdelete = (user.isdelete != useritem.isdelete) ? user.isdelete : 0;
                BackSecurity.Dto.User.Item item = _httpService.RequestJson<BackSecurity.Dto.User.Item>(UpdateUsers + useritem.id_usuario, HttpMethod.Put, JsonConvert.SerializeObject(useritem));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Users> ProfesionalUsers(int id)
        {
            try
            {
                Root userItem = _httpService.RequestJson<Root>(GetAllUsers, HttpMethod.Get);
                List<Users> users = new();
                foreach (BackSecurity.Dto.User.Item item in userItem.items)
                {
                    if (item.idtipocuenta == 2 && item.idempresa == id)
                    {
                        Users user = new();
                        user.id_usuario = item.id_usuario;
                        user.run_usuario = item.run_usuario;
                        user.nom_usuario = item.nom_usuario;
                        user.tipo_contrato = item.tipo_contrato;
                        user.fono_usuario = item.fono_usuario;
                        user.nacionalidad = item.nacionalidad;
                        user.clave = item.clave;
                        user.tipocuenta = (item.idtipocuenta > 0) ? GetFunctionById(item.idtipocuenta).nom_fun : "";
                        user.empresa = (item.idempresa > 0) ? _company.GetCompanyById(item.idempresa).nom_empresa : "";
                        user.fechacreacion = item.fechacreacion;
                        user.isdelete = item.isdelete;
                        user.Eliminado = (item.isdelete != 0) ? "Desactivado" : "Activo";
                        user.funcion = item.funcion;
                        user.correo = item.correo;
                        user.apellido = item.apellido;
                        user.dvrut = item.dvrut;
                        user.haxColor = (item.isdelete != 0) ? "#FF0000" : "#00A653";
                        users.Add(user);
                    }

                }
                return users;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<TrabajadoresRoot> Trabajadores(int idcompany)
        {
            List<TrabajadoresRoot> trabajadoresRoots = _httpService.RequestJson<TrabajadoresListRoot>(_GetTrabajadoresById, HttpMethod.Get).items.Where(x=> x.idempresa==idcompany).ToList();
            return trabajadoresRoots.OrderBy(x => x.id).ToList();
        }
    }
}
