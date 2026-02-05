using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Application.DTOs.UserDto
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username or email is required.")]
        [StringLength(256, ErrorMessage = "Username or email is too long.")]
        [Display(Name = "Username or email")]
        public string Username { get; set; } = string.Empty;

        public void Normalize()
        {
            Username = Username.Trim().ToLowerInvariant();
        }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(128, MinimumLength = 8,
        ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; } = string.Empty;
    }
}
