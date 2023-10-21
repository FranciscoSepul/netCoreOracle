
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


    }
}
