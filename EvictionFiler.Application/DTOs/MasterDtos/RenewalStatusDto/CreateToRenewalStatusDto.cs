using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.MasterDtos.RenewalStatusDto
{
    public class CreateToRenewalStatusDto : DeletableGuidEntity
    {
        [Required(ErrorMessage = "  Renewal Status Name is required")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
