using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class NewActiveModuleDto
    {
        public int BranchOfficeCompanyId { get; set; }
        public int ModuleId { get; set; }
        public int ContractTypeId { get; set; }
        public bool Active { get; set; }
        public string AuditUserCreate { get; set; }
    }
}
