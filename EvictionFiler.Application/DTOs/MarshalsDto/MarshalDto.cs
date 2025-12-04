using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.MarshalsDto
{
    public class MarshalDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        public string BadgeNumber { get; set; }

        public string Telephone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;

        public string OfficeAddress { get; set; } = string.Empty;
    }
}
