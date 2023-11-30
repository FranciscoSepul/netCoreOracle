using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Visita
{
    public class Item
    {
        public int id { get; set; }
        public int idprofesionalacargo { get; set; }
        public int idcompany { get; set; }
        public int idtipovisita { get; set; }
        public string descripcion { get; set; }
        public string fechaprogramacion { get; set; }
        public string horaprogramacion { get; set; }
        public int isdelete { get; set; }
    }

    public class VisitaInsert
    {
        public string descripcion { get; set; }
        public DateTime fechaprogramacion { get; set; }
        public string horaprogramacion { get; set; }
        public int idcompany { get; set; }
        public int idprofesionalacargo { get; set; }
        public int idTipo { get; set; }
    }
    public class Visitas
    {
        public int id { get; set; }
        public string idprofesionalacargo { get; set; }
        public string idcompany { get; set; }
        public string descripcion { get; set; }
        public string TipoVisita { get; set; }
        public string fechaprogramacion { get; set; }
        public string horaprogramacion { get; set; }
        public int isdelete { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class VisitasRoot
    {
        public List<Item> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }
}
