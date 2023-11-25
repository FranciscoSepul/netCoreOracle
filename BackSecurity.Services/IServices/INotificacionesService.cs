using BackSecurity.Dto.Company;
using BackSecurity.Dto.NotificacionDirigida;
using BackSecurity.Dto.Notificaciones;
using BackSecurity.Dto.TipoNotificacion;
using BackSecurity.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Services.IServices
{
    public interface INotificacionesService
    {
        bool Create(Notificaciones company,List<int> trabajadores);
        bool Update(Notificaciones company);
        List<NotificacionesList> List();
        List<TipoNotificacionRoot> ListTipoNotificacion();
        Company GetById(int id);
    }
}
