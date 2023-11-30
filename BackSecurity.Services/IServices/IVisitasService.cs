using BackSecurity.Dto.Company;
using BackSecurity.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Services.IServices
{
    public interface IVisitasService
    {
        bool Create(CompanyCreate company);
        bool Update(CompanyUpdate company);
        bool Disable(CompanyUpdate company);
        List<Dto.Visita.Item> AsesoriaList ();
        List<Dto.TipoVisita.Item> GetAllVisitas();
        List<Dto.Company.Company> AsesoriaListNotDisable ();
        Company GetAsesoriaById (int id);
        Dto.Company.Item GetAsesoriaByName(string id);
    }
}
