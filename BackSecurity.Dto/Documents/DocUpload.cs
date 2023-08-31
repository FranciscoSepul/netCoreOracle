using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BackSecurity.Dto.Documents
{
    public class Metadata {
        [Required]
        public string LabelName { get; set; }
        [Required]
        public string Value { get; set; }
    }
    public class DocUpload
    {
        [Required]
        public string CodeTypeDoc { get; set; }
        [Required]
        public string IdBranchOfficeCompany { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Filename { get; set; }
        public List<Metadata> Metadata { get; set; }
        
    }
}
