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
using BackSecurity.Dto.Visita;
using BackSecurity.Dto.TipoVisita;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace BackSecurity.Services.Services
{
    public class VisitasService : IVisitasService
    {
        private readonly IConfiguration _config;
        private readonly IHttpService _httpService;
        private readonly IDireccionService _direccionService;
        public string GetAllAsesoria = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/visita?limit=10000";
        public string _GetAsesoriaById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/visita/";
        public string InsertAsesoria = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/visita/";
        public string TipoVisita = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/tipovisita/";
        public string GetAllCompany = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/empresa?limit=10000";
        public string GetAllUsers = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/usuario?limit=10000";

        public VisitasService(IConfiguration configuration, IHttpService httpService, IDireccionService direccionService)
        {
            _config = configuration;
            _httpService = httpService;
            _direccionService = direccionService;
        }

        public List<Visitas> AsesoriaList()
        {
            try
            {
                List<Dto.Company.Item> companys = _httpService.RequestJson<CompanyRoot>(GetAllCompany, HttpMethod.Get).items;
                List<Dto.User.Item> ProfesionalesACargo = _httpService.RequestJson<Root>(GetAllUsers, HttpMethod.Get).items;
                List<BackSecurity.Dto.TipoVisita.Item> temas = _httpService.RequestJson<TipoVisitaRoot>(TipoVisita, HttpMethod.Get).items;

                List<Dto.Visita.Item> visitas = _httpService.RequestJson<VisitasRoot>(GetAllAsesoria, HttpMethod.Get).items;
                List<Dto.Company.Company> companies = new();
                List<Visitas> ListVisitas = new();

                foreach (Dto.Visita.Item item in visitas)
                {
                    Visitas visita = new();
                    visita.id = item.id;
                    visita.idprofesionalacargo = ProfesionalesACargo.Where(x => x.id_usuario == item.idprofesionalacargo).FirstOrDefault().nom_usuario;
                    visita.idcompany = companys.Where(x => x.id_empresa == item.idcompany).FirstOrDefault().nom_empresa;
                    visita.descripcion = item.descripcion;
                    visita.fechaprogramacion = item.fechaprogramacion;
                    visita.horaprogramacion = item.horaprogramacion;
                    visita.TipoVisita = temas.Where(x => x.id == item.idtipovisita).FirstOrDefault().nombre;
                    ListVisitas.Add(visita);
                }
                return ListVisitas.OrderByDescending(x => x.id).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }

        public string stateAsesoria(Dto.Company.Item item)
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
        public Company GetAsesoriaById(int id)
        {
            try
            {
                Company company = _httpService.RequestJson<Company>(_GetAsesoriaById + id, HttpMethod.Get);
                return company;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public Dto.Company.Item GetAsesoriaByName(string id)
        {
            List<Dto.Company.Item> companys = _httpService.RequestJson<CompanyRoot>(GetAllAsesoria, HttpMethod.Get).items;
            Dto.Company.Item company = companys.FirstOrDefault(x => x.nom_empresa == id);
            return company;
        }

        public bool Create(VisitaInsert company)
        {
            try
            {
                Console.WriteLine("en insert ");
                int visitas = _httpService.RequestJson<VisitasRoot>(GetAllAsesoria, HttpMethod.Get).items.OrderByDescending(x => x.id).FirstOrDefault().id;
                Dto.Visita.Item visita = new();
                visita.id = visitas+1;
                visita.idprofesionalacargo=company.idprofesionalacargo;
                visita.idcompany=company.idcompany;
                visita.isdelete=0;
                visita.fechaprogramacion=company.fechaprogramacion.ToString();
                visita.horaprogramacion=company.horaprogramacion;
                visita.descripcion=company.descripcion;
                visita.idtipovisita=company.idTipo;
                Console.WriteLine(JsonConvert.SerializeObject(visita));
                Dto.Visita.Item item = _httpService.RequestJson<Dto.Visita.Item>(InsertAsesoria, HttpMethod.Post, JsonConvert.SerializeObject(visita));
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
                CompanyInsert companyById = _httpService.RequestJson<CompanyInsert>(_GetAsesoriaById + company.id_empresa, HttpMethod.Get);

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
                BackSecurity.Dto.User.Item item = _httpService.RequestJson<BackSecurity.Dto.User.Item>(InsertAsesoria + company.id_empresa, HttpMethod.Put, JsonConvert.SerializeObject(companyById));
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
            CompanyInsert companyById = _httpService.RequestJson<CompanyInsert>(_GetAsesoriaById + company.id_empresa, HttpMethod.Get);
            #region Update company
            companyById.isdelete = (company.isdelete != companyById.isdelete) ? company.isdelete : 0;
            BackSecurity.Dto.User.Item item = _httpService.RequestJson<BackSecurity.Dto.User.Item>(InsertAsesoria + company.id_empresa, HttpMethod.Put, JsonConvert.SerializeObject(companyById));
            #endregion
            return (item != null);
        }

        public List<Company> AsesoriaListNotDisable()
        {
            try
            {
                List<Dto.Company.Item> companys = _httpService.RequestJson<CompanyRoot>(GetAllAsesoria, HttpMethod.Get).items;
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
                    company.eliminado = stateAsesoria(item);
                    company.fechaCreacion = item.fechaCreacion;
                    company.haxColor = (stateAsesoria(item) != "Activo") ? "#FF0000" : "#00A653";
                    company.Region = direccion.id_region;
                    company.Comuna = direccion.id_comuna;
                    company.Direccion = $"{direccion.calle}  {direccion.numeracion}";
                    company.IsDelete = (stateAsesoria(item) != "Activo") ? 1 : 0;
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

        public List<Dto.TipoVisita.Item> GetAllVisitas()
        {
            try
            {
                List<BackSecurity.Dto.TipoVisita.Item> temas = _httpService.RequestJson<TipoVisitaRoot>(TipoVisita, HttpMethod.Get).items;
                return temas.OrderBy(x => x.id).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }
    }
}
