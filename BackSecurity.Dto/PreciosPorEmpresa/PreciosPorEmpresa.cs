using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.PreciosPorEmpresa
{
   public class Item
    {
        public int id { get; set; }
        public int idempresa { get; set; }
        public int costoporaccidente { get; set; }
        public int costoporcharla { get; set; }
        public int costoporvisita { get; set; }
        public int costobase { get; set; }
        public int costoporasesoria { get; set; }
        public int costoporasesoriaespecial { get; set; }
        public int costoporpersonaextra { get; set; }
        public List<Link> links { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class PreciosPorEmpresaRoot
    {
        public List<Item> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }
}