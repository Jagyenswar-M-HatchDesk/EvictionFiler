
using System.ComponentModel.DataAnnotations.Schema;
using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Domain.Entities
{
	public class CaseForms : DeletableBaseEntity
	{
		public string? HTML { get; set; }
		public string? File { get; set; }
		public Guid? LegalCaseId { get; set; }
		[ForeignKey("LegalCaseId")]
		public LegalCase? LegalCase { get; set; }

		public Guid? FormTypeId { get; set; }
		[ForeignKey("FormTypeId")]
		public FormTypes? FormType { get; set; }
	}
}
