using BackSecurity.Dto.User;
using BackSecurity.Services.IServices;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackSecurity.Services.Common.ICommon;

namespace BackSecurity.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;

        public UserService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public bool Login(string user, string pass)
        {
            if (user == "manuel" && pass == "1234")
            {
                return true;
            }
            return false;

        }

        public bool Create(User user)
        {
            if (user != null)
            {
                return true;
            }
            return false;

        }

    }
}
