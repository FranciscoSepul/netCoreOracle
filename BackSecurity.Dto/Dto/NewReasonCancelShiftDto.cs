using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class NewReasonCancelShiftDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinAdvance { get; set; }
        public int MinPostAssignment { get; set; }
        public bool Exception { get; set; }
        public string CodeSGN { get; set; }
        public int BranchOfficeCompanyId { get; set; }
    }
}
