using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto.Base
{
    public class BaseDto
    {
        public bool AuditNotDeleted { get; set; }

        public DateTime? AuditCreateDate { get; set; }

        public DateTime? AuditLastUpdateDate { get; set; }

        public string AuditUserCreate { get; set; }
        public string AuditUserLastUpdate { get; set; }
    }
}
