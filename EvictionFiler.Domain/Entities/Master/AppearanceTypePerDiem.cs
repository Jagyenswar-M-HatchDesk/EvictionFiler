using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Domain.Entities.Master
{
	public class AppearanceTypePerDiem : DeletableGuidEntity
	{
		[MaxLength(250)]
		public string  Name { get; set; } = string.Empty;
		[MaxLength(500)]
		public string? Description { get; set; }
		public virtual ICollection<LegalCase> LegalCases { get; set; } = new List<LegalCase>();


    }
}
