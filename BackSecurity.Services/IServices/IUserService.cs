using BackSecurity.Dto.Funcion;
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
        bool Create(UserInsert user);
        List<Users> Users ();
        bool Update(UserUpdate user);
        bool Disable(UserDisable user);
        BackSecurity.Dto.User.Item GetWorker (string UserName);
        List<BackSecurity.Dto.Funcion.Item> ListFunction();
    }
}
