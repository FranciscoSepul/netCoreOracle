using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class NewMessageModuleDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeMessageId { get; set; }
        public int ModuleId { get; set; }
        public int BranchOfficeCompanyId { get; set; }
        public string AuditUserCreate { get; set; }
    }
}
