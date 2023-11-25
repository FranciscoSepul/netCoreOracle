using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Sucursal
{
   
    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class Sucursal
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int idregion { get; set; }
        public int numerotelefonico { get; set; }
        public string direccion { get; set; }
        public List<Link> links { get; set; }
    }

}


