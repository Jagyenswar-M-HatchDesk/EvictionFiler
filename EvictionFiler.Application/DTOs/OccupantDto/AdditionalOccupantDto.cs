using EvictionFiler.Domain.Entities.Base;

namespace EvictionFiler.Application.DTOs.OccupantDto
{
	public class AdditionalOccupantDto : DeletableGuidEntity
	{
		public Guid Id { get; set; }
		public string ?Name { get; set; }
		public string ?Relation { get; set; }

		public Guid? LegalCaseId { get; set; }
        public bool IsVisible { get; set; } = false;
    }
}
