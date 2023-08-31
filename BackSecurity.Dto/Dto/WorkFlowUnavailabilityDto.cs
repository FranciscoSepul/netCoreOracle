using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class WorkFlowUnavailabilityDto
    {
        public string CodeStateSgn { get; set; }
        public int BranchOfficeCompanyId { get; set; }
        public int ContractId { get; set; }
        public string TypeState { get; set; }
    }
}
