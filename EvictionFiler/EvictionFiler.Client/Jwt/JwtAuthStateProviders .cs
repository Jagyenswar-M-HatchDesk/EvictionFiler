using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EvictionFiler.Client.Jwt
{
    public class JwtAuthStateProviders : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;
        private AuthenticationState _cachedAuthState;

        public JwtAuthStateProviders(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        // This method is required because AuthenticationStateProvider is abstract
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _sessionStorage.GetItemAsync<string>("jwt_token");

            if (string.IsNullOrEmpty(token))
            {
                var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
                return new AuthenticationState(anonymous);
            }

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var identity = new ClaimsIdentity(jwt.Claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            _cachedAuthState = new AuthenticationState(user);
            return _cachedAuthState;
        }

        // Helper method to get UserId from token
        public async Task<string?> GetUserIdAsync()
        {
            var token = await _sessionStorage.GetItemAsync<string>("jwt_token");
            if (string.IsNullOrEmpty(token)) return null;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var userId = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }

        // Optional: call this after login or logout to notify the app
        public void NotifyAuthenticationStateChanged()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(_cachedAuthState));
        }
    }
}
