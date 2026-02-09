using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.MasterDtos.RentRegulationDto
{
    public class CreateToRentRegulationDto : DeletableGuidEntity
    {
        [Required(ErrorMessage = "Rent Regulation Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
    }
}
