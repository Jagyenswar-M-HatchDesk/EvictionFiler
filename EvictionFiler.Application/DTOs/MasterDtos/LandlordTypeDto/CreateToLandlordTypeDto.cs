using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.MasterDtos.LandlordTypeDto
{
    public class CreateToLandlordTypeDto : DeletableGuidEntity
    {
        [Required(ErrorMessage = "  Landllord type  is required")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
