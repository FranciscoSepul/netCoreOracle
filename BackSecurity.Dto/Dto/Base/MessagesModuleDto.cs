using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto.Base
{
    public class MessagesModuleDto : Base.BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeMessageId { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int BranchOfficeCompanyId { get; set; }
        public string contractName { get; set; }
    }
}
