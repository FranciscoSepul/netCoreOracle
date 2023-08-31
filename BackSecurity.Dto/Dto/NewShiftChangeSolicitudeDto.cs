using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class NewShiftChangeSolicitudeDto
    {
        public int? Id { get; set; }
        public string LoginUser { get; set; }
        public AttachedDto Attached { get; set; }
        public string Comment { get; set; }
        public int CodeStateSgn { get; set; }
        public int BranchOfficeCompanyId { get; set; }
        public int ContractId { get; set; }
        public string TypeState { get; set; }
        public int ShiftTurnTo { get; set; }
        public int ShiftTurnFrom { get; set; }
        public string SolicitudeDateFrom { get; set; }
        public string SolicitudeDateTo { get; set; }
        public int WorkerId { get; set; }
        public int Rut { get; set; }
        public string DvRut { get; set; }
        public string WorkerName { get; set; }
        public int IdMotivoNoDisponible { get; set; }
        public int IdReasonCancelshift { get; set; }
    }

    public class NewShiftChangeSolicitudeInsert
    {
        public string LoginUser { get; set; }
        public AttachedDto Attached { get; set; }
        public string Comment { get; set; }
        public int CodeStateSgn { get; set; }
        public int BranchOfficeCompanyId { get; set; }
        public int ContractId { get; set; }
        public string TypeState { get; set; }
        public int ShiftTurnTo { get; set; }
        public int ShiftTurnFrom { get; set; }
        public string SolicitudeDateFrom { get; set; }
        public string SolicitudeDateTo { get; set; }
        public int WorkerId { get; set; }
        public int Rut { get; set; }
        public string DvRut { get; set; }
        public string WorkerName { get; set; }
        public int IdMotivoNoDisponible { get; set; }
        public int FuncionId { get; set; }
        public int SindicatoId { get; set; }
    }

    public class NewShiftChangeSolicitudeDtoExcel
    {
        public int Id { get; set; }
        public string NroTicket { get; set; } //??
        public int CodigoTrabajador { get; set; } //WorkerId
        public string NombreTrabajador { get; set; }
        public int Rut { get; set; }
        public string TipoContrato { get; set; } //table tbMaeContractType, col contractTypeName (inyectando servicio ContractTypeService)
        public string Sindicato { get; set; } //
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string FHCreacion { get; set; }
        public string FTDesde { get; set; }
        public string FTHasta { get; set; }

    }
}
