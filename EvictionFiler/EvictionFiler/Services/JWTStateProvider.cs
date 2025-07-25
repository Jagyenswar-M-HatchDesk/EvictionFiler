using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EvictionFiler.Server.Services
{
    public class JwtAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly ILogger<JwtAuthStateProvider> _logger;
        private ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

        private bool _initialized = false;
        private AuthenticationState _cachedAuthState;

        public JwtAuthStateProvider(ProtectedSessionStorage sessionStorage, ILogger<JwtAuthStateProvider> logger)
        {
            _sessionStorage = sessionStorage;
            _logger = logger;
            _cachedAuthState = new AuthenticationState(_anonymous);
        }

        public async Task InitializeAsync()
        {
            if (_initialized) return;

            try
            {
                var result = await _sessionStorage.GetAsync<string>("jwt_token");  // JS interop (must be after render!)
                if (result.Success && result.Value is string token)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwt = handler.ReadJwtToken(token);
                    var identity = new ClaimsIdentity(jwt.Claims, "jwt");
                    _cachedAuthState = new AuthenticationState(new ClaimsPrincipal(identity));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initialize auth state.");
            }

            _initialized = true;
            NotifyAuthenticationStateChanged(Task.FromResult(_cachedAuthState));
        }


        public async Task SetTokenAsync(string token)
        {
            await _sessionStorage.SetAsync("jwt_token", token);

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwt.Claims, "jwt");
            _cachedAuthState = new AuthenticationState(new ClaimsPrincipal(identity));

            NotifyAuthenticationStateChanged(Task.FromResult(_cachedAuthState));
        }


        public async Task ClearTokenAsync()
        {
            await _sessionStorage.DeleteAsync("jwt_token");
            _cachedAuthState = new AuthenticationState(_anonymous);
            NotifyAuthenticationStateChanged(Task.FromResult(_cachedAuthState));
        }


       public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var result = await _sessionStorage.GetAsync<string>("jwt_token");
                if (result.Success && !string.IsNullOrWhiteSpace(result.Value))
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwt = handler.ReadJwtToken(result.Value);
                    var identity = new ClaimsIdentity(jwt.Claims, "jwt");
                    var user = new ClaimsPrincipal(identity);

                    return new AuthenticationState(user);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading JWT token from session.");
            }

            return new AuthenticationState(_anonymous);
        }


    }

}
