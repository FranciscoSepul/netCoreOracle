using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackSecurity.Dto.Account
{
    public class DevicePushSecret
    {

        [Required]
        public string PushSecret { get; set; }


    }
}