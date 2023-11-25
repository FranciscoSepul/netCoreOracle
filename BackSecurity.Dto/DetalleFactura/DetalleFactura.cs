using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.DetalleFactura
{
    public class InsertDetalleFactura
    {
        public int anoalizacionvalores { get; set; }
        public int costobase { get; set; }
        public int costoporasesoria { get; set; }
        public int costoporasesoriaespecial { get; set; }
        public int costoporcharla { get; set; }
        public int costoporpersonaextra { get; set; }
        public int costoporvisita { get; set; }
        public int diaalizacionvalores { get; set; }
        public int id { get; set; }
        public int mesalizacionvalores { get; set; }
        public int totalporasesoria { get; set; }
        public int totalporasesoriaespecial { get; set; }
        public int totalporaccidente { get; set; }
        public int totalporcharla { get; set; }
        public int totalporpersonaextra { get; set; }
        public int totalporvisita { get; set; }
    }
   public class Item
    {
        public int id { get; set; }
        public int costobase { get; set; }
        public int costoporcharla { get; set; }
        public int costoporvisita { get; set; }
        public int costoporasesoria { get; set; }
        public int costoporasesoriaespecial { get; set; }
        public int costoporpersonaextra { get; set; }
        public int totalporpersonaextra { get; set; }
        public int totalporcharla { get; set; }
        public int totalporvisita { get; set; }
        public int totalporasesoria { get; set; }
        public int totalporasesoriaespecial { get; set; }
        public int totalporaccidente { get; set; }
        public int mesalizacionvalores { get; set; }
        public int anoalizacionvalores { get; set; }
        public int diaalizacionvalores { get; set; }
        public List<Link> links { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class DetalleFacturaRoot
    {
        public List<Item> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }

}