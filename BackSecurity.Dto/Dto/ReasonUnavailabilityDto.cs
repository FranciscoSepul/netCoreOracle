using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class ReasonUnavailabilityDto : Base.BaseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int DiasAnticipacion { get; set; }
        public int HorasAnticipacion { get; set; }
        public bool EventualAutomatico { get; set; }
        public string CodeSGN { get; set; }
        public int BranchOfficeCompanyId { get; set; }
        public string Estado { get; set; }
        public string HexCode { get; set; }
        public List<ReasonUnAvExceptionPersonDto> UnAvExceptionPersonDtos { get; set; }
        public List<ReasonUnavExceptionTurnosDto> UnavExceptionTurnosDtos { get; set; }
        public List<SolicitudContratoDto> SolicitudContratos { get; set; }

    }
}
