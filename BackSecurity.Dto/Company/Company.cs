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
        public int IdDireccion { get; set; }
        public int numeroTelefonico { get; set; }
        public string ActividadEconomica { get; set; }
        public int IdPropiedadEmpresa { get; set; }
        public int idTipoDeEmpresa { get; set; }
    }

    public class CompanyUpdate
    {   
        public string nom_empresa { get; set; }    
        public string rut { get; set; }
        public object fechaCreacion { get; set; }
        public DateTime fechaFinContrato { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public int comuna { get; set; }
        public int isdelete { get; set; }
        public int region { get; set; }
        public int id_empresa { get; set; }
        public int numeroTelefonico { get; set; }
        public string actividadEconomica { get; set; }
        public string idPropiedadEmpresa { get; set; }
        public string idTipoDeEmpresa { get; set; }
        public int trabajadoresHombres { get; set; }
        public int trabajadoresMujeres { get; set; }
        public int costoporaccidente { get; set; }
        public int costoporcharla { get; set; }
        public int costoporvisita { get; set; }
        public int costobase { get; set; }
        public int costoporasesoria { get; set; }
        public int costoporasesoriaespecial { get; set; }
        public int costoporpersonaextra { get; set; }
        public int cantidadDeEmpleadosPorContrato { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime opstartDate { get; set; }
        public DateTime opendDate { get; set; }
        public int costoTotal { get; set; }
        public int costoTotalAccidente { get; set; }
        public int costoTotalCharla { get; set; }
        public int costoTotalVisita { get; set; }
        public int costoTotalAsesoria { get; set; }
        public int costoTotalAsesoriaEspecial { get; set; }
        public int costoTotalPersonasExtra { get; set; }
        public int totalAccidente { get; set; }
        public int totalCharla { get; set; }
        public int totalVisita { get; set; }
        public int totalAsesoria { get; set; }
        public int totalAsesoriaEspecial { get; set; }
        public int totalPersonasExtra { get; set; }


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
        public int numeroTelefonico { get; set; }
        public string ActividadEconomica { get; set; }
        public int IdPropiedadEmpresa { get; set; }
        public int idTipoDeEmpresa { get; set; }
        public int CantidadDeEmpleadosPorContrato { get; set; }

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
        public int numeroTelefonico { get; set; }
        public string ActividadEconomica { get; set; }
        public int IdPropiedadEmpresa { get; set; }
        public int idTipoDeEmpresa { get; set; }
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

    public class Factura
    {
        public int CostoTotal { get; set; }
        public int CostoTotalAccidente { get; set; }
        public int CostoTotalCharla { get; set; }
        public int CostoTotalVisita { get; set; }
        public int CostoTotalAsesoria { get; set; }
        public int CostoTotalAsesoriaEspecial { get; set; }
        public int CostoTotalPersonasExtra { get; set; }

    }
    public class Operaciones
    {
        public int TotalAccidente { get; set; }
        public int TotalCharla { get; set; }
        public int TotalVisita { get; set; }
        public int TotalAsesoria { get; set; }
        public int TotalAsesoriaEspecial { get; set; }
        public int TotalPersonasExtra { get; set; }

    }

}
