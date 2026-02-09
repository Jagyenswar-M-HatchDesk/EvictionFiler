using EvictionFiler.Domain.Entities.Base;

namespace EvictionFiler.Application.DTOs.FilingDtos
{
    public class FilingDto : DeletableGuidEntity
    {
        public Guid Id { get; set; }
        public string? GeneratedOSC { get; set; }
        public string? GeneratedMotion { get; set; }
        public Guid? LegalCaseId { get; set; }

    }
}
