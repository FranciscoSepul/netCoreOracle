using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackSecurity.Dto.Dto
{
    [Table("GeShifHistorytDto")]
    public class GeShifHistorytDto
    {
        [Required(ErrorMessage = "Rut no puede ser nulo o vacio")]
        [DisplayName("Rut Worker")]
        public int Rut { get; set; }

        [Required(ErrorMessage = "Fecha desde no puede ser nulo o vacio")]
        [DisplayName("Fecha Desde")]
        public string DateFrom { get; set; }

        [Required(ErrorMessage = "Fecha hasta no puede ser nulo o vacio")]
        [DisplayName("Fecha Hasta")]
        public string DateTo { get; set; }

        [Required(ErrorMessage = "Turno hasta no puede ser nulo o vacio")]
        [DisplayName("Turno Hasta")]
        public int TurnTo { get; set; }

        [Required(ErrorMessage = "Turno desde no puede ser nulo o vacio")]
        [DisplayName("Turno desde")]
        public int TurnFrom { get; set; }

        [DisplayName("Codigo Sucursal")]
        public string BranchOficeId { get; set; }

    }
}
