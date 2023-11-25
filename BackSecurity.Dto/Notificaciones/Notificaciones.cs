using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Notificaciones
{
     public class Notificaciones
    {
        public string cuerpo { get; set; }
        public string fechaprogramacion { get; set; }
        public int id { get; set; }
        public int idcompany { get; set; }
        public int idnotificaciondirigida { get; set; }
        public int idtiponotificacion { get; set; }
        public int idtrabajador { get; set; }
        public int status { get; set; }
        public string titulo { get; set; }
    }

     

    public class NotificacionesList
    {
        public string cuerpo { get; set; }
        public string fechaprogramacion { get; set; }
        public int id { get; set; }
        public string company { get; set; }
        public string notificaciondirigida { get; set; }
        public string tiponotificacion { get; set; }
        public string trabajador { get; set; }
        public int status { get; set; }
        public string titulo { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class NotificacionesRoot
    {
        public List<Notificaciones> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }


}