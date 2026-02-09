using EvictionFiler.Domain.Entities.Base;

namespace EvictionFiler.Application.DTOs.CalanderDto
{
    public class CalanderDto : DeletableGuidEntity
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string? Room { get; set; }
        public string? Caption { get; set; }
        public string? Index { get; set; }

        public string Judge { get; set; }

        public Guid? CountyId { get; set; }
        public string? CountyName { get; set; }

        public Guid? CourtPartId { get; set; }
        public string? CourtPartName { get; set; }


        public Guid? CaseStatusId { get; set; }
        public string? CaseStatusName { get; set; }


        public Guid? CaseTypeId { get; set; }
        public string? CaseTypeName { get; set; }


        public string? LastAction { get; set; }
        public string? OppositeAttorney { get; set; }
    }
}
