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
using BackSecurity.Dto.Comuna;
using BackSecurity.Dto.Region;
using BackSecurity.Dto.Direccion;


namespace BackSecurity.Services.Services
{
    public class DireccionService : IDireccionService
    {
        private readonly IConfiguration _config;
        private readonly IHttpService _httpService;
        public string GetAllRegion = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/region?limit=10000";
        public string StrGetComuna = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/comuna?limit=10000";
        public string StrGetDireccionById = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/direccion/";
        public string StrGetDireccionAll = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/direccion?limit=10000";
        public string InsertDireccionStr = "https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/direccion/";
        
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

        public Dto.Direccion.Item GetDireccionById(int id)
        {
            try
            {
                Dto.Direccion.Item direccion = _httpService.RequestJson<BackSecurity.Dto.Direccion.Item>(StrGetDireccionById + id + "?limit=10000", HttpMethod.Get);
                return direccion;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Dto.Comuna.Item> GetComunaById(int id)
        {
            try
            {
                List<Dto.Comuna.Item> comunas = _httpService.RequestJson<ComunaRoot>(StrGetComuna, HttpMethod.Get).items;
                List<Dto.Comuna.Item> comunasByRegion = new();
                foreach (Dto.Comuna.Item comuna in comunas)
                {
                    if (comuna.id_region == id)
                    {
                        comunasByRegion.Add(comuna);
                    }
                }
                return comunasByRegion;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public int Create(DireccionInsert direccion)
        {
             try
            {
                DirectionInsertOracle directionInsertOracle=new();
                BackSecurity.Dto.Direccion.DireccionRoot direccions = _httpService.RequestJson<BackSecurity.Dto.Direccion.DireccionRoot>(StrGetDireccionAll, HttpMethod.Get);
                directionInsertOracle.id_direccion=direccions.items.Count()+1;
                directionInsertOracle.calle=direccion.calle;
                directionInsertOracle.numeracion=direccion.numeracion;
                directionInsertOracle.id_region=direccion.id_region;
                directionInsertOracle.id_comuna=direccion.id_comuna;
                BackSecurity.Dto.Direccion.Item item = _httpService.RequestJson< BackSecurity.Dto.Direccion.Item>(InsertDireccionStr, HttpMethod.Post, JsonConvert.SerializeObject(directionInsertOracle));
                return item.id_direccion;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(DireccionInsert direccion)
        {
              try
            {
                DirectionInsertOracle directionInsertOracle=new();
                directionInsertOracle.id_direccion = direccion.id_direccion;
                directionInsertOracle.calle=direccion.calle;
                directionInsertOracle.numeracion=direccion.numeracion;
                directionInsertOracle.id_region=direccion.id_region;
                directionInsertOracle.id_comuna=direccion.id_comuna;
                BackSecurity.Dto.Direccion.Item item = _httpService.RequestJson< BackSecurity.Dto.Direccion.Item>(InsertDireccionStr+direccion.id_direccion, HttpMethod.Put, JsonConvert.SerializeObject(directionInsertOracle));
                return item.id_direccion;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
