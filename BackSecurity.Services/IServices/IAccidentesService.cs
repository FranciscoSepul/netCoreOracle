using BackSecurity.Dto.Accidente;
using BackSecurity.Dto.Company;
using BackSecurity.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Services.IServices
{
    public interface IAccidentesService
    {
        bool Create(CreateAccidente company);
        bool Update(CompanyUpdate company);
        bool Disable(CompanyUpdate company);
        List<Accidente> List ();
        List<Dto.TipoAccidente.Item> GetAllTipoAccidente();
        List<Dto.Gravedad.Item> GetAllGravedad();
        Company GetById (int id);
    }
}
