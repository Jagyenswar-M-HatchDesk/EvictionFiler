using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities
{
	public class AdditionalOccupants : DeletableGuidEntity
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
