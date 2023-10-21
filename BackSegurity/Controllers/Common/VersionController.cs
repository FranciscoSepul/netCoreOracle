using System;
using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace BackSecurity.Controllers.Common
{
    [Route("api/[controller]")]
    public class VersionController : Controller
    {
        [HttpGet]
        public ActionResult GetVersion()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            return Ok(new
            {
                Version = fileVersionInfo.FileVersion,
                Name = fileVersionInfo.ProductName
            });
        }
    }
}

