using EvictionFiler.Application.DTOs.UserDto;
//using EvictionFiler.Client.Services;
using EvictionFiler.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EvictionFiler.Server.Components.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        //private readonly AuthService _authService;

        public LoginModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public LoginViewModel loginModel { get; set; }

        [BindProperty]
        public List<string> AllErrors { get; set; } = new List<string>();

        [BindProperty]
        public string? ErrorMessage { get; set; } = string.Empty;
        [BindProperty]
        public string? UsernameError { get; set; } = string.Empty;
        [BindProperty]
        public string? PasswordError { get; set; } = string.Empty;

        [BindProperty]
        public bool IsProcessing { get; set; } = false;
        [BindNever]
        public string EmailMarginTop => AllErrors.Any() ? "5px" : "55px";

        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostSubmit()
        {
            if (!ModelState.IsValid)
                return Page();

            var result = await _signInManager.PasswordSignInAsync(
                loginModel.Username,
                loginModel.Password,
                isPersistent: true,
                lockoutOnFailure: false);

            //var login = await _authService.LoginAsync(loginModel);
            if (result.Succeeded)
            {
                return Redirect("/dashboard");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}
