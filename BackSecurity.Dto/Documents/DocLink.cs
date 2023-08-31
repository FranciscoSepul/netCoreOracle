using System;

namespace BackSecurity.Dto.Documents
{
    public class DocLink
    {
        public int Id { get; set; }
        public int TypeDocId { get; set; }
        public string Name { get; set; }
        public string SharepointSiteUrl { get; set; }
        public string RelativeUrl { get; set; }
        public string ExternalId { get; set; }
        public string Category { get; set; }
        public int OfficeId { get; set; }
        public int Version { get; set; }
        public DateTime Created { get; set; }
    }
}
