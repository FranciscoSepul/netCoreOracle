using BackSecurity.Dto.Dto;
namespace BackSecurity.Dto
{
    public class UserSolicitudeDto
    {
        public int? Id { get; set; }
        public int ReasonSolicitudeId { get; set; }
        public string Comment { get; set; }
        public int AttachedId { get; set; }
        public int CodLaborUnion { get; set; }
        public int idBranchOficeId { get; set; }

        public AttachedDto Attached { get; set; }
    }
}