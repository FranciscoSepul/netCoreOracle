using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Factura
{
     public class InsertFactura
    {
        public int anoemision { get; set; }
        public int diaemision { get; set; }
        public int estado { get; set; }
        public string fechacobro { get; set; }
        public string fechaemision { get; set; }
        public string fechapago { get; set; }
        public int habilitadopago { get; set; }
        public int id { get; set; }
        public int idcompany { get; set; }
        public int iddetallefactura { get; set; }
        public int mesemision { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public string fechaemision { get; set; }
        public string fechacobro { get; set; }
        public string fechapago { get; set; }
        public int estado { get; set; }
        public int iddetallefactura { get; set; }
        public int habilitadopago { get; set; }
        public int idcompany { get; set; }
        public int mesemision { get; set; }
        public int anoemision { get; set; }
        public int diaemision { get; set; }
        public List<Link> links { get; set; }
    }

    public class FacturaList
    {
        public int id { get; set; }
        public string fechaemision { get; set; }
        public string fechacobro { get; set; }
        public string fechapago { get; set; }
        public string estadoFactura { get; set; }
        public string BtnText { get; set; }
        public string HexBtn { get; set; }
        public int iddetallefactura { get; set; }
        public int habilitadopago { get; set; }
        public string NombreCompany { get; set; }
        public int mesemision { get; set; }
        public int anoemision { get; set; }
        public int diaemision { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class FacturaRoot
    {
        public List<Item> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }


}