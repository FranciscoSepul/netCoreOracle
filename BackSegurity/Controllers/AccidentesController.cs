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
using BackSecurity.Dto.Accidente;
using BackSecurity.Dto.Empleado;

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
            return Ok(_AccidentesService.AccidenteById(id));
        }

        [HttpGet("GetAllAccidents")]
        [AllowAnonymous]
        public IActionResult GetAllAccidents()
        {
            try
            {
                List<Accidente> company = _AccidentesService.List();
                return Ok(company.OrderByDescending(x=>x.Id).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.StackTrace);
            }

        }
        [HttpGet("GetAllTipoAccidentes")]
        [AllowAnonymous]
        public IActionResult GetAllTipoAccidents()
        {
            try
            {
                List<Dto.TipoAccidente.Item> tipo = _AccidentesService.GetAllTipoAccidente();
                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.StackTrace);
            }

        }
        [HttpGet("GetAllGravedad")]
        [AllowAnonymous]
        public IActionResult GetAllGravedad()
        {
            List<Dto.Gravedad.Item> gravedad = _AccidentesService.GetAllGravedad();
            return Ok(gravedad);
        }

        [HttpGet("GetAllMotivoAsesoria")]
        [AllowAnonymous]
        public IActionResult GetAllMotivoAsesoria()
        {
            return Ok(_AccidentesService.GetAllMotivoAsesoria());
        }

        [HttpGet("GetAllAsesoria")]
        [AllowAnonymous]
        public IActionResult GetAllAsesoria()
        {
            return Ok(_AccidentesService.GetAllAsesoria());
        }

        [HttpPost("CreateAsesoria")]
        [AllowAnonymous]
        public IActionResult CreateAsesoria([FromBody] BackSecurity.Dto.Asesoria.AsesoriaInsert insert)
        {
            Console.WriteLine("en insert 1");
            return  Ok(_AccidentesService.InsertAsesoria(insert));
        }

        [HttpGet("GetAllTipoAsesoria")]
        [AllowAnonymous]
        public IActionResult GetAllTipoAsesoria()
        {
            return Ok(_AccidentesService.GetAllTipoAsesoria());
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] CreateAccidente accidenteInsert)
        {
            Console.WriteLine("en insert");
            bool response = _AccidentesService.Create(accidenteInsert);
            return (response != false) ? Ok() : BadRequest();
        }

        [HttpPut("Disable")]
        [AllowAnonymous]
        public IActionResult Disable([FromBody] CompanyUpdate companyCreate)
        {
            bool user = _AccidentesService.Disable(companyCreate);
            return Ok(user);
        }
        [HttpGet("GetAllJobId")]
        [AllowAnonymous]
        public IActionResult GetAllJobId(int id)
        {
            Job tipo = _AccidentesService.GetByIdEmpleado(id);
            return Ok(tipo);
        }
        [HttpGet("LugarDelAccidentes")]
        [AllowAnonymous]
        public IActionResult LugarDelAccidentes()
        {
            List<Dto.CategoriaOcupacional.Item> tipo = _AccidentesService.LugarDelAccidentes();
            return Ok(tipo);
        }
        [HttpGet("GetAllMediosDePruebas")]
        [AllowAnonymous]
        public IActionResult GetAllMediosDePruebas()
        {
            List<Dto.CategoriaOcupacional.Item> tipo = _AccidentesService.MediosDePruebas();
            return Ok(tipo);
        }
        [HttpGet("AccidentById")]
        [AllowAnonymous]
        public IActionResult AccidentById(int id)
        {
            Accidente accidente = _AccidentesService.AccidenteById(id);
            return Ok(accidente);
        }
        [HttpGet("GetJobByCompany")]
        [AllowAnonymous]
        public IActionResult GetJobByCompany(int id)
        {
            List<Job> gravedad = _AccidentesService.GetJobByIdSucursal(id);
            return Ok(gravedad);
        }
    }
}
