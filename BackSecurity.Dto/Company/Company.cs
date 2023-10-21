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
        public string haxColor { get; set; }
        public string eliminado { get; set; }
        public int Region { get; set; }
        public int Comuna { get; set; }
        public string Direccion { get; set; }
    }

    public class CompanyCreate
    {
        public string nom_empresa { get; set; }
        public string Rut { get; set; }
        public string fechaCreacion { get; set; }
        public string fechaFinContrato { get; set; }
        public string Correo { get; set; }
        public int Region { get; set; }
        public int Comuna { get; set; }
        public string Direccion { get; set; }
        public int IdDireccion {get;set;}
    }

    public class CompanyUpdate
    {
        public int id_empresa {get;set;}
        public string nom_empresa { get; set; }
        public string Rut { get; set; }
        public string fechaCreacion { get; set; }
        public string fechaFinContrato { get; set; }
        public string Correo { get; set; }
        public int Region { get; set; }
        public int Comuna { get; set; }
        public string Direccion { get; set; }
        public int IdDireccion {get;set;}
        public int isdelete { get; set; }
    }
     public class CompanyInsert
    {
        public int id_empresa { get; set; }
        public string nom_empresa { get; set; }
        public string rut { get; set; }
        public string dvrut { get; set; }
        public string fechacreacion { get; set; }
        public string fechafincontrato { get; set; }
        public int isdelete { get; set; }
        public string imageBase64 { get; set; }
        public string correo { get; set; }
        public int iddireccion { get; set; }
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
        public int IDDIRECCION { get; set; }
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
