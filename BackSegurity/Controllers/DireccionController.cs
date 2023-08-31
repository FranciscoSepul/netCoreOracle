using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using BackSecurity.Dto.Dto;
using BackSecurity.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using BackSecurity.Controllers.Common;
using BackSecurity.Constants.Constants;

namespace BackSecurity.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class DireccionController : BaseController
    {
        private readonly IDireccionService _direccionService;

        public DireccionController(IDireccionService direccionService)
        {
            _direccionService = direccionService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertLogo([FromBody] LogoDto logo)
        {
            Response response = new();
            if (logo != null)
            {
                // var InsertLogoResponse = await logoService.InsertLogo(logo, user);
                // if (InsertLogoResponse > 0)
                //{
                response.Codigo = "204";
                response.Estado = "Not Content";
                response.Descripcion = "Logo insertado correctamente";
                return Ok();
                // }
            }
            response.Codigo = "400";
            response.Estado = "Error";
            response.Descripcion = "Error al insertar el logo";
            return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            LogoList logos = await _direccionService.GetAll();
            if (logos != null)
            {
                return Ok(logos);
            }
            return NoContent();

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LogoDto>> GetById(int id)
        {
            LogoDto logoDto = await _direccionService.GetById(id);
            if (logoDto.Id > 0)
            {
                return logoDto;
            }
            return NotFound();
        }

        //  [HttpDelete("{id:int}")]
        // public async Task<IActionResult> DeleteLogo(int id)
        // {
        //bool responseDelete = await _direccionService.DeleteLogo(id);
        //   return responseDelete ? NoContent() : NotFound();
        // }

        // [HttpPut("{id:int}")]
        // public async Task<IActionResult> PutLogo(int id, [FromBody] LogoDto logo)
        // {
        //    string user = HasToken() ? GetUserName() : "AdminException";

        //  if (logo != null)
        // {
        // bool responseUpdate = await logoService.PutLogo(id, logo, user);
        //   return responseUpdate ? NoContent() : NotFound();
        //}
        // else return BadRequest();
        // }

    }
}
