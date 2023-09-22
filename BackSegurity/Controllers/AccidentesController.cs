﻿
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
        private readonly ICompanyService _companyService;

        public AccidentesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetAccidentsById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAccidentsById(int id)
        {
            Company company = _companyService.GetCompanyById(id);
            return Ok(company);
        }
        [HttpGet("GetAllAccidents")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAccidents()
        {
            List<Dto.Company.Company> company = _companyService.CompanyList();
            return Ok(company);
        }
        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CompanyCreate companyInsert)
        {
            bool response = _companyService.Create(companyInsert);
            return (response !=false)? Ok():BadRequest();
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
