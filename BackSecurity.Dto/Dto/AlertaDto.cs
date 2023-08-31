using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class AlertaDto : Base.BaseDto
    {
        public int Id { get; set; }
        public int BranchOfficeId { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public int DiasAnticipacion { get; set; }
        public int CertificadoId { get; set; }
        public int FuncionId { get; set; }
        public string NombreCertificado { get; set; }
        public string NombreFuncion { get; set; }
        public string Estado { get; set; }
    }
    public class AlertaList
    {
        public int Cantidad { get; set; }
        public List<AlertaDto> Alertas { get; set; }
    }
}
