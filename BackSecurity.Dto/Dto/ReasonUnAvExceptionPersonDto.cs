using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class ReasonUnAvExceptionPersonDto : Base.BaseDto
    {
        public int Id { get; set; }
        public int ReasonId { get; set; }
        public int PermisosMaximos { get; set; }
        public int FuncionId { get; set; }
        public int Order { get; set; }
        public string Funcion { get; set; }

        public int TipoContratoId { get; set; }
        public string NombreTipoContrato { get; set; }

        public int CodSindicato { get; set; }
        public string NombreSindicato { get; set; }

        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public int TurnoDesde { get; set; }
        public int TurnoHasta { get; set; }
        public bool RepetirAnualmente { get; set; }
        public string Estado { get; set; }
        public string HexCode { get; set; }
    }

   
}
