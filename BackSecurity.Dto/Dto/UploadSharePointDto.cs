using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
   public class UploadSharePoint
    {
        public string CodeTypeDoc { get; set; }  
       
        public string IdBranchOfficeCompany { get; set; }
        
        public string Content { get; set; }
       
        public string FileName { get; set; }

        public List<MetaData> Metadata { get; set; }

        public class MetaData
        {  
            public string LabelName { get; set; }
           
            public string Value { get; set; }
        }

    }
}
