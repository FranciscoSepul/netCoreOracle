
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

    public class AccidentesController : BaseController
    {
        private readonly IAccidentesService _AccidentesService;

        public AccidentesController(IAccidentesService AccidentesService)
        {
            _AccidentesService = AccidentesService;
        }

        [HttpGet("GetAccidentsById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAccidentsById(int id)
        {
            Company company = _AccidentesService.GetCompanyById(id);
            return Ok(company);
        }
        [HttpGet("GetAllAccidents")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAccidents()
        {
            List<Dto.Company.Company> company = _AccidentesService.CompanyList();
            return Ok(company);
        }
        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CompanyCreate companyInsert)
        {
            bool response = _AccidentesService.Create(companyInsert);
            return (response !=false)? Ok():BadRequest();
        }
        
        [HttpPut("Update")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] CompanyUpdate companyInsert)
        {
            bool user = _AccidentesService.Update(companyInsert);
            return Ok(user);
        }

        [HttpPut("Disable")]
        [AllowAnonymous]
        public async Task<IActionResult> Disable([FromBody] CompanyUpdate companyCreate)
        {
            bool user = _AccidentesService.Disable(companyCreate);
            return Ok(user);
        }
        
    }
}
