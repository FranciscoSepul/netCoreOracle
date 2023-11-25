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

    public class FacturaId
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
        public int? NombreCompany { get; set; }
        public int mesemision { get; set; }
        public int anoemision { get; set; }
        public int diaemision { get; set; }
        public int totalporasesoria { get; set; }
        public int totalporasesoriaespecial { get; set; }
        public int totalporaccidente { get; set; }
        public int totalporcharla { get; set; }
        public int totalporpersonaextra { get; set; }
        public int totalporvisita { get; set; }
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
        public int numeroTelefonico { get; set; }
        public string ActividadEconomica { get; set; }
        public string IdPropiedadEmpresa { get; set; }
        public string idTipoDeEmpresa { get; set; }
        public int trabajadoresHombres { get; set; }
        public int trabajadoresMujeres { get; set; }

        #region PreciosPorEmpresa
        public int costoporaccidente { get; set; }
        public int costoporcharla { get; set; }
        public int costoporvisita { get; set; }
        public int costobase { get; set; }
        public int costoporasesoria { get; set; }
        public int costoporasesoriaespecial { get; set; }
        public int costoporpersonaextra { get; set; }
        public int CantidadDeEmpleadosPorContrato { get; set; }
        #endregion
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