﻿using BackSecurity.Dto.Company;
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
        List<Dto.Company.Company> CompanyListNotDisable ();
        Dto.Company.Company GetCompanyById (int id);
        Dto.Company.Item GetCompanyByName(string id);
        Factura GetCompanyFactura(string id,int desde);
        Operaciones GetCompanyOperaciones(string id, int desde);
        List<BackSecurity.Dto.Factura.FacturaList>  GetAllFacturas();
        bool FacturByCompany(int id);
        BackSecurity.Dto.Factura.FacturaId GetFacturaById(int id);

        List<Dto.PropiedadEmpresa.Item> ListPropiedadEmpresa();
        List<Dto.TipoEmpresa.Item> ListTipoEmpresa();
    }
}
