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
using BackSecurity.Dto.Company;
using BackSecurity.Dto.Direccion;
using BackSecurity.Dto.Notificaciones;
using BackSecurity.Dto.TipoNotificacion;
using BackSecurity.Dto.Trabajadores;
using BackSecurity.Dto.NotificacionDirigida;
using System.Net.Mail;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace BackSecurity.Services.Services
{
    public class NotificacionesService : INotificacionesService
    {
        private readonly IConfiguration _config;
        private readonly IHttpService _httpService;
        private readonly ICompanyService _companyService;
        private readonly IDireccionService _direccionService;
        public string GetAll = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/notification";
        public string _GetById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/notification/";
        public string _GetByIdNotification = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/tiponotification/";
        public string _GetCompanyById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/empresa/";
        public string _GetTrabajadoresById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/trabajadores/";
        public string _GetNotificacionDirigidaById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/notificationdirigida/";
        public string GetUsersById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/usuario/";
        public NotificacionesService(IConfiguration configuration,ICompanyService companyService, IHttpService httpService, IDireccionService direccionService)
        {
            _config = configuration;
            _httpService = httpService;
            _direccionService = direccionService;
            _companyService = companyService;
        }

        public List<NotificacionesList> List()
        {
            try
            {
                List<Notificaciones> item = _httpService.RequestJson<NotificacionesRoot>(GetAll, HttpMethod.Get).items;
                List<NotificacionesList> notificacionesLists = new();
                List<Company> companys =_companyService.CompanyList();
                List<TipoNotificacionRoot> notificacionDirigidaRoots = _httpService.RequestJson<ListIpoNotificacionRoot>(_GetByIdNotification, HttpMethod.Get).items;
                foreach (Notificaciones notificaciones in item)
                {
                    NotificacionesList notificacionesList = new();
                    notificacionesList.id = notificaciones.id;
                    notificacionesList.fechaprogramacion = notificaciones.fechaprogramacion;
                    notificacionesList.tiponotificacion =notificacionDirigidaRoots.Where(x => x.id == notificaciones.idtiponotificacion).FirstOrDefault()?.nombre; 
                    notificacionesList.cuerpo = notificaciones.cuerpo;
                    notificacionesList.titulo = notificaciones.titulo;
                    notificacionesList.status = notificaciones.status;
                    notificacionesList.company =companys.Where(x => x.id_empresa == notificaciones.idcompany).FirstOrDefault().nom_empresa ;
                    notificacionesList.notificaciondirigida = _httpService.RequestJson<NotificaciondirigidaFirs>(_GetNotificacionDirigidaById + notificaciones.idnotificaciondirigida, HttpMethod.Get)?.nombre;
                    if (notificacionesList.notificaciondirigida == "Empresa")
                    {
                        notificacionesList.trabajador = notificacionesList.company;
                    }
                    if (notificacionesList.notificaciondirigida == "Profesional")
                    {
                        notificacionesList.trabajador = (notificaciones.idtrabajador > 0) ? _httpService.RequestJson<BackSecurity.Dto.User.Item>(GetUsersById + notificaciones.idtrabajador, HttpMethod.Get)?.run_usuario : "Todos";
                    }
                    if (notificacionesList.notificaciondirigida == "Trabajador")
                    {
                        notificacionesList.trabajador = (notificaciones.idtrabajador > 0) ? _httpService.RequestJson<TrabajadoresRoot>(_GetTrabajadoresById + notificaciones.idtrabajador, HttpMethod.Get)?.run : "Todos";
                    }

                    notificacionesLists.Add(notificacionesList);
                }
                return notificacionesLists.OrderByDescending(x => x.id).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }

        public string stateCompany(Dto.Company.Item item)
        {

            string estadoBooleanCompany = (item.IsDelete != 0) ? "Desactivado" : "Activo";
            string estado = "";
            if (estadoBooleanCompany == "Activo" && item.fechaFinContrato != null)
            {
                estado = (DateTime.Parse(item.fechaFinContrato) > DateTime.Now.Date) ? "Activo" : "Desactivado";
            }
            else
            {
                estado = estadoBooleanCompany;
            }
            return estado;
        }
        public Company GetById(int id)
        {
            try
            {
                Company company = _httpService.RequestJson<Company>(_GetById + id, HttpMethod.Get);
                return company;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public Dto.Company.Item GetCompanyByName(string id)
        {
            List<Dto.Company.Item> companys = _httpService.RequestJson<CompanyRoot>(GetAll, HttpMethod.Get).items;
            Dto.Company.Item company = companys.FirstOrDefault(x => x.nom_empresa == id);
            return company;
        }

        public bool Create(Notificaciones notificaciones, List<int> trabajadores)
        {
            try
            {
                Console.WriteLine("en notifi ");
                notificaciones.id = _httpService.RequestJson<NotificacionesRoot>(GetAll, HttpMethod.Get).items.Count + 1;
                Notificaciones item = _httpService.RequestJson<Notificaciones>(_GetById, HttpMethod.Post, JsonConvert.SerializeObject(notificaciones));
                List<TrabajadoresRoot> trabajadoresRoots = _httpService.RequestJson<TrabajadoresListRoot>(_GetTrabajadoresById, HttpMethod.Get).items.Where(x=> x.idempresa==idcompany).ToList();

                if (notificaciones.idnotificaciondirigida != 3)
                {
                    if (trabajadores != null && trabajadores?.Count > 0)
                    {
                        foreach (int job in trabajadores)
                        {
                            TrabajadoresRoot trabajadoresRoot = trabajadoresRoots.Where(x=> x.id== item.idtrabajador).FirstOrDefault();
                            if (item.idtiponotificacion == 1)
                            {
                                smtp($"Hola {trabajadoresRoot.nombre},", item.titulo, item.cuerpo, trabajadoresRoot.correo);
                                sms(trabajadoresRoot.fono_usuario.ToString(), $"Hola {trabajadoresRoot.nombre}, {item.titulo} {item.cuerpo}");
                            }
                            if (item.idtiponotificacion == 2)
                            {
                                smtp($"Hola {trabajadoresRoot.nombre},", item.titulo, item.cuerpo, trabajadoresRoot.correo);

                            }
                            if (item.idtiponotificacion == 3)
                            {
                                sms(trabajadoresRoot.fono_usuario.ToString(), $"Hola {trabajadoresRoot.nombre}, {item.titulo} {item.cuerpo}");
                            }
                        }
                    }
                    if (item.idtrabajador == 0)
                    {
                        List<TrabajadoresRoot> trabajadoresRoots = _httpService.RequestJson<TrabajadoresListRoot>(_GetTrabajadoresById, HttpMethod.Get).items.Where(x => x.idempresa == item.idcompany).ToList();
                        foreach (TrabajadoresRoot trabajadoresRoot in trabajadoresRoots)
                        {
                            if (item.idtiponotificacion == 1)
                            {
                                smtp($"Hola {trabajadoresRoot.nombre},", item.titulo, item.cuerpo, trabajadoresRoot.correo);
                                sms(trabajadoresRoot.fono_usuario.ToString(), $"Hola {trabajadoresRoot.nombre}, {item.titulo} {item.cuerpo}");
                            }
                            if (item.idtiponotificacion == 2)
                            {
                                smtp($"Hola {trabajadoresRoot.nombre},", item.titulo, item.cuerpo, trabajadoresRoot.correo);

                            }
                            if (item.idtiponotificacion == 3)
                            {
                                sms(trabajadoresRoot.fono_usuario.ToString(), $"Hola {trabajadoresRoot.nombre}, {item.titulo} {item.cuerpo}");
                            }

                        }
                    }
                    else
                    {
                        TrabajadoresRoot trabajadoresRoot = _httpService.RequestJson<TrabajadoresRoot>(_GetTrabajadoresById + item.idtrabajador, HttpMethod.Get);
                        if (item.idtiponotificacion == 1)
                        {
                            smtp($"Hola {trabajadoresRoot.nombre},", item.titulo, item.cuerpo, trabajadoresRoot.correo);
                            sms(trabajadoresRoot.fono_usuario.ToString(), $"Hola {trabajadoresRoot.nombre}, {item.titulo} {item.cuerpo}");
                        }
                        if (item.idtiponotificacion == 2)
                        {
                            smtp($"Hola {trabajadoresRoot.nombre},", item.titulo, item.cuerpo, trabajadoresRoot.correo);

                        }
                        if (item.idtiponotificacion == 3)
                        {
                            sms(trabajadoresRoot.fono_usuario.ToString(), $"Hola {trabajadoresRoot.nombre}, {item.titulo} {item.cuerpo}");
                        }
                    }
                    return (item != null);
                }
                else
                {
                    if (trabajadores != null && trabajadores?.Count > 0)
                    {
                        foreach (int job in trabajadores)
                        {
                            TrabajadoresRoot trabajad = _httpService.RequestJson<TrabajadoresRoot>(_GetTrabajadoresById + item.idtrabajador, HttpMethod.Get);
                            if (item.idtiponotificacion == 1)
                            {
                                smtp($"Hola {trabajad.nombre},", item.titulo, item.cuerpo, trabajad.correo);
                                sms(trabajad.fono_usuario.ToString(), $"Hola {trabajad.nombre}, {item.titulo} {item.cuerpo}");
                            }
                            if (item.idtiponotificacion == 2)
                            {
                                smtp($"Hola {trabajad.nombre},", item.titulo, item.cuerpo, trabajad.correo);

                            }
                            if (item.idtiponotificacion == 3)
                            {
                                sms(trabajad.fono_usuario.ToString(), $"Hola {trabajad.nombre}, {item.titulo} {item.cuerpo}");
                            }
                        }
                    }
                    Console.WriteLine("else");
                    BackSecurity.Dto.User.Item trabajadoresRoot = _httpService.RequestJson<BackSecurity.Dto.User.Item>(GetUsersById + notificaciones.idtrabajador, HttpMethod.Get);

                    if (item.idtiponotificacion == 1)
                    {
                        smtp($"Hola {trabajadoresRoot.nom_usuario},", item.titulo, item.cuerpo, trabajadoresRoot.correo);
                        sms(trabajadoresRoot.fono_usuario.ToString(), $"Hola {trabajadoresRoot.nom_usuario}, {item.titulo} {item.cuerpo.Substring(0, 100)}");
                    }
                    if (item.idtiponotificacion == 2)
                    {
                        smtp($"Hola {trabajadoresRoot.nom_usuario},", item.titulo, item.cuerpo, trabajadoresRoot.correo);

                    }
                    if (item.idtiponotificacion == 3)
                    {
                        sms(trabajadoresRoot.fono_usuario.ToString(), $"Hola {trabajadoresRoot.nom_usuario}, {item.titulo} {item.cuerpo.Substring(0, 100)}");
                    }
                    return (item != null);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return false;
            }
        }

        public bool Update(Notificaciones notificaciones)
        {
            try
            {
                // CompanyInsert companyById = _httpService.RequestJson<CompanyInsert>(_GetById + company.id_empresa, HttpMethod.Get);
                #region Update direccion
                Console.WriteLine(JsonConvert.SerializeObject(notificaciones));
                //BackSecurity.Dto.User.Item item = _httpService.RequestJson<BackSecurity.Dto.User.Item>(_GetById + company.id_empresa, HttpMethod.Put, JsonConvert.SerializeObject(companyById));
                #endregion

                // return (item != null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public List<TipoNotificacionRoot> ListTipoNotificacion()
        {
            List<TipoNotificacionRoot> notificacionDirigidaRoots = _httpService.RequestJson<ListIpoNotificacionRoot>(_GetByIdNotification, HttpMethod.Get).items;
            return notificacionDirigidaRoots;
        }

        public bool smtp(string Subject, string titulo, string body, string destinatario)
        {

            string emailRemitente = "nomasaccidentescompany@gmail.com";
            string contraseñaRemitente = "ebam sxxy eebj grox";

            string emailDestinatario = destinatario;

            MailMessage mensaje = new MailMessage
            {
                From = new MailAddress(emailRemitente),
                Subject = Subject,
                IsBodyHtml = true,
                Body = $"<html><body><h1>{titulo}</h1><p>{body}</p></body></html>"
            };

            mensaje.To.Add(new MailAddress(emailDestinatario));

            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential(emailRemitente, contraseñaRemitente),
                EnableSsl = true
            };

            try
            {
                clienteSmtp.Send(mensaje);
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool sms(string numeroTelefonico, string body)
        {
            try
            {
                const string accountSid = "ACafa7fd641e35d38b538d18278aec90ca";
                const string authToken = "e71cb06f12f58700f4dd3d51b838cd2a";

                TwilioClient.Init(accountSid, authToken);

                var fromPhoneNumber = new PhoneNumber("19896601277");

                Console.WriteLine("numero" + numeroTelefonico);
                Console.WriteLine("body" + body);
                var toPhoneNumber = new PhoneNumber("+56" + numeroTelefonico);

                var message = MessageResource.Create(
                    to: toPhoneNumber,
                    from: fromPhoneNumber,
                    body: body
                );

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
