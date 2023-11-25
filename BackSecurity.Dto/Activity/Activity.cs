using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Activity
{
    public class ActivityList
    {
        public int id { get; set; }
        public string tema { get; set; }
        public string profesionalacargo { get; set; }
        public string company { get; set; }
        public string fechaprogramacionyHora { get; set; }
        public string haxColor { get; set; }
        public int isdelete { get; set; }
        public string eliminado { get; set; }
        public string descripcion { get; set; }
    }

    public class ActivityInsert
    {
        public string descripcion { get; set; }
        public string fechaprogramacion { get; set; }
        public string horaprogramacion { get; set; }
        public int id { get; set; }
        public int idcompany { get; set; }
        public int idprofesionalacargo { get; set; }
        public int isdelete { get; set; }
        public int tema { get; set; }
        public List<int> idtrabajador { get; set; }
        public List<int> idimplementos { get; set; }

    }

    public class ActivityCreate
    {
        public string descripcion { get; set; }
        public string fechaprogramacion { get; set; }
        public string horaprogramacion { get; set; }
        public int id { get; set; }
        public int idcompany { get; set; }
        public int idprofesionalacargo { get; set; }
        public int isdelete { get; set; }
        public int tema { get; set; }
        public int idtrabajador { get; set; }
        public int idimplementos { get; set; }

        public string idusuarioscapacitacion { get; set; }
        public string idimplementoscapacitacion { get; set; }

    }



    public class Item
    {
        public int id { get; set; }
        public int tema { get; set; }
        public int idprofesionalacargo { get; set; }
        public int idcompany { get; set; }
        public string descripcion { get; set; }
        public string fechaprogramacion { get; set; }
        public string horaprogramacion { get; set; }
        public int isdelete { get; set; }
        public int idtrabajador { get; set; }
        public int idimplementos { get; set; }
        public string idusuarioscapacitacion { get; set; }
        public string idimplementoscapacitacion { get; set; }
        public List<Link> links { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class ActivityRoot
    {
        public List<Item> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }
}
