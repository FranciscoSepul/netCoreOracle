using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    [Table("GetLogoDto")]
    public class GetLogoDto
    {
        public int IdBranchOfficeCompany { get; set; }
        public int? IdTypeLogo { get; set; }
        public DateTime? ActivationDate { get; set; }
    }
}
