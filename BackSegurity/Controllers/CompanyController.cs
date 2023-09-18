
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
            Company company = _companyService.GetCompanyById(id);
            return Ok(company);
        }
        [HttpGet("GetCompanyByName")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCompanyByName(string id)
        {
            Dto.Company.Item company= _companyService.GetCompanyByName(id);
            return Ok(company);
        }
        [HttpGet("GetAllCompany")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCompany()
        {
            List<Dto.Company.Company> company = _companyService.CompanyList();
            return Ok(company);
        }

        
    }
}
