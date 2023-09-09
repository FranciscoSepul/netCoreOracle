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
        public List<Dto.Company.Item> CompanyList()
        {
            try
            {
               List<Dto.Company.Item> company = _httpService.RequestJson<CompanyRoot>(GetAllCompany, HttpMethod.Get).items;
               return company;
            }
            catch (Exception Exception)
            {
                return null;
            }

        }
        public Company GetCompanyById(int id)
        {
            try
            {

                Company company = _httpService.RequestJson<Company>(_GetCompanyById+id, HttpMethod.Get);
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
