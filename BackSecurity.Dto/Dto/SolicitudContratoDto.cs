using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class SolicitudContratoDto : Base.BaseDto
    {
        public int? Id { get; set; }
        public int? MotivoNoDisponibleId { get; set; }
        public int? MotivoInasistenciaId { get; set; }
        public int TipoContratoId { get; set; }
        public bool Active { get; set; }
        public string NombreTipoContrato { get; set; }
        public string NombreNoDisponibilidad { get; set; }
        public string NombreInasistencia { get; set; }
    }
}
