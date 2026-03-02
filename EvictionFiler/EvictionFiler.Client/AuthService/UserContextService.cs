using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace EvictionFiler.Client.AuthService
{
    public class UserContextService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private bool _isLoaded = false;
        public bool IsAuthenticated => User?.Identity?.IsAuthenticated ?? false;

        public string UserId { get; private set; }
        public bool IsAdmin { get; private set; }
        public ClaimsPrincipal User { get; private set; }

        public UserContextService(AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task LoadAsync()
        {
            if (_isLoaded)
                return;

            var state = await _authStateProvider.GetAuthenticationStateAsync();
            User = state.User;

            if (User.Identity?.IsAuthenticated == true)
            {
                UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                IsAdmin = User.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "Super Admin");
            }

            _isLoaded = true;
        }
    }

}
