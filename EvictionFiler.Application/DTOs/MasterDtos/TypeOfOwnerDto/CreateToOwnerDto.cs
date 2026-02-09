using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.MasterDtos.TypeOfOwnerDto
{
    public class CreateToOwnerDto : DeletableGuidEntity
    {
        [Required(ErrorMessage = "  Owner Name is required")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
