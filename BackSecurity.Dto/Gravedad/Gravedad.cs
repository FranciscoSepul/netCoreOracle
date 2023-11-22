using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Gravedad
{
  public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class Gravedad
    {
        public int id { get; set; }
        public string gravedad { get; set; }
        public List<Link> links { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public string gravedad { get; set; }
        public List<Link> links { get; set; }
    }

    public class GravedadList
    {
        public List<Item> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }



}