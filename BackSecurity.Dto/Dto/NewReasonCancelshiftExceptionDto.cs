using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class NewReasonCancelshiftExceptionDto
    {
        public int? Id { get; set; }
        public int ReasonId { get; set; }
        public int TurnosMaximos { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string ExceptionPriority { get; set; }
        public int FuntionId { get; set; }
        public int ContractId { get; set; }
        public int LaborUnionId { get; set; }
        public string AuditUserCreate { get; set; }
        public int TurnoDesde { get; set; }
        public int TurnoHasta { get; set; }
        public int MinAdvance { get; set; }
        public int MinPostAssignment { get; set; }

    }

    public class NewReasonCancelshiftException
    {
        public int ReasonId { get; set; } //>ok
        public int TurnosMaximos { get; set; }
        public DateTime FechaDesde { get; set; }//>ok
        public DateTime FechaHasta { get; set; }//>ok
        public string ExceptionPriority { get; set; }
        public int funcionId { get; set; }//>ok
        public int tipoContratoId { get; set; }//>ok
        public int codSindicato { get; set; }//>ok
        public string AuditUserCreate { get; set; }
        public int TurnoDesde { get; set; }//>ok
        public int TurnoHasta { get; set; }//>ok
        public int MinAdvance { get; set; }//>ok
        public int MinPostAssignment { get; set; }//>ok
        public string InasistenciaRut {get;set;}
    }

    public class NewReasonCancelshiftExceptionInsert
    {
        public int ReasonId { get; set; } //>ok
        public int TurnosMaximos { get; set; }
        public DateTime FechaDesde { get; set; }//>ok
        public DateTime FechaHasta { get; set; }//>ok
        public string ExceptionPriority { get; set; }
        public int funcionId { get; set; }//>ok
        public int tipoContratoId { get; set; }//>ok
        public int codSindicato { get; set; }//>ok
        public string AuditUserCreate { get; set; }
        public int TurnoDesde { get; set; }//>ok
        public int TurnoHasta { get; set; }//>ok
        public int MinAdvance { get; set; }//>ok
        public int MinPostAssignment { get; set; }//>ok
    }
}
