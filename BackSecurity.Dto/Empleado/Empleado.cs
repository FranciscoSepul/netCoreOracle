using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Empleado
{

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class Job
    {
        public int id { get; set; }
        public string run { get; set; }
        public string dvrut { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int fono_usuario { get; set; }
        public string correo { get; set; }
        public string nacionalidad { get; set; }
        public int idempresa { get; set; }
        public int isdelete { get; set; }
        public int iddireccion { get; set; }
        public int idactividaddetrabajo { get; set; }
        public int sexo { get; set; }
        public string HoraIngreso { get; set; }
        public string HoraSalida { get; set; }
        ///
        public string FechaNacimiento { get; set; }
        public string FechaContrato { get; set; }
        public string PuebloOriginario { get; set; }
        public string Profesion { get; set; }
        public string TipoDeContrato { get; set; }
        public int idCategoriaOcupacional { get; set; }
        public int IdTipoDeIngreso { get; set; }

        public List<Link> links { get; set; }
    }

    public class EmpleadoRoot
    {
        public List<Job> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }


}