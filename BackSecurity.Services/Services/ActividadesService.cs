﻿using BackSecurity.Dto.User;
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
using BackSecurity.Dto.Activity;
using BackSecurity.Dto.Tema;
using BackSecurity.Dto.Implementos;
using BackSecurity.Dto.Notificaciones;
using BackSecurity.Dto.Company;

namespace BackSecurity.Services.Services
{
    public class ActividadesService : IActividadesService
    {
        private readonly IConfiguration _config;
        private readonly IHttpService _httpService;
        private readonly IDireccionService _direccionService;
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly INotificacionesService _notificacionesService;
        public string GetAllActivity = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/capacitacion/";
        public string _GetActivityById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/capacitacion/";
        public string InsertActivity = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/capacitacion/";
        public string GetTemas = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/temacapacitacion/";
        public string GetImplementos = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/implementos/";
        public string _GetCompanyById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/empresa/";
        public string GetAllUsers = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/usuario?limit=10000";
        public string GetAllCompany = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/empresa?limit=10000";



        public ActividadesService(IConfiguration configuration, INotificacionesService notificacionesService, ICompanyService companyService, IUserService userService, IHttpService httpService, IDireccionService direccionService)
        {
            _config = configuration;
            _httpService = httpService;
            _direccionService = direccionService;
            _userService = userService;
            _companyService = companyService;
            _notificacionesService = notificacionesService;
        }
        public List<Dto.Activity.ActivityList> List()
        {
            try
            {
                List<Dto.Activity.Item> activitys = _httpService.RequestJson<ActivityRoot>(GetAllActivity, HttpMethod.Get).items;
                List<ActivityList> activitysList = new();
                List<Dto.User.Item> ProfesionalesACargo = _httpService.RequestJson<Root>(GetAllUsers, HttpMethod.Get).items;
                List<Company> companys =_companyService.CompanyList();
                foreach (Dto.Activity.Item activity in activitys)
                {
                    ActivityList activityList = new();
                    activityList.id = activity.id;
                    activityList.profesionalacargo = ProfesionalesACargo.Where(x => x.id_usuario == activity.idprofesionalacargo).FirstOrDefault().nom_usuario;
                    activityList.haxColor = (stateCompany(activity) != "Activo") ? "#FF0000" : "#00A653";
                    activityList.tema = _httpService.RequestJson<OneTemaRoot>(GetTemas + activity.tema, HttpMethod.Get).capacitacion;
                    activityList.company =companys.Where(x => x.id_empresa == activity.idcompany).FirstOrDefault().nom_empresa;
                    activityList.fechaprogramacionyHora = ($"{DateTime.Parse(activity.fechaprogramacion).ToString("dd/MM/yyyy")} {activity.horaprogramacion}");
                    activityList.eliminado = stateCompany(activity);
                    activitysList.Add(activityList);
                }
                return activitysList.OrderByDescending(x => x.id).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }
        public string stateCompany(Dto.Activity.Item item)
        {

            string estadoBooleanCompany = (item.isdelete != 0) ? "Cancelado" : "Activo";
            string estado = "";
            if (estadoBooleanCompany == "Activo")
            {
                if (DateTime.Parse(item.fechaprogramacion) < DateTime.Now)
                {
                    estado = "Realizado";
                }
                estado = "Activo";
            }
            else
            {
                estado = estadoBooleanCompany;
            }
            return estado;
        }

        public List<BackSecurity.Dto.Tema.Item> ListTema()
        {
            try
            {
                List<BackSecurity.Dto.Tema.Item> temas = _httpService.RequestJson<TemaRoot>(GetTemas, HttpMethod.Get).items;
                return temas.OrderBy(x => x.capacitacion).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Dto.Activity.ActivityInsert GetActivityById(int id)
        {
            try
            {
                Dto.Activity.Item activitys = _httpService.RequestJson<Dto.Activity.Item>(GetAllActivity + id.ToString(), HttpMethod.Get);
                ActivityInsert activityInsert = new();
                activityInsert.descripcion = activitys.descripcion;
                activityInsert.fechaprogramacion = activitys.fechaprogramacion;
                activityInsert.horaprogramacion = activitys.horaprogramacion;
                activityInsert.id = activitys.id;
                activityInsert.idcompany = activitys.idcompany;
                activityInsert.idprofesionalacargo = activitys.idprofesionalacargo;
                activityInsert.isdelete = activitys.isdelete;
                activityInsert.tema = activitys.tema;
                activityInsert.idtrabajador= new();
                activityInsert.idimplementos=new();
                foreach (string job in activitys.idusuarioscapacitacion.Split(';'))
                {
                    activityInsert.idtrabajador.Add(int.Parse(job));
                }
                foreach (string implement in activitys.idimplementoscapacitacion.Split(';'))
                {
                    activityInsert.idimplementos.Add(int.Parse(implement));
                }

                return activityInsert;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                return null;
            }

        }

        public Dto.Company.Item GetCompanyByName(string id)
        {
            List<Dto.Company.Item> companys = _httpService.RequestJson<CompanyRoot>(GetAllCompany, HttpMethod.Get).items;
            Dto.Company.Item company = companys.FirstOrDefault(x => x.nom_empresa == id);
            return company;
        }

        public bool Create(ActivityInsert activityInsert)
        {
            try
            {
                Console.WriteLine("creando capacitacion");
                ActivityCreate activity = new();
                activity.fechaprogramacion = activityInsert.fechaprogramacion;
                activity.descripcion = activityInsert.descripcion;
                activity.tema = activityInsert.tema;
                activity.idprofesionalacargo = activityInsert.idprofesionalacargo;
                activity.horaprogramacion = activityInsert.horaprogramacion;
                activity.idtrabajador = 0;
                activity.idcompany = activityInsert.idcompany;
                activity.idimplementos = 0;
                activity.id = _httpService.RequestJson<ActivityRoot>(GetAllActivity, HttpMethod.Get).items.Count() + 1;
                activity.isdelete = 0;
                string trabajadores = "";
                foreach (int trabajador in activityInsert.idtrabajador)
                {
                    trabajadores = (trabajadores == "") ? trabajadores + trabajador : trabajadores + ";" + trabajador;
                }
                string implementos = "";
                foreach (int implemento in activityInsert.idimplementos)
                {
                    implementos = (implementos == "") ? implementos + implemento : implementos + ";" + implemento;
                }
                activity.idusuarioscapacitacion = trabajadores;
                activity.idimplementoscapacitacion = implementos;
                Console.WriteLine(JsonConvert.SerializeObject(activity));
                BackSecurity.Dto.User.Item item = _httpService.RequestJson<BackSecurity.Dto.User.Item>(InsertActivity, HttpMethod.Post, JsonConvert.SerializeObject(activity));

                #region  crear capacitacion
                Notificaciones notificaciones = new();
                notificaciones.fechaprogramacion = DateTime.Now.Date.ToString();
                notificaciones.cuerpo = $"Los invitamos cordial mente a asistir a la capacitacion de {_httpService.RequestJson<OneTemaRoot>(GetTemas + activity.tema, HttpMethod.Get).capacitacion} el dia {DateTime.Parse(activity.fechaprogramacion).Date} - {activity.horaprogramacion} a cargo del profesional {_userService.GetWorkerById(activity.idprofesionalacargo).nom_usuario}";
                notificaciones.titulo = "Capacitacion";
                notificaciones.idtiponotificacion = 2;
                notificaciones.idnotificaciondirigida = 2;
                notificaciones.idcompany = activity.idcompany;
                notificaciones.idtrabajador = activity.idtrabajador;
                _notificacionesService.Create(notificaciones,activityInsert.idtrabajador);
                #endregion
                return (item != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return false;
            }
        }

        public List<Dto.Implementos.Item> ListImplementos()
        {
            try
            {
                List<BackSecurity.Dto.Implementos.Item> temas = _httpService.RequestJson<ImplementosRoot>(GetImplementos, HttpMethod.Get).items;
                return temas.OrderBy(x => x.id).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        /*
       public bool Update(CompanyUpdate company)
       {
           try
           {
               CompanyInsert companyById = _httpService.RequestJson<CompanyInsert>(_GetCompanyById + company.id_empresa, HttpMethod.Get);

               #region Update direccion
               Dto.Direccion.Item direccion = _direccionService.GetDireccionById(companyById.iddireccion);
               DireccionInsert direccionInsert = new();
               direccionInsert.id_direccion = direccion.id_direccion;
               direccionInsert.calle = direccion.calle;
               direccionInsert.id_region = direccion.id_region;
               direccionInsert.id_comuna = direccion.id_comuna;
               int IDDIRECCION = _direccionService.Update(direccionInsert);
               #endregion
               #region Update company
               companyById.correo = company.Correo;
               string[] rut = company.Rut.Split('-');
               Console.WriteLine("rr " + rut[1]);
               companyById.rut = rut[0];
               companyById.dvrut = (rut.Length > 1) ? rut[1] : " ";
               companyById.nom_empresa = company.nom_empresa;
               companyById.fechafincontrato = company.fechaFinContrato.Split('T').FirstOrDefault();
               Console.WriteLine(JsonConvert.SerializeObject(companyById));
               BackSecurity.Dto.User.Item item = _httpService.RequestJson<BackSecurity.Dto.User.Item>(InsertCompany + company.id_empresa, HttpMethod.Put, JsonConvert.SerializeObject(companyById));
               #endregion

               return (item != null);
           }
           catch (Exception)
           {
               return false;
           }
       }

       public bool Disable(CompanyUpdate company)
       {
           CompanyInsert companyById = _httpService.RequestJson<CompanyInsert>(_GetCompanyById + company.id_empresa, HttpMethod.Get);
           #region Update company
           companyById.isdelete = (company.isdelete != companyById.isdelete) ? company.isdelete : 0;
           BackSecurity.Dto.User.Item item = _httpService.RequestJson<BackSecurity.Dto.User.Item>(InsertCompany + company.id_empresa, HttpMethod.Put, JsonConvert.SerializeObject(companyById));
           #endregion
           return (item != null);
       }

       public List<Company> CompanyListNotDisable()
       {
           try
           {
               List<Dto.Company.Item> companys = _httpService.RequestJson<CompanyRoot>(GetAllCompany, HttpMethod.Get).items;
               List<Dto.Company.Company> companies = new();
               foreach (Dto.Company.Item item in companys)
               {
                   Dto.Direccion.Item direccion = _direccionService.GetDireccionById(item.IDDIRECCION);
                   Dto.Company.Company company = new();

                   company.id_empresa = item.id_empresa;
                   company.nom_empresa = item.nom_empresa;
                   company.Rut = item.Rut;
                   company.DvRut = item.DvRut;
                   company.ImageBase64 = item.ImageBase64;
                   company.fechaFinContrato = item.fechaFinContrato;
                   company.Correo = item.Correo;
                   company.eliminado = stateCompany(item);
                   company.fechaCreacion = item.fechaCreacion;
                   company.haxColor = (stateCompany(item) != "Activo") ? "#FF0000" : "#00A653";
                   company.Region = direccion.id_region;
                   company.Comuna = direccion.id_comuna;
                   company.Direccion = $"{direccion.calle}  {direccion.numeracion}";
                   company.IsDelete = (stateCompany(item) != "Activo") ? 1 : 0;
                   if (company.IsDelete == 0)
                   {
                       companies.Add(company);
                   }

               }
               return companies.OrderBy(x => x.IsDelete).ToList();
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message + ex.StackTrace);
               return null;
           }
       }*/
    }
}
