using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.TipoNotificacion
{
   public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class TipoNotificacionRoot
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public List<Link> links { get; set; }
    }

}