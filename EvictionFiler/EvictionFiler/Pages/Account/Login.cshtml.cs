using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.RateLimiting;
using static System.Net.WebRequestMethods;

namespace EvictionFiler.Server.Components.Pages.Account
{
    [EnableRateLimiting("login")]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(
            SignInManager<User> signInManager, UserManager<User> userManager, IEmailService emailService,
            ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
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
                return Page();

            var user = await _userManager.FindByNameAsync(Login.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return Page();
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, Login.Password);

            if (!passwordValid)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return Page();
            }

            // ✅ MAIN DECISION POINT
            if (!user.TwoFactorEnabled)
            {
                // 🚀 direct login
                await _signInManager.SignInAsync(user, true);

                _logger.LogInformation("User {Username} logged in WITHOUT 2FA.", Login.Username);

                return Redirect("/dashboard");
            }

            // 🔐 2FA users ke liye OTP
            var token = await _userManager.GenerateTwoFactorTokenAsync(
                user,
                TokenOptions.DefaultEmailProvider);

            TempData["2fa_user"] = user.Id.ToString();
            await _emailService.SendOtpAsync(user.Email, token);

            ViewData["OtpSent"] = true;

            _logger.LogInformation("OTP sent to user {Username}", Login.Username);

            return Page();
        }

        public async Task<IActionResult> OnPostVerifyOtp()
        {
            ModelState.Remove("Login.Password");

            if (!ModelState.IsValid)
            {
                ViewData["OtpSent"] = true;
                return Page();
            }
            var userId = TempData["2fa_user"]?.ToString();

            if (string.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError("", "Session expired. Please login again.");
                return Page();
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ModelState.AddModelError("", "Session expired.");
                return Page();
            }

            var valid = await _userManager.VerifyTwoFactorTokenAsync(
                user,
                TokenOptions.DefaultEmailProvider,
                Login.Otp);

            if (!valid)
            {
                ViewData["OtpSent"] = true;
                ModelState.AddModelError("", "Invalid OTP.");
                return Page();
            }

            // ✅ FINAL LOGIN
            await _signInManager.SignInAsync(user, true);

            return Redirect("/dashboard");
        }

        public async Task<IActionResult> OnPostResendOtp()
        {
            ModelState.Remove("Login.Password");

            if (!ModelState.IsValid)
            {
                ViewData["OtpSent"] = true;
                return Page();
            }
            var userId = TempData["2fa_user"]?.ToString();

            if (string.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError("", "Session expired. Please login again.");
                return Page();
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ModelState.AddModelError("", "Session expired.");
                return Page();
            }

            // 🔥 IMPORTANT: TempData ko preserve karo
            TempData.Keep("2fa_user");

            // ✅ New OTP generate
            var token = await _userManager.GenerateTwoFactorTokenAsync(
                user,
                TokenOptions.DefaultEmailProvider);

            await _emailService.SendOtpAsync(user.Email, token);

            ViewData["OtpSent"] = true;

            _logger.LogInformation("OTP resent to user {Username}", user.UserName);

            return Page();
        }
    }
}
