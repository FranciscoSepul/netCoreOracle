using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
    public class WorkerDto
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Ciudad { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string DvRut { get; set; }
        public string TipoContrato { get; set; }
        public DateTime TrabajadorDesde { get; set; }
        public string NomSindicato { get; set; }
        public int CodSindicato { get; set; }
        public int WorkerId { get; set; }
        public string Rut { get; set; }
        public string Region { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NombrecontactoEmergencia { get; set; }
        public string FonoContactoEmergencia { get; set; }
        public string RutCompleto { get; set; }
        public string Sexo { get; set; }
        public string CodEstadoCivil { get; set; }
        public string Telefono { get; set; }
        public string Sucursal { get; set; }
        public List<CertificationDto> TrabajadorCertificaciones { get; set; }
        public ContractTypeDto Contrato { get; set; }
        public List<OperationalFunctionDto> Funciones { get; set; }
        public List<BranchOfficeDto> BranchOffices { get; set; }
    }
}
