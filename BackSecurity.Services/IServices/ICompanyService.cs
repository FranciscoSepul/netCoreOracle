using BackSecurity.Dto.Company;
using BackSecurity.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Services.IServices
{
    public interface ICompanyService
    {
        bool Create(CompanyCreate company);
        bool Update(CompanyUpdate company);
        bool Disable(CompanyUpdate company);
        List<Dto.Company.Company> CompanyList ();
        Company GetCompanyById (int id);
        Dto.Company.Item GetCompanyByName(string id);
    }
}
