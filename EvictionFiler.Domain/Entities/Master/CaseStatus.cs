using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Domain.Entities.Master
{
	public class CaseStatus : DeletableGuidEntity
	{
		[MaxLength(50)]
		public string  Name { get; set; } = string.Empty;
		[MaxLength(500)]
		public string? Description { get; set; }

	}
}
