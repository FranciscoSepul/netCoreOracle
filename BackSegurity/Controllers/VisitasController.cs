
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
using BackSecurity.Dto.Visita;

namespace BackSecurity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VisitasController : BaseController
    {
        private readonly IVisitasService _VisitasService;

        public VisitasController(IVisitasService VisitasService)
        {
            _VisitasService = VisitasService;
        }

        [HttpGet("GetVisitasById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetVisitasById(int id)
        {
            Company company = _VisitasService.GetAsesoriaById(id);
            return Ok(company);
        }
        [HttpGet("GetVisitasByName")]
        [AllowAnonymous]
        public async Task<IActionResult> GetVisitasByName(string id)
        {
            Dto.Company.Item company= _VisitasService.GetAsesoriaByName(id);
            return Ok(company);
        }
        [HttpGet("GetAllVisitas")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllVisitas()
        {
            List<Dto.Visita.Visitas> company = _VisitasService.AsesoriaList();
            return Ok(company);
        }
        [HttpGet("GetAllTipoVisitas")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllTipoVisitas()
        {            
            List<Dto.TipoVisita.Item> company = _VisitasService.GetAllVisitas();
            return Ok(company);
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] VisitaInsert companyInsert)
        {
            Console.Write("en insert");
            bool response = _VisitasService.Create(companyInsert);
            return (response !=false)? Ok():BadRequest();
        }
        
        [HttpPut("Update")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] CompanyUpdate companyInsert)
        {
            bool user = _VisitasService.Update(companyInsert);
            return Ok(user);
        }

        [HttpPut("Disable")]
        [AllowAnonymous]
        public async Task<IActionResult> Disable([FromBody] CompanyUpdate companyCreate)
        {
            bool user = _VisitasService.Disable(companyCreate);
            return Ok(user);
        }
        
    }
}
