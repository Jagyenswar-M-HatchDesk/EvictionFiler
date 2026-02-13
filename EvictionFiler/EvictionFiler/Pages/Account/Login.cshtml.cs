using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;

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
                var user = await _signInManager.UserManager.FindByNameAsync(Login.Username);

                // 🔹 Get your firm/subscription data
                var firmData = await HttpContext.RequestServices
                    .GetRequiredService<IUserRepository>()
                    .GetFirmSubscriptionAsync(user.Id);

                var claims = new List<Claim>
    {
        new Claim("CompanyId", firmData.FirmId?.ToString() ?? ""),
        new Claim("SubscriptionId", firmData.Firms?.SubscriptionTypeId?.ToString() ?? ""),
        new Claim("SubscriptionName", firmData.Firms?.SubscriptionTypes?.Name ?? "")
    };

                // 🔹 Add claims to Identity Cookie
                var identity = new ClaimsIdentity(claims);
                await _signInManager.UserManager.AddClaimsAsync(user, claims);

                // 🔹 Refresh sign-in so cookie gets updated with new claims
                await _signInManager.RefreshSignInAsync(user);
                _logger.LogInformation(
                    "User {Username} logged in successfully.",
                    Login.Username);

                return Redirect("/dashboard");
            }

            _logger.LogWarning(
                "Failed login attempt for user {Username}.",
                Login.Username);

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return Page();
        }
    }
}
