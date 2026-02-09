using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.MasterDtos.CaseTypeDto
{
    public class CreateToCaseTypeDto : DeletableGuidEntity
    {
        [Required(ErrorMessage = "  Casetype Name is required")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
