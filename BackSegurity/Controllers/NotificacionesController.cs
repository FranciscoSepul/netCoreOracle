
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
using BackSecurity.Dto.TipoNotificacion;

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
        ///public async Task<IActionResult> GetNotificationById(int id)
       // {
        //    CompanyInsert company = _notificacionesService.GetById(id);
         //   return Ok(company);
       // }

        [HttpGet("GetAllNotification")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllNotification()
        {
            List<NotificacionesList> company = _notificacionesService.List();
            return Ok(company);
        }
        
        [HttpGet("GetAllTipoNotification")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllTipoNotification()
        {
            List<TipoNotificacionRoot> dirigida = _notificacionesService.ListTipoNotificacion();
            return Ok(dirigida);
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] NotificacionesCreate notificaciones)
        {
            Console.WriteLine("en el create");
            bool response = _notificacionesService.CreateNotif(notificaciones,null);
            return (response !=false)? Ok():BadRequest();
        }
        
    }
}
