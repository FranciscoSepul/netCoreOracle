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
using BackSecurity.Dto.Activity;
using BackSecurity.Dto.Tema;
using BackSecurity.Dto.Implementos;

namespace BackSecurity.Services.Services
{
    public class ActividadesService : IActividadesService
    {
        private readonly IConfiguration _config;
        private readonly IHttpService _httpService;
        private readonly IDireccionService _direccionService;
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        public string GetAllActivity = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/capacitacion/";
        public string _GetActivityById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/capacitacion/";
        public string InsertActivity = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/capacitacion/";
        public string GetTemas = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/temacapacitacion/";
        public string GetImplementos = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/implementos/";

        public ActividadesService(IConfiguration configuration, ICompanyService companyService, IUserService userService, IHttpService httpService, IDireccionService direccionService)
        {
            _config = configuration;
            _httpService = httpService;
            _direccionService = direccionService;
            _userService = userService;
            _companyService = companyService;
        }
        public List<Dto.Activity.ActivityList> List()
        {
            try
            {
                List<Dto.Activity.Item> activitys = _httpService.RequestJson<ActivityRoot>(GetAllActivity, HttpMethod.Get).items;
                List<ActivityList> activitysList = new();
                foreach (Dto.Activity.Item activity in activitys)
                {

                    ActivityList activityList = new();
                    activityList.id = activity.id;
                    activityList.profesionalacargo = _userService.GetWorkerById(activity.idprofesionalacargo).nom_usuario;
                    activityList.haxColor = (stateCompany(activity) != "Activo") ? "#FF0000" : "#00A653";
                    activityList.tema = _httpService.RequestJson<OneTemaRoot>(GetTemas + activity.tema, HttpMethod.Get).capacitacion;
                    activityList.company = _companyService.GetCompanyById(activity.idcompany).nom_empresa;
                    activityList.fechaprogramacionyHora = ($"{DateTime.Parse(activity.fechaprogramacion).ToString("dd/MM/yyyy")} {activity.horaprogramacion}");
                    activityList.isdelete = activity.isdelete;
                    activityList.eliminado = stateCompany(activity);
                    activitysList.Add(activityList);
                }
                return activitysList.OrderBy(x => x.isdelete).ToList();
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
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }
        /*
        public Company GetCompanyById(int id)
        {
            try
            {
                Company company = _httpService.RequestJson<Company>(_GetCompanyById + id, HttpMethod.Get);
                return company;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public Dto.Company.Item GetCompanyByName(string id)
        {
            List<Dto.Company.Item> companys = _httpService.RequestJson<CompanyRoot>(GetAllCompany, HttpMethod.Get).items;
            Dto.Company.Item company = companys.FirstOrDefault(x => x.nom_empresa == id);
            return company;
        }
*/
        public bool Create(ActivityCreate activity)
        {
            try
            {
                Console.WriteLine(_httpService.RequestJson<ActivityRoot>(GetAllActivity, HttpMethod.Get).items.Count());
                activity.id = _httpService.RequestJson<ActivityRoot>(GetAllActivity, HttpMethod.Get).items.Count() + 1;
                activity.isdelete = 0;
                Console.WriteLine(JsonConvert.SerializeObject(activity));
                BackSecurity.Dto.User.Item item = _httpService.RequestJson<BackSecurity.Dto.User.Item>(InsertActivity, HttpMethod.Post, JsonConvert.SerializeObject(activity));
                return (item != null);
            }
            catch (Exception)
            {
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
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
