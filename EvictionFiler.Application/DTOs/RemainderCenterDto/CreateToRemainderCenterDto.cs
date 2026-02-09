using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.RemainderCenterDto
{
    public class CreateToRemainderCenterDto : DeletableGuidEntity
    {
        public string CaseCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Case is required.")]
        public Guid? CaseId { get; set; }

        [Required(ErrorMessage = "Tenant is required.")]
        public Guid? TenantId { get; set; }
        public string? TenantName { get; set; }

        [Required(ErrorMessage = "County is required.")]
        public Guid? CountyId { get; set; }
        public string? CountyName { get; set; }

        public string? Index { get; set; }
        public string? RemainderTypeName { get; set; }
        [Required(ErrorMessage = "Type is required.")]
        public Guid? RemainderTypeId { get; set; }

        public DateTime? When { get; set; }


        public string? Notes { get; set; }
        public string? ReminderName { get; set; }
        public Guid? ReminderCategoryId { get; set; }
        public string? ReminderCategoryName { get; set; }
        public string? ReminderEscalateName { get; set; }
        public Guid? ReminderEscalateId { get; set; }
        public bool? IsComplete { get; set; }
    }
}
