using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class BranchOfficeDto
    {
        public int IdBranchOffice { get; set; }
        public string CodBranchOffice { get; set; }
        public int WorkerCode { get; set; }
        public bool Active { get; set; }
        public int BranchOfficeWorkerId { get; set; }
    }
}
