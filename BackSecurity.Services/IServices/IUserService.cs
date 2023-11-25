using BackSecurity.Dto.Funcion;
using BackSecurity.Dto.Trabajadores;
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
        bool Create(UserToInsert user);
        List<Users> Users ();
        List<Users> ProfesionalUsers (int id);
        bool Update(UserUpdate user);
        bool Disable(UserDisable user);
        BackSecurity.Dto.User.Item GetWorker (string UserName);
        List<BackSecurity.Dto.Funcion.Item> ListFunction();
        List<TrabajadoresRoot> Trabajadores(int idcompany);
        BackSecurity.Dto.User.Item GetWorkerById(int UserId);
    }
}
