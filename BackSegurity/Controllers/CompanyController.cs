using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using BackSecurity.Dto.User;
using BackSecurity.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using BackSecurity.Controllers.Common;
using BackSecurity.Dto.Authentication;
using BackSecurity.Constants.Constants;
using BackSecurity.Dto.Company;

namespace BackSecurity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetCompanyById")]
        [AllowAnonymous]
        public IActionResult GetCompanyById(int id)
        {
            Dto.Company.Company company = _companyService.GetCompanyById(id);
            return Ok(company);
        }

        [HttpGet("GetCompanyByName")]
        [AllowAnonymous]
        public IActionResult GetCompanyByName(string id)
        {
            Dto.Company.Item company = _companyService.GetCompanyByName(id);
            return Ok(company);
        }

        [HttpGet("GetCompanyFactura")]
        [AllowAnonymous]
        public IActionResult GetCompanyFactura(string id, int desde)
        {
            Factura factura = _companyService.GetCompanyFactura(id, desde);
            return Ok(factura);
        }

        [HttpGet("GetFacturaById")]
        [AllowAnonymous]
        public IActionResult GetCompanyFactura(int id)
        {
            BackSecurity.Dto.Factura.FacturaId factura = _companyService.GetFacturaById(id);
            return Ok(factura);
        }

        [HttpGet("GetCompanyOperaciones")]
        [AllowAnonymous]
        public IActionResult GetCompanyOperaciones(string id, int desde)
        {
            Console.WriteLine("aca ");
            Operaciones factura = _companyService.GetCompanyOperaciones(id, desde);
            return Ok(factura);
        }

        [HttpGet("GetAllCompany")]
        [AllowAnonymous]
        public IActionResult GetAllCompany()
        {
            List<Dto.Company.Company> company = _companyService.CompanyList();
            return Ok(company);
        }

        [HttpGet("GetAllCompanyNotDisable")]
        [AllowAnonymous]
        public IActionResult GetAllCompanyNotDisable()
        {
            List<Dto.Company.Company> company = _companyService.CompanyListNotDisable();
            return Ok(company);
        }

        [HttpGet("GetAllFacturas")]
        [AllowAnonymous]
        public IActionResult GetAllFacturas()
        {
            return Ok(_companyService.GetAllFacturas());
        }
        [HttpGet("ListPropiedadEmpresa")]
        [AllowAnonymous]
        public IActionResult ListPropiedadEmpresa()
        {
            return Ok(_companyService.ListPropiedadEmpresa());
        }
        [HttpGet("ListTipoEmpresa")]
        [AllowAnonymous]
        public IActionResult ListTipoEmpresa()
        {
            return Ok(_companyService.ListTipoEmpresa());
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] CompanyCreate companyInsert)
        {
            bool response = _companyService.Create(companyInsert);
            return (response != false) ? Ok() : BadRequest();
        }

        [HttpGet("FactureByCompany")]
        [AllowAnonymous]
        public IActionResult FactureByCompany(int id)
        {
            bool factura = _companyService.FacturByCompany(id);
            return Ok(factura);
        }

        [HttpPut("Update")]
        [AllowAnonymous]
        public IActionResult Update([FromBody] CompanyUpdate companyInsert)
        {
            bool user = _companyService.Update(companyInsert);
            return Ok(user);
        }

        [HttpPut("Disable")]
        [AllowAnonymous]
        public IActionResult Disable([FromBody] CompanyUpdate companyCreate)
        {
            bool user = _companyService.Disable(companyCreate);
            return Ok(user);
        }

    }
}
