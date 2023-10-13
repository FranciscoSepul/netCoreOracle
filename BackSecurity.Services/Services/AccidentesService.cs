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
using BackSecurity.Dto.Accidente;
using BackSecurity.Dto.TipoAccidente;
using BackSecurity.Dto.Gravedad;
using DocumentFormat.OpenXml.Drawing;

namespace BackSecurity.Services.Services
{
    public class AccidentesService : IAccidentesService
    {
        private readonly IConfiguration _config;
        private readonly IHttpService _httpService;
        private readonly IDireccionService _direccionService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        public string GetAll = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/accidente?limit=10000";
        public string _GetById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/accidente/";
        public string Insert = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/accidente/";

        public string TipoAccidenteGetById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/tipodeaccidente/";
        public string GravedadById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/gravedad/";

        public AccidentesService(IConfiguration configuration, IHttpService httpService, IDireccionService direccionService, ICompanyService companyService, IUserService userService)
        {
            _config = configuration;
            _httpService = httpService;
            _direccionService = direccionService;
            _companyService = companyService;
            _userService = userService;
        }

        public List<Dto.TipoAccidente.Item> GetAllTipoAccidente()
        {
            List<Dto.TipoAccidente.Item> accidents = _httpService.RequestJson<TipoAccidenteList>(TipoAccidenteGetById, HttpMethod.Get).items;
            return accidents;
        }

        public TipoAccidente GetByIdTipoAccidente(int id)
        {
            TipoAccidente accident = _httpService.RequestJson<TipoAccidente>(TipoAccidenteGetById + id, HttpMethod.Get);
            return accident;
        }
        public Gravedad GetByIdGravedad(int id)
        {
            Gravedad gravedad = _httpService.RequestJson<Gravedad>(GravedadById + id, HttpMethod.Get);
            return gravedad;
        }
        public List<Dto.Gravedad.Item> GetAllGravedad()
        {
            List<Dto.Gravedad.Item> gravedades = _httpService.RequestJson<GravedadList>(GravedadById , HttpMethod.Get).items;
            return gravedades;
        }
        public static string ColorIcon(Dto.Accidente.Item item)
        {
            if (item.idgravedad == 1)
            {
                return "blue";
            }
            else
            {
                return (item.idgravedad == 2) ? "yellow" : "red";
            }
        }
        public List<Accidente> List()
        {
            try
            {
                List<Dto.Accidente.Item> accident = _httpService.RequestJson<AccidentRoot>(GetAll, HttpMethod.Get).items;
                List<Accidente> accidentes = new();
                foreach (Dto.Accidente.Item item in accident)
                {
                    Accidente accidente = new();
                    accidente.Id = item.id;
                    accidente.Descripcion = item.descripcion;
                    accidente.Tipoaccidente = GetByIdTipoAccidente(item.idtipoaccidente).accidente;
                    accidente.Empresa = _companyService.GetCompanyById(item.idempresa).nom_empresa;
                    accidente.NombreProfesional = _userService.GetWorkerById(item.idtrabajador).nom_usuario;
                    accidente.Gravedad = GetByIdGravedad(item.idgravedad).gravedad;
                    accidente.RutTrabajador = _userService.GetWorkerById(item.idtrabajador).run_usuario;
                    accidente.Fechaaccidente = item.fechaaccidente;
                    accidente.Fechaalta = item.fechaalta;
                    accidente.Fono_emergencia = item.fono_emergencia;
                    accidente.color = ColorIcon(item);
                    accidentes.Add(accidente);
                }
                return accidentes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }

        public string state(Dto.Company.Item item)
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

        public bool Create(CreateAccidente accidente)
        {
            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(accidente));
                BackSecurity.Dto.Accidente.Accidente item = _httpService.RequestJson<BackSecurity.Dto.Accidente.Accidente>(Insert, HttpMethod.Post, JsonConvert.SerializeObject(accidente));
                return (item != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(CompanyUpdate company)
        {
            try
            {
                CompanyInsert companyById = _httpService.RequestJson<CompanyInsert>(_GetById + company.id_empresa, HttpMethod.Get);

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
                BackSecurity.Dto.User.Item item = _httpService.RequestJson<BackSecurity.Dto.User.Item>(Insert + company.id_empresa, HttpMethod.Put, JsonConvert.SerializeObject(companyById));
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
            CompanyInsert companyById = _httpService.RequestJson<CompanyInsert>(_GetById + company.id_empresa, HttpMethod.Get);
            #region Update company
            companyById.isdelete = (company.isdelete != companyById.isdelete) ? company.isdelete : 0;
            BackSecurity.Dto.User.Item item = _httpService.RequestJson<BackSecurity.Dto.User.Item>(Insert + company.id_empresa, HttpMethod.Put, JsonConvert.SerializeObject(companyById));
            #endregion
            return (item != null);
        }


    }
}
