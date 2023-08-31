using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class NewReasonUnAvExceptionPersonDto
    {
        public int? Id { get; set; }
        public int ReasonId { get; set; }
        public int PermisosMaximos { get; set; }
        public int FuncionId { get; set; }
        public int TipoContratoId { get; set; }
        public int SindicatoId { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int TurnoDesde { get; set; }
        public int TurnoHasta { get; set; }
        public bool RepetirAnualmente { get; set; }
    }
}
