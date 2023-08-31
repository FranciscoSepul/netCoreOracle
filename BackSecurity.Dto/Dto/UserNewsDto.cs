using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackSecurity.Dto.Dto
{
    [Table("GeShifDto")]
    public class UserNewsDto
    {
        public string organizationId { get; set; }
        public string campaignId { get; set; }
        public Boolean files { get; set; }
    }
}
