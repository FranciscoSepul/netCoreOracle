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
}
