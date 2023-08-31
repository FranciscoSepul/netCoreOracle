using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class NewAuditLoginDto
    {
        public string LoginUser { get; set; }
        public int DeviceId { get; set; }
        public string System { get; set; }
    }
}
