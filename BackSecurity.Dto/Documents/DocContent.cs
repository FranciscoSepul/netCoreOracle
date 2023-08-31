using System;

namespace BackSecurity.Dto.Documents
{
    public class DocContent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string PathRelative { get; set; }
        public DateTime Created { get; set; }
        public int Version { get; set; }
        public int Type { get; set; }
        
    }
}
