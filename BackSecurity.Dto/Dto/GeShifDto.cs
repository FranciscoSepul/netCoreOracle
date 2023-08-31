using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackSecurity.Dto.Dto
{
    [Table("GeShifDto")]
    public class GeShifDto
    {
        [Required(ErrorMessage = "Rut no puede ser nulo o vacio")]
        [DisplayName("Rut Worker")]
        public int Rut { get; set; }
        [Required(ErrorMessage = "FechaDesde no puede ser nulo o vacio")]
        [DisplayName("Fecha Desde")]
        public string DateFrom { get; set; }
        [DisplayName("Hora Desde")]
        public string HourFrom { get; set; }
        [DisplayName("Codigo Operacional")]
        public string CodeOperationalFunction { get; set; }
        [DisplayName("Id planificación")]
        public int IdPlanCertificate { get; set; }
        [DisplayName("Codigo Trabajador")]
        public string WorkerCode { get; set; }
        [DisplayName("Id compañía")]
        public int BranchOfficeCompanyId { get; set; }

    }

    public class GeTurn
    {
        public long Rut { get; set; }
        public DateTime DateFrom { get; set; }
    }
}
