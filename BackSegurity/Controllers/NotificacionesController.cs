
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
using BackSecurity.Dto.Notificaciones;
using BackSecurity.Dto.NotificacionDirigida;

namespace BackSecurity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class NotificacionesController : BaseController
    {
        private readonly  INotificacionesService _notificacionesService;

        public NotificacionesController(INotificacionesService notificacionesService)
        {
            _notificacionesService = notificacionesService;
        }

        //[HttpGet("GetNotificationById")]
        //[AllowAnonymous]
       // public async Task<IActionResult> GetNotificationById(int id)
        //{
        //    CompanyInsert company = _notificacionesService.GetById(id);
        //    return Ok(company);
        //}

        [HttpGet("GetAllNotification")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllNotification()
        {
            List<NotificacionesList> company = _notificacionesService.List();
            return Ok(company);
        }
        
         [HttpGet("GetAllNotificationDirigida")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllNotificationDirigida()
        {
            List<NotificaciondirigidaFirs> dirigida = _notificacionesService.ListDirigido();
            return Ok(dirigida);
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] Notificaciones notificaciones)
        {
            bool response = _notificacionesService.Create(notificaciones);
            return (response !=false)? Ok():BadRequest();
        }
        
        [HttpPut("Update")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] Notificaciones notificaciones)
        {
            bool user = _notificacionesService.Update(notificaciones);
            return Ok(user);
        }

        [HttpPut("Disable")]
        [AllowAnonymous]
        public async Task<IActionResult> Disable([FromBody] CompanyUpdate companyCreate)
        {
            bool user = _notificacionesService.Disable(companyCreate);
            return Ok(user);
        }
        
    }
}
