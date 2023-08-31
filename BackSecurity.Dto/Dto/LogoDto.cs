using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    [Table("LogoDto")]
    public class LogoDto : Base.BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdTypeLogo { get; set; }

        public string TypeLogo { get; set; }

        public DateTime ActivationDate { get; set; }
        public DateTime? DisableDate { get; set; }

        public string File { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage ="El campo {0} tiene un máximo de 50 caracteres.")]
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int IdBranchOfficeCompany { get; set; }
        public string Status { get; set; }
        public string HexCode { get; set; }
    }

    public class LogoList
    {
        public int cantidad { get; set; }
        public List<LogoDtoList> logos { get; set; }
    }

    public class LogoDtoList : Base.BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdTypeLogo { get; set; }
        public string TypeLogo { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime? DisableDate { get; set; }
        public int IdBranchOfficeCompany { get; set; }
        public string Status { get; set; }
        public string HexCode { get; set; }
        public string file {get;set;}
        public string filename {get;set;}
    }

    public class LogoDtoExcel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string FHActivacion { get; set; }
        public string FHDesactivacion { get; set; }
        public string NombreDocumento { get; set; }
        public string CodigoCreador { get; set; }
        public string FHCreacion { get; set; }
        public string CodigoEditor { get; set; }
        public string FHEdicion { get; set; }
        public string Estado { get; set; }
       // public string Accion { get; set; }
    }
}
