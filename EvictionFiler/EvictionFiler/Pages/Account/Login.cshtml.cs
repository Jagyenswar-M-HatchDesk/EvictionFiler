using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.RateLimiting;

namespace EvictionFiler.Server.Components.Pages.Account
{
    [EnableRateLimiting("login")]
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

        [BindNever]
        public string EmailMarginTop => AllErrors.Any() ? "5px" : "60px";

        public void OnGet() { }

        public async Task<IActionResult> OnPostSubmit()
        {
            if (!ModelState.IsValid)
            {
               
                return Page();
            }
            await Task.Delay(1000);

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

            AllErrors.Add("Invalid Credentials.");
            return Page();
        }
    }
}
