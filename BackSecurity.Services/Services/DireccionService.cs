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
using BackSecurity.Dto.Region;

namespace BackSecurity.Services.Services
{
    public class DireccionService : IDireccionService
    {
        private readonly IConfiguration _config;
        private readonly IHttpService _httpService;
        public string GetAllRegion = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/region/";
        public string StrGetComunaById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/empresa/";
        public DireccionService(IConfiguration configuration, IHttpService httpService)
        {
            _config = configuration;
            _httpService = httpService;
        }

        public List<Dto.Region.Item> DireccionList()
        {
            try
            {
                List<Dto.Region.Item> regions = _httpService.RequestJson<RegionRoot>(GetAllRegion, HttpMethod.Get).items;
                return regions;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Company GetComunaById(int id)
        {
            try
            {

                Company company = _httpService.RequestJson<Company>(StrGetComunaById + id, HttpMethod.Get);
                return company;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
