using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSecurity.Dto.Dto
{
   public class SharePointEntryDto
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string SharepointSiteUrl { get; set; }
		public string RelativeUrl { get; set; }
		public DateTime Created { get; set; }
		public int Version { get; set; }
		public string ExternalId { get; set; }
		public string Category { get; set; }
		public int OfficeId { get; set; }
		public int TypeDocId { get; set; }

	}
}
