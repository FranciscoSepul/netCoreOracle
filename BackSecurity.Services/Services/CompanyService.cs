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
using BackSecurity.Dto.Empleado;
using BackSecurity.Dto.PreciosPorEmpresa;
using BackSecurity.Dto.Accidente;
using System.Globalization;

namespace BackSecurity.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IConfiguration _config;
        private readonly IHttpService _httpService;
        private readonly IDireccionService _direccionService;
        public string GetAllCompany = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/empresa?limit=10000";
        public string _GetCompanyById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/empresa/";
        public string InsertCompany = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/empresa/";
        public string idPropiedadEmpresa = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/propiedadempresa/";
        public string idTipoDeEmpresa = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/tipodeempresa/";
        public string CategoriaOcupacional = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/categoriaocupacional/";
        public string TipoDeIngreso = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/tipodeingreso/";
        public string LugarDelAccidente = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/lugardeaccidente/";
        public string MedioDePrueba = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/mediodeprueba/";
        public string GetJobById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/trabajadores/";
        public string PreciosPorEmpresa = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/preciosporempresa/";
        public string GetAll = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/accidente?limit=10000";
        public string format = "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz '(hora de verano de Chile)'";

        public CompanyService(IConfiguration configuration, IHttpService httpService, IDireccionService direccionService)
        {
            _config = configuration;
            _httpService = httpService;
            _direccionService = direccionService;
        }

        public List<Dto.Company.Company> CompanyList()
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
                    company.numeroTelefonico = item.numeroTelefonico;
                    company.ActividadEconomica = item.ActividadEconomica;
                    company.IdPropiedadEmpresa = _httpService.RequestJson<Dto.PropiedadEmpresa.Item>(idPropiedadEmpresa + item.IdPropiedadEmpresa, HttpMethod.Get).nombre;
                    company.idTipoDeEmpresa = _httpService.RequestJson<Dto.TipoEmpresa.Item>(idTipoDeEmpresa + item.idTipoDeEmpresa, HttpMethod.Get).nombre;
                    company.trabajadoresHombres = _httpService.RequestJson<EmpleadoRoot>(GetJobById, HttpMethod.Get).items.Where(x => x.idempresa == item.id_empresa && x.sexo == 1).Count();
                    company.trabajadoresMujeres = _httpService.RequestJson<EmpleadoRoot>(GetJobById, HttpMethod.Get).items.Where(x => x.idempresa == item.id_empresa && x.sexo == 0).Count();


                    company.IsDelete = (stateCompany(item) != "Activo") ? 1 : 0;

                    companies.Add(company);
                }
                return companies.OrderBy(x => x.IsDelete).ToList();
            }
            catch (Exception ex)
            {
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
        public Dto.Company.Company GetCompanyById(int id)
        {
            try
            {
                CompanyInsert item = _httpService.RequestJson<CompanyInsert>(_GetCompanyById + id, HttpMethod.Get);
                Dto.Direccion.Item direccion = _direccionService.GetDireccionById(item.iddireccion);
                Dto.Company.Company company = new();

                company.id_empresa = item.id_empresa;
                company.nom_empresa = item.nom_empresa;
                company.Rut = item.rut;
                company.DvRut = item.dvrut;
                company.ImageBase64 = item.imageBase64;
                company.fechaFinContrato = item.fechafincontrato;
                company.Correo = item.correo;
                company.Region = direccion.id_region;
                company.Comuna = direccion.id_comuna;
                company.Direccion = $"{direccion.calle}  {direccion.numeracion}";
                company.numeroTelefonico = item.numeroTelefonico;
                company.ActividadEconomica = item.ActividadEconomica;
                company.IdPropiedadEmpresa = _httpService.RequestJson<Dto.PropiedadEmpresa.Item>(idPropiedadEmpresa + item.IdPropiedadEmpresa, HttpMethod.Get).nombre;
                company.idTipoDeEmpresa = _httpService.RequestJson<Dto.TipoEmpresa.Item>(idTipoDeEmpresa + item.idTipoDeEmpresa, HttpMethod.Get).nombre;
                company.trabajadoresHombres = _httpService.RequestJson<EmpleadoRoot>(GetJobById, HttpMethod.Get).items.Where(x => x.idempresa == item.id_empresa && x.sexo == 1).Count();
                company.trabajadoresMujeres = _httpService.RequestJson<EmpleadoRoot>(GetJobById, HttpMethod.Get).items.Where(x => x.idempresa == item.id_empresa && x.sexo == 0).Count();
                company.CantidadDeEmpleadosPorContrato = item.CantidadDeEmpleadosPorContrato;

                BackSecurity.Dto.PreciosPorEmpresa.Item preciosPorE = _httpService.RequestJson<PreciosPorEmpresaRoot>(PreciosPorEmpresa, HttpMethod.Get).items.Where(x => x.idempresa == id).FirstOrDefault();
                if (preciosPorE != null)
                {
                    company.costoporaccidente = preciosPorE.costoporaccidente;
                    company.costoporcharla = preciosPorE.costoporcharla;
                    company.costoporvisita = preciosPorE.costoporvisita;
                    company.costobase = preciosPorE.costobase;
                    company.costoporasesoria = preciosPorE.costoporasesoria;
                    company.costoporasesoriaespecial = preciosPorE.costoporasesoriaespecial;
                    company.costoporpersonaextra = preciosPorE.costoporpersonaextra;
                }

                return company;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }

        }

        public Dto.Company.Item GetCompanyByName(string id)
        {
            List<Dto.Company.Item> companys = _httpService.RequestJson<CompanyRoot>(GetAllCompany, HttpMethod.Get).items;
            Dto.Company.Item company = companys.FirstOrDefault(x => x.nom_empresa == id);
            return company;
        }

        public bool Create(CompanyCreate company)
        {
            try
            {
                DireccionInsert direccion = new();
                direccion.calle = company.direccion;
                direccion.id_region = company.region;
                direccion.id_comuna = company.comuna;
                int IDDIRECCION = _direccionService.Create(direccion);

                CompanyInsert companyInsert = new();
                List<Dto.Company.Item> companys = _httpService.RequestJson<CompanyRoot>(GetAllCompany, HttpMethod.Get).items;
                companyInsert.id_empresa = companys.Count() + 1;
                companyInsert.iddireccion = IDDIRECCION;
                companyInsert.correo = company.correo;
                companyInsert.fechacreacion = DateTime.Now.Date.ToString().Split(' ').FirstOrDefault().Replace('/', '-');
                string[] rut = company.rut.Split('-');
                companyInsert.rut = rut[0];
                companyInsert.dvrut = (rut.Count() > 1) ? rut[1] : " ";
                companyInsert.nom_empresa = company.nom_empresa;
                companyInsert.isdelete = 0;
                companyInsert.fechafincontrato = company.fechaFinContrato.ToString().Split('T').FirstOrDefault();
                companyInsert.numeroTelefonico = company.numeroTelefonico;
                companyInsert.IdPropiedadEmpresa = int.Parse(company.idPropiedadEmpresa);
                companyInsert.idTipoDeEmpresa = int.Parse(company.idTipoDeEmpresa);
                companyInsert.ActividadEconomica = company.actividadEconomica;
                companyInsert.CantidadDeEmpleadosPorContrato = company.cantidadDeEmpleadosPorContrato;
                BackSecurity.Dto.User.Item item = _httpService.RequestJson<BackSecurity.Dto.User.Item>(InsertCompany, HttpMethod.Post, JsonConvert.SerializeObject(companyInsert));
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
                companyById.correo = company.correo;
                string[] rut = company.rut.Split('-');
                companyById.rut = rut[0];
                companyById.dvrut = (rut.Length > 1) ? rut[1] : " ";
                companyById.nom_empresa = company.nom_empresa;
                companyById.fechafincontrato = company.fechaFinContrato.ToString().Split('T').FirstOrDefault();
                companyById.numeroTelefonico = company.numeroTelefonico;
                companyById.IdPropiedadEmpresa = int.Parse(company.idPropiedadEmpresa);
                companyById.idTipoDeEmpresa = int.Parse(company.idTipoDeEmpresa);
                companyById.ActividadEconomica = company.actividadEconomica;
                companyById.CantidadDeEmpleadosPorContrato = company.cantidadDeEmpleadosPorContrato;

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
                return null;
            }
        }

        public Factura GetCompanyFactura(string id, string desde, string hasta)
        {
            Factura factura = new();
            Console.WriteLine(desde);
            Console.WriteLine(hasta);

            DateTime Fdesde = DateTime.ParseExact(desde, format, CultureInfo.InvariantCulture);
            DateTime Fhasta = DateTime.ParseExact(hasta, format, CultureInfo.InvariantCulture);
            BackSecurity.Dto.PreciosPorEmpresa.Item preciosPorE = _httpService.RequestJson<PreciosPorEmpresaRoot>(PreciosPorEmpresa, HttpMethod.Get).items.Where(x => x.idempresa.ToString() == id).FirstOrDefault();
            List<Dto.Accidente.Item> accident = _httpService.RequestJson<AccidentRoot>(GetAll, HttpMethod.Get).items.Where(x => x.idempresa.ToString() == id && DateTime.Parse(x.fechaaccidente) >= Fdesde
            && DateTime.Parse(x.fechaaccidente) <= Fhasta).ToList();
            factura.CostoTotalAccidente = (accident.Count > 0) ? accident.Count * preciosPorE.costoporaccidente : 0;
            factura.CostoTotalCharla = 0;
            factura.CostoTotalVisita = 0;
            factura.CostoTotalAsesoria = 0;
            factura.CostoTotalAsesoriaEspecial = 0;
            int cantidadTrabajadores = _httpService.RequestJson<EmpleadoRoot>(GetJobById, HttpMethod.Get).items.Where(x => x.idempresa.ToString() == id).Count();
            int cantidadPorContrato = _httpService.RequestJson<CompanyInsert>(_GetCompanyById + id, HttpMethod.Get).CantidadDeEmpleadosPorContrato;
            factura.CostoTotalPersonasExtra = (cantidadPorContrato < cantidadTrabajadores) ? (cantidadPorContrato - cantidadTrabajadores) * preciosPorE.costoporpersonaextra : 0;
            factura.CostoTotal = preciosPorE.costobase + (factura.CostoTotalAccidente + factura.CostoTotalCharla + factura.CostoTotalVisita + factura.CostoTotalAsesoria + factura.CostoTotalAsesoriaEspecial +
            factura.CostoTotalPersonasExtra);
            return factura;
        }

        public Operaciones GetCompanyOperaciones(string id, string desde, string hasta)
        {
            Operaciones operaciones = new();
            DateTime Fdesde = DateTime.ParseExact(desde, format, CultureInfo.InvariantCulture);
            DateTime Fhasta = DateTime.ParseExact(hasta, format, CultureInfo.InvariantCulture);
            List<Dto.Accidente.Item> accident = _httpService.RequestJson<AccidentRoot>(GetAll, HttpMethod.Get).items.Where(x => x.idempresa.ToString() == id && DateTime.ParseExact(x.fechaaccidente, format, CultureInfo.InvariantCulture)  >= Fdesde
            && DateTime.ParseExact(x.fechaaccidente, format, CultureInfo.InvariantCulture) <= Fhasta).ToList();
            operaciones.TotalAccidente = accident.Count;
            operaciones.TotalCharla = 0;
            operaciones.TotalVisita = 0;
            operaciones.TotalAsesoria = 0;
            operaciones.TotalAsesoriaEspecial = 0;
            int cantidadTrabajadores = _httpService.RequestJson<EmpleadoRoot>(GetJobById, HttpMethod.Get).items.Where(x => x.idempresa.ToString() == id).Count();
            int cantidadPorContrato = _httpService.RequestJson<CompanyInsert>(_GetCompanyById + id, HttpMethod.Get).CantidadDeEmpleadosPorContrato;
            operaciones.TotalPersonasExtra = (cantidadPorContrato < cantidadTrabajadores) ? (cantidadPorContrato - cantidadTrabajadores) : 0;
            return operaciones;

        }
    }
}
