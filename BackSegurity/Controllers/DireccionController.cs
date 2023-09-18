
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
            Dto.Company.Item company= _companyService.GetComunaById(id);
            return Ok(company);
        }
        [HttpGet("GetAllRegion")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllRegion()
        {
            List<Dto.Region.Item> regions = _companyService.DireccionList();
            return Ok(regions);
        }

        
    }
}
