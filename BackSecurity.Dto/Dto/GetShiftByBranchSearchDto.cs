using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackSecurity.Dto.Dto
{
    [Table("GetShiftByBranchSearch")]
    public class GetShiftByBranchSearchDto
    {
        [Required(ErrorMessage = "Codigo de Sucursal no puede ser nulo o vacio")]
        public string CodSucursal { get; set; }
        public int CodTurno { get; set; }
        public int TipoTurno { get; set; }
        public string Rut { get; set; }
        public string FechaDesde { get; set; }
        public string HoraDesde { get; set; }

    }
}
