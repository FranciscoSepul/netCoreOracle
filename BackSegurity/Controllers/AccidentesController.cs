
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
using BackSecurity.Dto.Accidente;

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
        public IActionResult GetAccidentsById(int id)
        {
            Company company = _AccidentesService.GetById(id);
            return Ok(company);
        }
        [HttpGet("GetAllAccidents")]
        [AllowAnonymous]
        public IActionResult GetAllAccidents()
        {
            List<Accidente> company = _AccidentesService.List();
            return Ok(company);
        }
        [HttpGet("GetAllTipoAccidentes")]
        [AllowAnonymous]
        public IActionResult GetAllTipoAccidents()
        {
            List<Dto.TipoAccidente.Item> tipo = _AccidentesService.GetAllTipoAccidente();
            return Ok(tipo);
        }
        [HttpGet("GetAllGravedad")]
        [AllowAnonymous]
        public IActionResult GetAllGravedad()
        {
             List<Dto.Gravedad.Item> gravedad = _AccidentesService.GetAllGravedad();
            return Ok(gravedad);
        }
        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] CreateAccidente companyInsert)
        {
            bool response = _AccidentesService.Create(companyInsert);
            return (response != false) ? Ok() : BadRequest();
        }

        [HttpPut("Update")]
        [AllowAnonymous]
        public IActionResult Update([FromBody] CompanyUpdate companyInsert)
        {
            bool user = _AccidentesService.Update(companyInsert);
            return Ok(user);
        }

        [HttpPut("Disable")]
        [AllowAnonymous]
        public IActionResult Disable([FromBody] CompanyUpdate companyCreate)
        {
            bool user = _AccidentesService.Disable(companyCreate);
            return Ok(user);
        }

    }
}
