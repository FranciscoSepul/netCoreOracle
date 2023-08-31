namespace BackSecurity.Dto
{
    public class SolicitudeStateDto
    {
        public int? Id { get; set; }
        public int SolicitudeId { get; set; }
        public string LoginUser { get; set; }
        public int Status { get; set; } = 0;
        public string Observacion { get; set; }
    }
}