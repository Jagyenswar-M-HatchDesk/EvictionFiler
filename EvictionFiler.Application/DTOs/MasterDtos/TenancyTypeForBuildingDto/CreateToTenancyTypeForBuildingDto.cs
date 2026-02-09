using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.MasterDtos.TenancyTypeForBuildingDto
{
    public class CreateToTenancyTypeForBuildingDto : DeletableGuidEntity
    {
        [Required(ErrorMessage = "  Rent Regulation Name is required")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
