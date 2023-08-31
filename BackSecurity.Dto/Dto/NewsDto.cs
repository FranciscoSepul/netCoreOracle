
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace BackSecurity.Dto.Dto
{
    public class Result
    {
        public int code { get; set; }
        public string messsage { get; set; }
        public List<NewsDto> data { get; set; }
    }

    public class NewsDto
    {
        public string Id { get; set; }
        public int IdBranchOfficeCompany { get; set; }
        public string Name { get; set; }
        public List<AppNewsDto> AppNews { get; set; }
        public string[] Tags { get; set; }
        public List<AppRuleDto> AppRule { get; set; }
    }

    public class AppNewsDto : Base.BaseDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AppImage> AppImage { get; set; }
        public List<AppNewsSindicato> Sindicatos { get; set; } = new List<AppNewsSindicato>();
        public List<AppNewsOperationalFunction> OperationalFunctions { get; set; } = new List<AppNewsOperationalFunction>();
        public List<AppNewsContractType> ContractTypes { get; set; } = new List<AppNewsContractType>();
        public string NewsType { get; set; }
        public DateTime? ProgramDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string HexCode { get; set; }
        public bool Prioridad { get; set; }
        public string Imagen { get; set; }
    }
    public class AppNewsSindicato
    {
        public int Cod_sindicato { get; set; }
    }
    public class AppNewsOperationalFunction
    {
        public int IdOperationalFunction { get; set; }
    }
    public class AppNewsContractType
    {
        public int IdContractType { get; set; }
    }
    public class AppImage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class AppRuleDto
    {
        public string Typename { get; set; }
        public long StartDate { get; set; }
        public long EndDate { get; set; }
        public string[] Days { get; set; }
    }
    public class RuleDaysDto
    {
        public int Id { get; set; }
        public string Days { get; set; }
    }
    public class ContractTypeDto
    {
        public int IdContractType { get; set; }
        public string CodContractType { get; set; }
        public string ContractTypeName { get; set; }
        public string ContractTypeDescription { get; set; }
    }
    public class SindicatoDto
    {
        public int Cod_sindicato { get; set; }
        public string Name { get; set; }
    }
    public class OperationalFunctionDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Priority { get; set; }
        public List<CertificationDto> Certificaciones { get; set; }
    }

    public class AppNewsExport
    {

        public int? Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string TipoContrato { get; set; }
        public string Sindicato { get; set; }
        public string Funcion { get; set; }
        public DateTime? FHProgramacion { get; set; }
        public DateTime? FHFinalizacion { get; set; }
        public string Documento { get; set; }
        public string NombreCreador { get; set; }
        public DateTime? FHCreacion { get; set; }
        public string NombreEditor { get; set; }
        public DateTime? FHEdicion { get; set; }
        public string Estado { get; set; }
    }

     public class AppNewsExportFormat
    {

        public int? Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string TipoContrato { get; set; }
        public string Sindicato { get; set; }
        public string Funcion { get; set; }
        public string FHProgramacion { get; set; }
        public string FHFinalizacion { get; set; }
        public string Documento { get; set; }
        public string NombreCreador { get; set; }
        public string FHCreacion { get; set; }
        public string NombreEditor { get; set; }
        public string FHEdicion { get; set; }
        public string Estado { get; set; }
    }
}
