using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackSecurity.Dto.Documents {
    public class EditGroupDto {

        public string Name { get; set; }

        public string Description { get; set; }

        public int BranchOfficeCompanyId { get; set; }

        public List<int> TypeDocIds { get; set; }

        public int? ParentGroupId { get; set; }

        public string Authorization;

    }
}