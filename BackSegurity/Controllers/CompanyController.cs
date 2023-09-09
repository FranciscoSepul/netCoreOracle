
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

        //[HttpGet("List")]
        //[AllowAnonymous]
        //public async Task<IActionResult> ListUsers()
       // {
        //    List<Users> user = _userService.Users();
        //    return Ok(user);
       // }

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
            List<Dto.Company.Item> company = _companyService.CompanyList();
            return Ok(company);
        }

       // [HttpPost("Create")]
        //[AllowAnonymous]
       // public async Task<IActionResult> Create([FromBody] UserInsert userInsert)
      //  {
      //       Console.WriteLine("en insert ");
      //      bool response = _userService.Create(userInsert);
      //      return (response !=false)? Ok():BadRequest();
      //  }
        
       // [HttpPut("Update")]
       // [AllowAnonymous]
       // public async Task<IActionResult> Update()
       // {
       //     List<Users> user = _userService.Users();
       //     return Ok(user);
       // }
        
    }
}
