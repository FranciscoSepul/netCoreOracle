
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
using BackSecurity.Dto.Meses;

namespace BackSecurity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DireccionController : BaseController
    {
        private readonly IDireccionService _DireccionService;

        public DireccionController(IDireccionService DireccionService)
        {
            _DireccionService = DireccionService;
        }

        [HttpGet("GetComunaByRegion")]
        [AllowAnonymous]
        public async Task<IActionResult> GetComunaByRegion(int id)
        {
            List<Dto.Comuna.Item> comuna = _DireccionService.GetComunaById(id);
            return Ok(comuna);
        }

        [HttpGet("GetDireccionById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDireccionById(int id)
        {
            BackSecurity.Dto.Direccion.Item comuna = _DireccionService.GetDireccionById(id);
            return Ok(comuna);
        }

        [HttpGet("GetAllRegion")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllRegion()
        {
            List<Dto.Region.Item> regions = _DireccionService.DireccionList();
            return Ok(regions);
        }
        [HttpGet("GetAllMeses")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllMeses()
        {
            List<Meses> meses =new();
            
            Meses meses1 = new();
            meses1.Mes="Enero";
            meses1.Id=1;
            meses.Add(meses1);
            Meses meses2 = new();
            meses2.Mes="Febrero";
            meses2.Id=2;
            meses.Add(meses2);
            Meses meses3 = new();
            meses3.Mes="Marzo";
            meses3.Id=3;
            meses.Add(meses3);
            Meses meses4 = new();
            meses4.Mes="Abril";
            meses4.Id=4;
            meses.Add(meses4);
            Meses meses5 = new();
            meses5.Mes="Mayo";
            meses5.Id=5;
            meses.Add(meses5);
            Meses meses6 = new();
            meses6.Mes="Junio";
            meses6.Id=6;
            meses.Add(meses6);
            Meses meses7 = new();
            meses7.Mes="Julio";
            meses7.Id=7;
            meses.Add(meses7);
            Meses meses8 = new();
            meses8.Mes="Agosto";
            meses8.Id=8;
            meses.Add(meses8);
            Meses meses9 = new();
            meses9.Mes="Septiembre";
            meses9.Id=9;
            meses.Add(meses9);
            Meses meses10 = new();
            meses10.Mes="Octubre";
            meses10.Id=10;
            meses.Add(meses10);
            Meses meses11 = new();
            meses11.Mes="Noviembre";
            meses11.Id=11;
            meses.Add(meses11);
            Meses meses12 = new();
            meses12.Mes="Diciembre";
            meses12.Id=12;
            meses.Add(meses12);
            return Ok(meses);
        }

    }
}
