using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackSecurity.Dto.Documents
{
    public class CreateGroupDto
    {
        [Required] public string Name { get; set; }

        public string Description { get; set; }

        [Required] public int BranchOfficeCompanyId { get; set; }

        public List<int> TypeDocIds { get; set; }

        public int? ParentGroupId { get; set; }

        public string Authorization;
    }
}