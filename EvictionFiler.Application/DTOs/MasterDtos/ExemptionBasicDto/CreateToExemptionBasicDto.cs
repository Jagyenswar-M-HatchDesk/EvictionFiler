using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.MasterDtos.ExemptionBasicDto
{
    public class CreateToExemptionBasicDto : DeletableGuidEntity
    {
        [Required(ErrorMessage = "  Rent Regulation Name is required")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
