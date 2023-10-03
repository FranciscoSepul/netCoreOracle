using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Direccion
{
   
   public class DireccionInsert
    {
        public int id_direccion { get; set; }
        public int id_comuna { get; set; }
        public int id_region { get; set; }
        public string calle { get; set; }
        public int numeracion { get; set; }
    }
    public class Item
    {
        public int id_direccion { get; set; }
        public int id_comuna { get; set; }
        public int id_region { get; set; }
        public string calle { get; set; }
        public int numeracion { get; set; }
        public List<Link> links { get; set; }
    }

     public class DirectionInsertOracle
    {
        public int id_direccion { get; set; }
        public int id_comuna { get; set; }
        public int id_region { get; set; }
        public string calle { get; set; }
        public int numeracion { get; set; }
    }


    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class DireccionRoot
    {
        public List<Item> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }

}
