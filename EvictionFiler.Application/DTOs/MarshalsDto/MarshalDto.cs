using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.MarshalsDto
{
    public class MarshalDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Badge Number  is required")]
        public string BadgeNumber { get; set; }


        [RegularExpression(@"^(\+1\s?)?(\(?\d{3}\)?[\s.-]?)?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Enter a valid telephone number.")]
        public string Telephone { get; set; } = string.Empty;


        [RegularExpression(@"^(\+1\s?)?(\(?\d{3}\)?[\s.-]?)?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Enter a valid fax number.")]
        public string Fax { get; set; } = string.Empty;
        [Required(ErrorMessage = "Docket Number  is required")]

        public string DocketNo { get; set; } = string.Empty;

        public string OfficeAddress { get; set; } = string.Empty;
    }
}
