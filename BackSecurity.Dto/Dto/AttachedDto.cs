using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    [Table("AttachedDto")]
    public class AttachedDto
    {
        public int Id { get; set; }
        public string File { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string RelativePathSharePoint { get; set; }
        public int? SharePointId { get; set; }
        public string AuditUserLastUpdate { get; set; }
    }
}
