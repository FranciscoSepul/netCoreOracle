using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class ShiftChangeSolicitudeStateDto
    {
        public int SolicitudeId { get; set; }
        public int FlowId { get; set; }
        public string Observacion { get; set; }
        public int? FlowOptionsTypeId { get; set; }
        public int? FlowOptionsSubTypeId { get; set; }
    }
}
