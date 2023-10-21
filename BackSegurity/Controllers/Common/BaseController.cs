
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BackSecurity.Controllers.Common
{
    [ApiController]
    public abstract class BaseController : Controller
    {


        protected string GetAuthorization()
        {
            return Request.Headers["Authorization"];
        }
        protected string GetToken()
        {
            string authorization = Request.Headers["Authorization"];
            if (authorization != null)
            {
                string[] parts = authorization.Split(" ");
                return parts[1];
            }
            return null;
        }

        protected bool HasToken()
        {
            return GetToken() != null;
        }

        protected long GetRut()
        {
            return long.Parse(HttpContext.User.Claims.Where(c => c.Type == "rut").First().Value);
        }

        protected string GetRutPlain()
        {
            string rutNumber = HttpContext.User.Claims.Where(c => c.Type == "rut").First().Value;
            string dv = HttpContext.User.Claims.Where(c => c.Type == "dv").First().Value;
            return $"{rutNumber}-{dv}";
        }

        protected int GetUserId()
        {
            return int.Parse(HttpContext.User.Claims.Where(c => c.Type == "userId").First().Value);
        }

        protected List<string> GetBranchs()
        {
            return HttpContext.User.Claims.Where(c => c.Type == "branch").Select(c => c.Value).ToList();
        }

        protected string GetCompany()
        {
            return HttpContext.User.Claims.Where(c => c.Type == "company").First().Value;
        }

        protected string GetBranchDefault()
        {
            return HttpContext.User.Claims.Where(c => c.Type == "branchDefault").First().Value;
        }
        protected string GetUserName()
        {
            return HttpContext.User.Claims.Where(c => c.Type == "username").First().Value;
        }
    }
}

