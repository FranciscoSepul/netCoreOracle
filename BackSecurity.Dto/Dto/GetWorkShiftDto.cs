using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    [Table("GetShiftWork")]
    public class GetWorkShiftDto
    {

        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public int TurnoDesde { get; set; }
        public int TurnoHasta { get; set; }
        public string CodSucursal { get; set; }
    }
}
