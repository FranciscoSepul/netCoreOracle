using BackSecurity.Dto.Company;
using BackSecurity.Dto.User;
using BackSecurity.Dto.Comuna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackSecurity.Dto.Direccion;

namespace BackSecurity.Services.IServices
{
    public interface IDireccionService
    {
        List<Dto.Region.Item> DireccionList ();
        List<Dto.Comuna.Item> GetComunaById (int id);
        int Create(Dto.Direccion.DireccionInsert user);
        int Update(Dto.Direccion.DireccionInsert user);
        Dto.Direccion.Item GetDireccionById(int iddireccion);
    }
}
