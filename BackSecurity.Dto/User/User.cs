using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.User
{
    public class UserLogin
    {
        public string username { get; set; }
        public string password { get; set; }
        public string identifier { get; set; }
    }

    public class UserInsert
    {
        public string apellido { get; set; }
        public string clave { get; set; }
        public string correo { get; set; }
        public string dvrut { get; set; }
        public string fechacreacion { get; set; }
        public int fono_usuario { get; set; }
        public int funcion { get; set; }
        public int id_usuario { get; set; }
        public int idempresa { get; set; }
        public int idtipocuenta { get; set; }
        public int isdelete { get; set; }
        public string nacionalidad { get; set; }
        public string nom_usuario { get; set; }
        public string run_usuario { get; set; }
        public string tipo_contrato { get; set; }
    }

    public class UserToInsert
    {
        public string nom_usuario { get; set; }
        public string run_usuario { get; set; }
        public int fono_usuario { get; set; }
        public string tipo_contrato { get; set; }
        public int id_empresa { get; set; }
        public int funcion { get; set; }
        public string nacionalidad { get; set; }
        public string correo { get; set; }

    }

    public class UserUpdate
    {
        public string apellido { get; set; }
        public string clave { get; set; }
        public string correo { get; set; }
        public string dvrut { get; set; }
        public string fechacreacion { get; set; }
        public int fono_usuario { get; set; }
        public int funcion { get; set; }
        public int id_usuario { get; set; }
        public int id_empresa { get; set; }
        public int idtipocuenta { get; set; }
        public int isdelete { get; set; }
        public string nacionalidad { get; set; }
        public string nom_usuario { get; set; }
        public string run_usuario { get; set; }
        public string tipo_contrato { get; set; }
    }

    public class UserDisable
    {
        public string apellido { get; set; }
        public string clave { get; set; }
        public string correo { get; set; }
        public string dvrut { get; set; }
        public string fechacreacion { get; set; }
        public int fono_usuario { get; set; }
        public string funcion { get; set; }
        public int id_usuario { get; set; }
        public int idempresa { get; set; }
        public int idtipocuenta { get; set; }
        public int isdelete { get; set; }
        public string nacionalidad { get; set; }
        public string nom_usuario { get; set; }
        public string run_usuario { get; set; }
        public string tipo_contrato { get; set; }
    }
    public class Item
    {
        public int id_usuario { get; set; }
        public string run_usuario { get; set; }
        public string nom_usuario { get; set; }
        public string tipo_contrato { get; set; }
        public int fono_usuario { get; set; }
        public string nacionalidad { get; set; }
        public string clave { get; set; }
        public int idtipocuenta { get; set; }
        public int idempresa { get; set; }
        public string fechacreacion { get; set; }
        public int isdelete { get; set; }
        public string funcion { get; set; }
        public string correo { get; set; }
        public string apellido { get; set; }
        public string dvrut { get; set; }
        public List<Link> links { get; set; }
    }

    public class Users
    {
        public int id_usuario { get; set; }
        public string run_usuario { get; set; }
        public string nom_usuario { get; set; }
        public string tipo_contrato { get; set; }
        public int fono_usuario { get; set; }
        public string nacionalidad { get; set; }
        public string clave { get; set; }
        public string tipocuenta { get; set; }
        public string empresa { get; set; }
        public string fechacreacion { get; set; }
        public int isdelete { get; set; }
        public string Eliminado { get; set; }
        public string funcion { get; set; }
        public string correo { get; set; }
        public string apellido { get; set; }
        public string dvrut { get; set; }
        public string haxColor { get; set; }
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

    public class ContractType
    {
        public string contract { get; set; }
    }

}
