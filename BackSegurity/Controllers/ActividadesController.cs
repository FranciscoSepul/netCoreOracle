
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
using BackSecurity.Dto.Activity;

namespace BackSecurity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ActividadesController : BaseController
    {
        private readonly IActividadesService _ActividadesService;

        public ActividadesController(IActividadesService ActividadesService)
        {
            _ActividadesService = ActividadesService;
        }
         [HttpGet("GetAllActivity")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllActivity()
        {
            List<Dto.Activity.ActivityList> activi = _ActividadesService.List();
            return Ok(activi);
        }
        [HttpGet("GetAllTemas")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllTemas()
        {
            List<Dto.Tema.Item> tema = _ActividadesService.ListTema();
            return Ok(tema);
        }

           [HttpGet("GetAllImplementos")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllImplementos()
        {
            List<Dto.Implementos.Item> implementos = _ActividadesService.ListImplementos();
            return Ok(implementos);
        }

        [HttpGet("GetActivityById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetActivityById(int id)
        {
            return Ok(_ActividadesService.GetActivityById(id));
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] ActivityCreate companyInsert)
        {
            bool response = _ActividadesService.Create(companyInsert);
            return (response !=false)? Ok():BadRequest();
        }
        /*
        [HttpPut("Update")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] CompanyUpdate companyInsert)
        {
            bool user = _ActividadesService.Update(companyInsert);
            return Ok(user);
        }
        
        [HttpPut("Disable")]
        [AllowAnonymous]
        public async Task<IActionResult> Disable([FromBody] CompanyUpdate companyCreate)
        {
            bool user = _companyService.Disable(companyCreate);
            return Ok(user);
        }
        */
        
    }
}
