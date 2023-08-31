using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackSecurity.Dto.Dto
{
    [Table("UserDto")]
    public class UserDto
    {
        [Required(ErrorMessage = "User no puede ser nulo o vacio")]
        public string User { get; set; }
        [Required(ErrorMessage = "Pass no puede ser nulo o vacio")]
        public string Pass { get; set; }

    }
}
