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

namespace BackSecurity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string user, string pass)
        {
            Console.WriteLine("here 1 " + user + " " + pass);
            string response = _userService.Login(user, pass);
            if (response != "")
            {
                TokenDto token = new TokenDto();
                token.Token = response;
                return Ok(token);
            }
            return Unauthorized();

        }

        [HttpGet("List")]
        [AllowAnonymous]
        public async Task<IActionResult> ListUsers()
        {
            Console.WriteLine("here 1 ");
            List<User> users = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                User user = new User();
                user.Id = i;
                user.Nombre = "Usuario numero " + i;
                user.ApellidoPaterno ="a";
                user.ApellidoMaterno ="a";
                user.Direccion ="falsa "+i;
                user.Ciudad ="sant";
                user.Region ="metropolitana";
                user.Correo ="correoFalso123";
                user.DvRut ="3";
                user.funcion =1;
                user.Rut ="111111111";
                user.numeroContacto ="999999999";
                user.Nacionalidad ="chile";
                user.companias =1;
                users.add(user);
            }
            return Ok(users);
       }

    }
}
