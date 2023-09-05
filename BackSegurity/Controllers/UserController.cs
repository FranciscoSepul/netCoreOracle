﻿using System.Net.Http.Headers;
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
            string response = _userService.Login(user, pass);
            if (response != " " && response != null)
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
            Root user = _userService.Users();
            return Ok(user);
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> ListUsers()
        {
            Root user = _userService.Users();
            return Ok(user);
        }
        
        [HttpPut("Update")]
        [AllowAnonymous]
        public async Task<IActionResult> ListUsers()
        {
            Root user = _userService.Users();
            return Ok(user);
        }
    }
}
