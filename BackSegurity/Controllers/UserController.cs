using System.Diagnostics.Contracts;

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
using BackSecurity.Dto.Funcion;

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
            List<Users> user = _userService.Users();
            return Ok(user);
        }

        [HttpGet("ListFunction")]
        [AllowAnonymous]
        public async Task<IActionResult> ListFunction()
        {
            List<BackSecurity.Dto.Funcion.Item> user = _userService.ListFunction();
            return Ok(user);
        }

        [HttpGet("GetWorkerInfo")]
        [AllowAnonymous]
        public async Task<IActionResult> GetWorkerInfo(string UserName)
        {
            BackSecurity.Dto.User.Item user = _userService.GetWorker(UserName);
            return Ok(user);
        }

        [HttpGet("GetUserById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdUsers(int id)
        {
            List<Users> user = _userService.Users();
            return Ok(user);
        }

        [HttpGet("GetTipoContrato")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTipoContrato()
        {
            List<ContractType> contract =new();
            ContractType contractType = new();
            contractType.contract="Indefinido";
            contract.Add(contractType);
            ContractType contractTypeB = new();
            contractTypeB.contract="Bono Turno";
            contract.Add(contractTypeB);
            ContractType contractTypeA = new();
            contractTypeA.contract="Aprendizaje";
            contract.Add(contractTypeA);
            ContractType contractTypeT = new();
            contractTypeT.contract="Temporal";
            contract.Add(contractTypeT);
            ContractType contractTypeO = new();
            contractTypeO.contract="Ocasional";
            contract.Add(contractTypeO);
            ContractType contractTypeP = new();
            contractTypeP.contract="Plazo Fijo";
            contract.Add(contractTypeP);
            return Ok(contract);
        }
        [HttpGet("GetPaises")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPaises()
        {
            List<ContractType> contract =new();
            ContractType contractType = new();
            contractType.contract="Chile";
            contract.Add(contractType);
            ContractType contractTypeB = new();
            contractTypeB.contract="Colombia";
            contract.Add(contractTypeB);
            ContractType contractTypeA = new();
            contractTypeA.contract="Peru";
            contract.Add(contractTypeA);
            ContractType contractTypeT = new();
            contractTypeT.contract="Uruguai";
            contract.Add(contractTypeT);
            ContractType contractTypeO = new();
            contractTypeO.contract="Bolivia";
            contract.Add(contractTypeO);
            ContractType contractTypeP = new();
            contractTypeP.contract="Mexico";
            contract.Add(contractTypeP);
            return Ok(contract);
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] UserInsert userInsert)
        {
            bool response = _userService.Create(userInsert);
            return (response !=false)? Ok():BadRequest();
        }
        
        [HttpPut("Update")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] UserUpdate userInsert)
        {
            Console.WriteLine("en update ");
            bool user = _userService.Update(userInsert);
            return Ok(user);
        }

        [HttpPut("Disable")]
        [AllowAnonymous]
        public async Task<IActionResult> Disable([FromBody] UserDisable userInsert)
        {
            bool user = _userService.Disable(userInsert);
            return Ok(user);
        }

        
    }
}
