using BackSecurity.Dto.Dto;
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

namespace BackSecurity.Services.Services
{
    public class DireccionService : IDireccionService
    {
        private readonly string spAppTbLogoSearch = "spAppTbLogoSearch";
        private readonly IConfiguration _config;
        private readonly ILogService _logService;

        public DireccionService( ILogService logService, IConfiguration configuration)
        {
            _logService = logService;
            _config = configuration;
        }

        public Task<bool> DeleteLogo(int id, string user)
        {
            throw new NotImplementedException();
        }

        public Task<LogoList> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<LogoDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(LogoDto logo, string UserCreate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutLogo(int id, LogoDto logoDto, string UserCreate)
        {
            throw new NotImplementedException();
        }
    }
}
