using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Asesoria
{
    public class Item
    {
        public int idasesoria { get; set; }
        public string fecha_asesoria { get; set; }
        public string profesional { get; set; }
        public object lugar { get; set; }
        public object comentario { get; set; }
        public int idmotivoasesoria { get; set; }
        public int idcompany { get; set; }
        public int idtipodeasesoria { get; set; }
        public List<Link> links { get; set; }
    }

      public class AsesoriaInsert
    {
        public string fecha_asesoria { get; set; }
        public int profesional { get; set; }
        public object comentario { get; set; }
        public int idmotivoasesoria { get; set; }
        public int idcompany { get; set; }
        public int idtipodeasesoria { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class AsesoriaRoot
    {
        public List<Item> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }
}