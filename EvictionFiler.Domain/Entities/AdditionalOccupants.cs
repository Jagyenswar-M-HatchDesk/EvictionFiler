using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Entities.Base.Base;

namespace EvictionFiler.Domain.Entities
{
	public class AdditionalOccupants : DeletableBaseEntity
	{
		[MaxLength(50)]
		public string Name { get; set; } = string.Empty;
		[MaxLength(500)]
		public string? Relation { get; set; }
		public Guid? LegalCaseId { get; set; }
		[ForeignKey("LegalCaseId")]
		public virtual LegalCase? LegalCase { get; set; }

	}
}
