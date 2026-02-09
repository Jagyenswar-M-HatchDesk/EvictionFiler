using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.MasterDtos.CourtPartDto
{
    public class CreateToCourtPartDto : DeletableGuidEntity
    {
        [Required(ErrorMessage = "  Court-Part Name is required")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
