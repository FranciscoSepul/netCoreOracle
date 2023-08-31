using System;
using System.Collections.Generic;

namespace BackSecurity.Dto.Documents
{
    public class GroupContent {
        public class TypeDocContent
        {
            public int Id { get; set; }
            public string Name {get; set; }
            public string Description { get; set; }
            public string Code { get; set; }
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public List<DocLink> Content { get; set; }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<TypeDocContent> TypeDocContents { get; set; }
        public List<DocLink> Contents { get; set; }
    }

}