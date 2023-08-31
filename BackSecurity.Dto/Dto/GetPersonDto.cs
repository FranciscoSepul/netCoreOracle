using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackSecurity.Dto.Dto
{
    [Table("GetPersonDto")]
    public class GetWorkerDto
    {
        public int Rut { get; set; }
        public string ContractType { get; set; }
        public int Ficha { get; set; }
        public int BranchOfficeCompanyId { get; set; }
        public int BranchValidity { get; set; }
        public int WorkerValidity { get; set; }
    }
}
