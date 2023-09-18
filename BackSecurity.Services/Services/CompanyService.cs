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
using BackSecurity.Dto.Company;

namespace BackSecurity.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IConfiguration _config;
        private readonly IHttpService _httpService;
        public string GetAllCompany = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/empresa/";
        public string _GetCompanyById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/empresa/";
        public string InsertCompany = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/usuario/";

        public CompanyService(IConfiguration configuration, IHttpService httpService)
        {
            _config = configuration;
            _httpService = httpService;
        }

        public bool Create(Company user)
        {
            try
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<Dto.Company.Company> CompanyList()
        {
            try
            {
                List<Dto.Company.Item> companys = _httpService.RequestJson<CompanyRoot>(GetAllCompany, HttpMethod.Get).items;
                List<Dto.Company.Company> companies = new();
                foreach (Dto.Company.Item item in companys)
                {
                    Dto.Company.Company company = new()
                    {
                        nom_empresa = item.nom_empresa,
                        Rut = item.Rut,
                        DvRut = item.DvRut,
                        ImageBase64 = item.ImageBase64,
                        fechaFinContrato = item.fechaFinContrato,
                        Correo = item.Correo,
                        eliminado = stateCompany(item),
                        fechaCreacion = item.fechaCreacion,
                        haxColor = (stateCompany(item) != "Activo") ? "#FF0000" : "#00A653"
                    };
                    companies.Add(company);
                }
                return companies;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string stateCompany(Dto.Company.Item item)
        {

            string estadoBooleanCompany = (item.IsDelete != 0) ? "Desactivado" : "Activo";
            string estado = "";
            if (estadoBooleanCompany == "Activo")
            {
                estado = (DateTime.Parse(item.fechaFinContrato) > DateTime.Now.Date) ? "Activo" : "Desactivado";
            }
            else
            {
                estado = estadoBooleanCompany;
            }
            return estado;
        }
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
    }
}
