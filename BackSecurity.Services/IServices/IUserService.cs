using BackSecurity.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Services.IServices
{
    public interface IUserService
    {
        string Login(string user, string pass);
        bool Create(User user);
        List<User> Users ();
    }
}
