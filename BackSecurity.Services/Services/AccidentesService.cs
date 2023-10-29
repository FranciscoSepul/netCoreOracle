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
using BackSecurity.Dto.Empleado;
using BackSecurity.Dto.Notificaciones;
using BackSecurity.Dto.PropiedadEmpresa;

namespace BackSecurity.Services.Services
{
    public class AccidentesService : IAccidentesService
    {
        private readonly IConfiguration _config;
        private readonly IHttpService _httpService;
        private readonly IDireccionService _direccionService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly INotificacionesService _notificacionesService;
        public string _GetCompanyById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/empresa/";
        public string GetAll = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/accidente?limit=10000";
        public string _GetById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/accidente/";
        public string Insert = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/accidente/";
        public string TipoAccidenteGetById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/tipodeaccidente/";
        public string GravedadById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/gravedad/";
        public string GetSucursalAchsById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/sucursalachs/";
        public string GetJobById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/trabajadores/";
        public string idPropiedadEmpresa = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/propiedadempresa/";
        public string idTipoDeEmpresa = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/tipodeempresa/";
        public string CategoriaOcupacional = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/categoriaocupacional/";
        public string TipoDeIngreso = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/tipodeingreso/";
        public string LugarDelAccidente = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/lugardeaccidente/";
        public string MedioDePrueba = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/mediodeprueba/";


        public AccidentesService(IConfiguration configuration, INotificacionesService notificacionesService, IHttpService httpService, IDireccionService direccionService, ICompanyService companyService, IUserService userService)
        {
            _config = configuration;
            _httpService = httpService;
            _direccionService = direccionService;
            _companyService = companyService;
            _userService = userService;
            _notificacionesService = notificacionesService;
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
            List<Dto.Gravedad.Item> gravedades = _httpService.RequestJson<GravedadList>(GravedadById, HttpMethod.Get).items;
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
                return (item.idgravedad == 2) ? "orange" : "red";
            }
        }

        public Accidente AccidenteById(int id)
        {
            Console.WriteLine("accident by id ");
            Dto.Accidente.Item item = _httpService.RequestJson<Dto.Accidente.Item>(_GetById + id, HttpMethod.Get);
            Accidente accidente = new();
            accidente.Id = item.id;
            accidente.Descripcion = item.descripcion;
            accidente.Tipoaccidente = GetByIdTipoAccidente(item.idtipoaccidente).accidente;

            Dto.Company.Company company = _companyService.GetCompanyById(item.idempresa);
            Console.WriteLine("company " + item.idempresa);
            accidente.Empresa = company.nom_empresa;
            accidente.EmpresaDvRut = company.DvRut;
            accidente.EmpresaRut = company.Rut;
            accidente.ComunaEmpresa = _direccionService.GetComunaById(company.Comuna).FirstOrDefault().nombre_comuna;
            accidente.CorreoEmpresa = company?.Correo;
            accidente.RegionEmpresa = _direccionService.DireccionList().Where(x => x.id_region == company.Region).FirstOrDefault().nom_reg;
            accidente.DireccionEmpresa = company?.Direccion;
            accidente.numeroTelefonico = company.numeroTelefonico;
            accidente.ActividadEconomica = company.ActividadEconomica;
            accidente.IdPropiedadEmpresa = _httpService.RequestJson<Dto.PropiedadEmpresa.Item>(idPropiedadEmpresa + company.IdPropiedadEmpresa, HttpMethod.Get).nombre;
            accidente.idTipoDeEmpresa = _httpService.RequestJson<Dto.TipoEmpresa.Item>(idTipoDeEmpresa + company.idTipoDeEmpresa, HttpMethod.Get).nombre;
            accidente.trabajadoresHombres = _httpService.RequestJson<EmpleadoRoot>(GetJobById, HttpMethod.Get).items.Where(x => x.idempresa == item.idempresa && x.sexo == 1).Count();
            accidente.trabajadoresMujeres = _httpService.RequestJson<EmpleadoRoot>(GetJobById, HttpMethod.Get).items.Where(x => x.idempresa == item.idempresa && x.sexo == 0).Count(); 

            Dto.User.Item user = _userService.GetWorkerById(item.idtrabajador);
            accidente.NombreProfesional = user?.nom_usuario;
            accidente.CelProfesional = user?.fono_usuario.ToString();
            accidente.RutProfesional = user?.run_usuario;
            accidente.Apellidofesional = user?.apellido;
            accidente.ClasificacionDenunciante = "Empleador";
            accidente.Gravedad = GetByIdGravedad(item.idgravedad).gravedad;
            Job job = _httpService.RequestJson<Job>(GetJobById + item.idtrabajador, HttpMethod.Get);
            if (job != null)
            {
                accidente.RutTrabajador = job?.run;
                accidente.EmpleadoNombre = job?.nombre;
                accidente.NumeroContactoEmnpleado = job.fono_usuario;
                accidente.CorreoEmpleado = job?.correo;
                Dto.Direccion.Item direccionTrabajadores = _direccionService.GetDireccionById(job.iddireccion);
                accidente.DireccionTrabajador = direccionTrabajadores.calle;
                accidente.ComunaTrabajador = _direccionService.GetComunaById(direccionTrabajadores.id_comuna).FirstOrDefault().nombre_comuna;
                accidente.HoraAccidente = DateTime.Parse(item.fechaaccidente).ToString("HH:mm");
                accidente.Sexo = (job.sexo == 0) ? "Mujer" : "Hombre";
                accidente.HoraIngresoAlTrabajo = job.HoraIngreso;
                accidente.HoraSalidaTrabajo = job.HoraSalida;
                accidente.FechaNacimiento = job.FechaNacimiento;
                accidente.Edad = (DateTime.Now.Year - DateTime.Parse(job.FechaNacimiento).Year).ToString() + " Años";
                accidente.ProfesionTrabajador = job.Profesion;
                accidente.PuebloOriginario = job.PuebloOriginario;
                accidente.TipoDeContratoTrabajador = job.TipoDeContrato;
                accidente.CategoriaOcupacional = _httpService.RequestJson<Dto.CategoriaOcupacional.Item>(CategoriaOcupacional + job.idCategoriaOcupacional, HttpMethod.Get).nombre;
                accidente.TipoDeIngreso = _httpService.RequestJson<Dto.CategoriaOcupacional.Item>(TipoDeIngreso + job.IdTipoDeIngreso, HttpMethod.Get).nombre;
                accidente.Nacionalidad = job.nacionalidad;
                accidente.Antiguedad = (DateTime.Now.Year - DateTime.Parse(job.FechaContrato).Year).ToString() + " Años";

            }

            accidente.Fechaaccidente = DateTime.Parse(item?.fechaaccidente).ToString("dd/MM/yyyy");
            accidente.Fechaalta = item?.fechaalta;
            accidente.Fono_emergencia = item.fono_emergencia;
            accidente.TipoDeAccidente = _httpService.RequestJson<Dto.CategoriaOcupacional.Item>(LugarDelAccidente + item.idLugarDeAccidente, HttpMethod.Get).nombre;
            Console.WriteLine("Tipo de accidente " + accidente.TipoDeAccidente);
            Console.WriteLine("Medio de prueba " + item.idMedioDePrueba);
            accidente.MedioDePrueba = _httpService.RequestJson<Dto.CategoriaOcupacional.Item>(MedioDePrueba + item.idMedioDePrueba, HttpMethod.Get).nombre;
            accidente.color = ColorIcon(item);
            return accidente;

        }

        public List<Dto.CategoriaOcupacional.Item> LugarDelAccidentes()
        {
           return _httpService.RequestJson<Dto.CategoriaOcupacional.CategoriaOcupacionalRoot>(LugarDelAccidente , HttpMethod.Get).items;
        }
        public List<Dto.CategoriaOcupacional.Item> MediosDePruebas()
        {
           return  _httpService.RequestJson<Dto.CategoriaOcupacional.CategoriaOcupacionalRoot>(MedioDePrueba , HttpMethod.Get).items;
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
                    accidente.Tipoaccidente = GetByIdTipoAccidente(item.idtipoaccidente).accidente;
                    Dto.Company.Company company = _companyService.GetCompanyById(item.idempresa);
                    accidente.Empresa = company.nom_empresa;
                    Dto.User.Item user = _userService.GetWorkerById(item.idtrabajador);
                    accidente.NombreProfesional = user?.nom_usuario;
                    accidente.Gravedad = GetByIdGravedad(item.idgravedad).gravedad;
                    Job job = _httpService.RequestJson<Job>(GetJobById + item.idtrabajador, HttpMethod.Get);
                    if (job != null)
                    {
                        accidente.RutTrabajador = job?.run;
                    }
                    accidente.Fechaaccidente = DateTime.Parse(item?.fechaaccidente).ToString("dd/MM/yyyy");
                    accidente.color = ColorIcon(item);
                    accidentes.Add(accidente);
                }
                return accidentes.OrderBy(x => x.Id).ToList();
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
                InsertAccidente insertAccidente = new();
                insertAccidente.idtipoaccidente = accidente.IdTipoDeAccidente;
                insertAccidente.id = _httpService.RequestJson<AccidentRoot>(GetAll, HttpMethod.Get).items.Count() + 1;
                insertAccidente.idgravedad = accidente.IdGravedad;
                insertAccidente.idempresa = accidente.IdEmpresa;
                insertAccidente.idprofesional = accidente.IdProfesional;
                insertAccidente.fechaaccidente = DateTime.Now.ToString();
                insertAccidente.descripcion = accidente.Descripcion;
                insertAccidente.fono_emergencia = int.Parse(accidente.fono);
                insertAccidente.idtrabajador = accidente.IdTrabajador;
                insertAccidente.idlugardeaccidente = accidente.Idlugardeaccidente;
                insertAccidente.idmediodeprueba =accidente.Idmediodeprueba;
                BackSecurity.Dto.Accidente.Accidente item = _httpService.RequestJson<BackSecurity.Dto.Accidente.Accidente>(Insert, HttpMethod.Post, JsonConvert.SerializeObject(insertAccidente));
                Notificaciones notificaciones = new();
                notificaciones.fechaprogramacion = DateTime.Now.Date.ToString();
                CompanyInsert company = _httpService.RequestJson<CompanyInsert>(_GetCompanyById + accidente.IdEmpresa, HttpMethod.Get);
                notificaciones.cuerpo = $"Favor comunicarse de manera urgente con la empresa {company.nom_empresa} al correo {company.correo} o al fono {accidente.fono} ya que el trabajador {_userService.GetWorkerById(accidente.IdTrabajador).nom_usuario} tuvo un accidente de grado {GetByIdGravedad(accidente.IdGravedad).gravedad} Tipo de accidente: {GetByIdTipoAccidente(accidente.IdTipoDeAccidente).accidente}  Descripcion: {accidente.Descripcion} ";
                notificaciones.titulo = "Urgente";
                notificaciones.idtiponotificacion = 1;
                notificaciones.idnotificaciondirigida = 3;
                notificaciones.idcompany = accidente.IdEmpresa;
                notificaciones.idtrabajador = accidente.IdProfesional;
                _notificacionesService.Create(notificaciones);
                return (item != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("llegu catch "+ex.Message +ex.InnerException);
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

        public Job GetByIdEmpleado(int id)
        {
            Job job = _httpService.RequestJson<Job>(GetJobById + id, HttpMethod.Get);
            return job;
        }

        public List<Job> GetJobByIdSucursal(int id)
        {
            List<Job> jobs = _httpService.RequestJson<EmpleadoRoot>(GetJobById, HttpMethod.Get).items;
            List<Job> jobsBySucursal = new();
            if (jobs.Count > 0)
            {
                Job AllJob = new();
                AllJob.id = 0;
                AllJob.run = "Todos";
                jobsBySucursal.Add(AllJob);
            }

            foreach (Job job in jobs)
            {
                if (job.idempresa == id)
                {
                    jobsBySucursal.Add(job);
                }
            }
            return jobsBySucursal;
        }

        public Company GetByIdSucursal(int id)
        {
            throw new NotImplementedException();
        }
    }
}
