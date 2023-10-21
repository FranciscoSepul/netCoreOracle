using System.ComponentModel.DataAnnotations;

namespace BackSecurity.Dto.Account
{
    public class ChangePass
    {
        [Required]
        public string Password { get; set; }
    }
}
