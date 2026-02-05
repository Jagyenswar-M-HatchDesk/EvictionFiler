using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.RateLimiting;

namespace EvictionFiler.Server.Components.Pages.Account
{
    [EnableRateLimiting("login")]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(
            SignInManager<User> signInManager,
            ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public LoginViewModel Login { get; set; } = new();


        [BindProperty]
        public List<string> AllErrors { get; set; } = new List<string>();

        public void OnGet() { }

        public async Task<IActionResult> OnPostSubmit()
        {
            Login.Normalize();

            if (!ModelState.IsValid)
            {
               
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(
                Login.Username,
                Login.Password,
                isPersistent: true,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation(
                    "User {Username} logged in successfully.",
                    Login.Username);

                return RedirectToPage("/dashboard");
            }

            _logger.LogWarning(
                "Failed login attempt for user {Username}.",
                Login.Username);

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return Page();
        }
    }
}
