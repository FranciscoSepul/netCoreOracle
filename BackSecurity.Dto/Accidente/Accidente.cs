using System;
using System.Collections.Generic;
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
        public string Empresa { get; set; }
        public string NombreProfesional { get; set; }
        public string Gravedad { get; set; }
        public string RutTrabajador { get; set; }
        public string Fechaaccidente { get; set; }
        public string Fechaalta { get; set; }
        public int Fono_emergencia { get; set; }
        public string color { get; set; }
    }
    public class CreateAccidente
    {
        public int IdGravedad { get; set; }
        public int IdProfesional { get; set; }
        public int IdTipoDeAccidente { get; set; }
        public int fono { get; set; }
        public int IdTrabajador { get; set; }
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