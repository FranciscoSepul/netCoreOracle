using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Funcion
{
    public class Function
    { 
        public int id_fun { get; set; }
        public string nom_fun { get; set; }
    }

     public class Item
    {
        public int id_fun { get; set; }
        public string nom_fun { get; set; }
        public List<Link> links { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class RootFunction
    {
        public List<Item> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }


}
