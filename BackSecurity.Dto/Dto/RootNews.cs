using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class RootNews
    {
        public int? Code { get; set; }
        public string Message { get; set; }
        public List<NewsDto> Data { get; set; }
        public string Imagen { get; set; }
    }
}
