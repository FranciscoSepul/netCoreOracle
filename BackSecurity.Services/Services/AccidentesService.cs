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
using BackSecurity.Dto.Company;
using BackSecurity.Dto.Direccion;
using BackSecurity.Dto.Accidente;
using BackSecurity.Dto.TipoAccidente;
using BackSecurity.Dto.Gravedad;
using DocumentFormat.OpenXml.Drawing;
using BackSecurity.Dto.Empleado;

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
        public string GetSucursalAchsById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/sucursalachs/";
        public string GetJobById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/trabajadores/";
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

                    CompanyInsert company = _companyService.GetCompanyById(item.idempresa);
                    Dto.Direccion.Item direccion = _direccionService.GetDireccionById(company.iddireccion);
                    accidente.Empresa = company.nom_empresa;
                    accidente.EmpresaDvRut = company.dvrut;
                    accidente.EmpresaRut = company.rut;
                    accidente.ComunaEmpresa = _direccionService.GetComunaById(direccion.id_comuna).FirstOrDefault().nombre_comuna;
                    accidente.CorreoEmpresa = company?.correo;
                    accidente.RegionEmpresa = _direccionService.DireccionList().Where(x => x.id_region == direccion.id_region).FirstOrDefault().nom_reg;
                    accidente.DireccionEmpresa = direccion?.calle;

                    Dto.User.Item user = _userService.GetWorkerById(item.idtrabajador);
                    accidente.NombreProfesional = user?.nom_usuario;
                    accidente.CelProfesional = user?.fono_usuario.ToString();
                    accidente.RutProfesional = user?.run_usuario;
                    accidente.Apellidofesional = user?.apellido;

                    accidente.Gravedad = GetByIdGravedad(item.idgravedad).gravedad;

                    Console.WriteLine(item.idtrabajador);
                    Job job = _httpService.RequestJson<Job>(GetJobById + item.idtrabajador, HttpMethod.Get);
                    if (job != null)
                    {
                        accidente.RutTrabajador = job?.run;
                        accidente.EmpleadoNombre = job?.nombre;
                        accidente.NumeroContactoEmnpleado = job.fono_usuario;
                        accidente.CorreoEmpleado = job?.correo;
                    }
                    
                    accidente.Fechaaccidente = item?.fechaaccidente;
                    accidente.Fechaalta = item?.fechaalta;
                    accidente.Fono_emergencia = item.fono_emergencia;
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

                Console.WriteLine(JsonConvert.SerializeObject(insertAccidente));
                BackSecurity.Dto.Accidente.Accidente item = _httpService.RequestJson<BackSecurity.Dto.Accidente.Accidente>(Insert, HttpMethod.Post, JsonConvert.SerializeObject(insertAccidente));
                return (item != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
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

        public Job GetByIdEmpleado(int id)
        {
            Job job = _httpService.RequestJson<Job>(GetJobById + id, HttpMethod.Get);
            return job;
        }

        public List<Job> GetJobByIdSucursal(int id)
        {
            List<Job> jobs = _httpService.RequestJson<EmpleadoRoot>(GetJobById, HttpMethod.Get).items;
            List<Job> jobsBySucursal = new();
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
