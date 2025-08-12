using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Entities.Base.Base;

namespace EvictionFiler.Domain.Entities.Master
{
	public class FormTypes : DeletableBaseEntity
	{
		[MaxLength(500)]
		public string Name { get; set; } = string.Empty;
		[MaxLength(500)]
		public Guid? CaseTypeId { get; set; }
		[ForeignKey("CaseTypeId")]
		public CaseType? CaseType { get; set; }
		public string? HTML { get; set; }

		[NotMapped]
		public string CaseTypeName { get; set; }
	}
}
