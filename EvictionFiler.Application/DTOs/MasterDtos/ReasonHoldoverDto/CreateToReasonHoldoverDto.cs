using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.MasterDtos.ReasonHoldoverDto
{
    public class CreateToReasonHoldoverDto : DeletableGuidEntity
    {
        [Required(ErrorMessage = "  Reason Holder  is required")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
