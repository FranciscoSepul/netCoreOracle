using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackSecurity.Dto.Activity;

namespace BackSecurity.Services.IServices
{
    public interface IActividadesService
    {
        List<Dto.Activity.ActivityList> List ();
        List<BackSecurity.Dto.Tema.Item> ListTema();
        List<BackSecurity.Dto.Implementos.Item> ListImplementos();
        bool Create(ActivityCreate activity);
        /*
        bool Update(CompanyUpdate company);
        bool Disable(CompanyUpdate company);
        
        List<Dto.Company.Company> ListNotDisable ();
        Company GetById (int id);
        Dto.Company.Item GetByName(string id);*/
    }
}
