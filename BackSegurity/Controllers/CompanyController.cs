
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
        public async Task<IActionResult> GetCompanyById(int id)
        {
            Dto.Company.Company company = _companyService.GetCompanyById(id);
            return Ok(company);
        }
        [HttpGet("GetCompanyByName")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCompanyByName(string id)
        {
            Dto.Company.Item company = _companyService.GetCompanyByName(id);
            return Ok(company);
        }

        [HttpGet("GetCompanyFactura")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCompanyFactura(string id, string desde, string hasta)
        {
            Factura factura = _companyService.GetCompanyFactura(id, desde, hasta);
            return Ok(factura);
        }
        [HttpGet("GetCompanyOperaciones")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCompanyOperaciones(string id, string desde, string hasta)
        {
            Operaciones factura = _companyService.GetCompanyOperaciones(id, desde, hasta);
            return Ok(factura);
        }

        [HttpGet("GetAllCompany")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCompany()
        {
            List<Dto.Company.Company> company = _companyService.CompanyList();
            return Ok(company);
        }
        [HttpGet("GetAllCompanyNotDisable")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCompanyNotDisable()
        {
            List<Dto.Company.Company> company = _companyService.CompanyListNotDisable();
            return Ok(company);
        }
        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CompanyCreate companyInsert)
        {
            bool response = _companyService.Create(companyInsert);
            return (response != false) ? Ok() : BadRequest();
        }

        [HttpPut("Update")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] CompanyUpdate companyInsert)
        {
            bool user = _companyService.Update(companyInsert);
            return Ok(user);
        }

        [HttpPut("Disable")]
        [AllowAnonymous]
        public async Task<IActionResult> Disable([FromBody] CompanyUpdate companyCreate)
        {
            bool user = _companyService.Disable(companyCreate);
            return Ok(user);
        }

    }
}
