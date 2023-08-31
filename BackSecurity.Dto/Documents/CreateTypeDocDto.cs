
using System.ComponentModel.DataAnnotations;

namespace BackSecurity.Dto.Documents
{
    public class CreateTypeDocDto
    {
        [Required] public string Name { get; set; }
        [Required] public string Code { get; set; }

        public string Description { get; set; }
    }
}