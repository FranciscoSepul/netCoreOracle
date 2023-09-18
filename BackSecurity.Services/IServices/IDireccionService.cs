using BackSecurity.Dto.Company;
using BackSecurity.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Services.IServices
{
    public interface IDireccionService
    {
        List<Dto.Region.Item> DireccionList ();
        Company GetComunaById (int id);
    }
}
