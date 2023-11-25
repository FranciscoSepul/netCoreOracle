
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

    public class Hangfire : BaseController
    {

        public Hangfire()
        {

        }

       
    }
}
