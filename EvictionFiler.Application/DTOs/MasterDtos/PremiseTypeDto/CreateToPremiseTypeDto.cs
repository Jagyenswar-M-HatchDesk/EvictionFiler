using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.MasterDtos.PremiseTypeDto
{
    public class CreateToPremiseTypeDto : DeletableGuidEntity
    {
        [Required(ErrorMessage = "  Premise type  is required")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
