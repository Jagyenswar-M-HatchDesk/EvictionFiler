
using System.ComponentModel.DataAnnotations.Schema;
using EvictionFiler.Domain.Entities.Base.Base;

namespace EvictionFiler.Domain.Entities
{
	public class CaseForms : DeletableBaseEntity
	{
		public string? HTML { get; set; }
		public string? File { get; set; }
		public Guid? LegalCaseId { get; set; }
		[ForeignKey("LegalCaseId")]
		public LegalCase? LegalCase { get; set; }
	}
}
