using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.MasterDtos.TenancyTypeDto
{
    public class CreateToTenancyTypeDto : DeletableGuidEntity
    {
        [Required(ErrorMessage = "  Tenancy type Name is required")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
