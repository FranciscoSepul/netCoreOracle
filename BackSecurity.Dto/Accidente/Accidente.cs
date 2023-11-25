using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Accidente
{
    public class Accidente
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Tipoaccidente { get; set; }
        #region  datos empresa
        public string Empresa { get; set; }
        public string EmpresaRut { get; set; }
        public string EmpresaDvRut { get; set; }
        public string CorreoEmpresa { get; set; }
        public string RegionEmpresa { get; set; }
        public string ComunaEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public int numeroTelefonico { get; set; }
        public string ActividadEconomica { get; set; }
        public string IdPropiedadEmpresa { get; set; }
        public string idTipoDeEmpresa { get; set; }
        public int trabajadoresHombres { get; set; }
        public int trabajadoresMujeres { get; set; }
        #endregion
        public string CelProfesional { get; set; }
        public string RutProfesional { get; set; }
        public string NombreProfesional { get; set; }
        public string Apellidofesional { get; set; }
        public string Gravedad { get; set; }

        #region  trabajador
        public string RutTrabajador { get; set; }
        public string EmpleadoNombre {get;set;}
        public int NumeroContactoEmnpleado {get;set;}
        public string CorreoEmpleado {get;set;}
        //
        public string DireccionTrabajador {get;set;}
        public string ComunaTrabajador {get;set;}
        public string Sexo {get;set;}
        public string Edad {get;set;}
        public string FechaNacimiento {get;set;}
        public string PuebloOriginario {get;set;}
        public string Nacionalidad {get;set;}
        public string ProfesionTrabajador {get;set;}
        public string Antiguedad {get;set;}
        public string TipoDeContratoTrabajador {get;set;}
        public string CategoriaOcupacional {get;set;}
        public string TipoDeIngreso {get;set;}
        #endregion
        public string Fechaaccidente { get; set; }
        public string HoraAccidente { get; set; }
        public string HoraIngresoAlTrabajo { get; set; }
        public string HoraSalidaTrabajo { get; set; }
        public string TipoDeAccidente { get; set; }
        public string MedioDePrueba { get; set; }
        public string Fechaalta { get; set; }
        public int Fono_emergencia { get; set; }
        public string color { get; set; }
        public string ClasificacionDenunciante { get; set; }
    }
    public class CreateAccidente
    {
        public int IdGravedad { get; set; }
        public int IdProfesional { get; set; }
        public int IdTipoDeAccidente { get; set; }
        public string fono { get; set; }
        public int IdEmpresa { get; set; }
        public int IdTrabajador { get; set; }
        public string Descripcion { get; set; }
        public int Idlugardeaccidente { get; set; }
        public int Idmediodeprueba { get; set; }
    }

    public class InsertAccidente
    {
        public string descripcion { get; set; }
        public string fechaaccidente { get; set; }
        public string fechaalta { get; set; }
        public int fono_emergencia { get; set; }
        public int id { get; set; }
        public int idempresa { get; set; }
        public int idgravedad { get; set; }
        public int idprofesional { get; set; }
        public int idtipoaccidente { get; set; }
        public int idtrabajador { get; set; }
        public int idlugardeaccidente { get; set; }
        public int idmediodeprueba { get; set; }
    }
    public class Item
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int idtipoaccidente { get; set; }
        public int idempresa { get; set; }
        public int idprofesional { get; set; }
        public int idgravedad { get; set; }
        public int idtrabajador { get; set; }
        public string fechaaccidente { get; set; }
        public string fechaalta { get; set; }
        public int fono_emergencia { get; set; }
        public int idLugarDeAccidente { get; set; }
        public int idMedioDePrueba { get; set; }
        public List<Link> links { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class AccidentRoot
    {
        public List<Item> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }


}