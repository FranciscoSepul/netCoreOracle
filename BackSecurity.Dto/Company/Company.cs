using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Company
{
    public class Company
    {
        public int id_empresa { get; set; }
        public string nom_empresa { get; set; }
        public string Rut { get; set; }
        public string DvRut { get; set; }
        public string fechaCreacion { get; set; }
        public string fechaFinContrato { get; set; }
        public int IsDelete { get; set; }
        public string ImageBase64 { get; set; }
        public string Correo { get; set; }
        public string haxColor {get;set;}
        public string eliminado {get;set;}
    }

    public class Item
    {
        public int id_empresa { get; set; }
        public string nom_empresa { get; set; }
        public string Rut { get; set; }
        public string DvRut { get; set; }
        public string fechaCreacion { get; set; }
        public string fechaFinContrato { get; set; }
        public int IsDelete { get; set; }
        public string ImageBase64 { get; set; }
        public string Correo { get; set; }
        public List<Link> links { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class CompanyRoot
    {
        public List<Item> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }

}
