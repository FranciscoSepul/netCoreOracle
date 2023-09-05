using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.User
{
    public class User
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
        public string Correo { get; set; }
        public string DvRut { get; set; }
        public int funcion { get; set; }
        public string Rut { get; set; }
        public string numeroContacto { get; set; }
        public string Nacionalidad { get; set; }
        public int companias { get; set; }
    }

    public class Item
    {
        public int id_usuario { get; set; }
        public string run_usuario { get; set; }
        public string nom_usuario { get; set; }
        public string cuenta { get; set; }
        public string tipo_contrato { get; set; }
        public int fono_usuario { get; set; }
        public string nacionalidad { get; set; }
        public List<Link> links { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class Root
    {
        public List<Item> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }

}
