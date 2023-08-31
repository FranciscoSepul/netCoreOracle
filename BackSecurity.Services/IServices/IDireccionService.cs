using BackSecurity.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Services.IServices
{
    public interface IDireccionService
    {
        Task<LogoList> GetAll();
        Task<LogoDto> GetById(int id);
        Task<int> Insert(LogoDto logo,string UserCreate);
        Task<bool> PutLogo(int id, LogoDto logoDto, string UserCreate);
        Task<bool> DeleteLogo(int id, string user);
    }
}
