using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EvictionFiler.Server.Services
{
    public class JwtAuthStateProvider : AuthenticationStateProvider
    {
        //private readonly ProtectedSessionStorage _sessionStorage;
        private readonly ISessionStorageService _sessionStorage;
        private readonly ILogger<JwtAuthStateProvider> _logger;
        private ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

        private bool _initialized = false;
        private AuthenticationState _cachedAuthState;

        public JwtAuthStateProvider(ISessionStorageService sessionStorage, ILogger<JwtAuthStateProvider> logger)
        {
            _sessionStorage = sessionStorage;
            _logger = logger;
            _cachedAuthState = new AuthenticationState(_anonymous);
        }

        public async Task InitializeAsync()
        {
            if (_initialized)
                return;

            try
            {
                // JWT token session storage se lo
                var token = await _sessionStorage.GetItemAsync<string>("jwt_token");

                if (!string.IsNullOrWhiteSpace(token))
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwt = handler.ReadJwtToken(token);

                    var identity = new ClaimsIdentity(jwt.Claims, "jwt");
                    _cachedAuthState = new AuthenticationState(new ClaimsPrincipal(identity));
                }
                else
                {
                    // Agar token nahi mila to anonymous user
                    _cachedAuthState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initialize auth state.");
                _cachedAuthState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            _initialized = true;

            // Notify Blazor ke authentication state me update kar do
            NotifyAuthenticationStateChanged(Task.FromResult(_cachedAuthState));
        }




        public async Task SetTokenAsync(string token)
        {
            await _sessionStorage.SetItemAsync("jwt_token", token);

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwt.Claims, "jwt");

            _cachedAuthState = new AuthenticationState(new ClaimsPrincipal(identity));

            NotifyAuthenticationStateChanged(Task.FromResult(_cachedAuthState));
        }



        public async Task ClearTokenAsync()
        {
            await _sessionStorage.RemoveItemAsync("jwt_token");
            _cachedAuthState = new AuthenticationState(_anonymous);
            NotifyAuthenticationStateChanged(Task.FromResult(_cachedAuthState));
        }


       public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                // Token read karo session se
                var token = await _sessionStorage.GetItemAsync<string>("jwt_token");

                // Token null ya empty hai to anonymous user return karo
                if (string.IsNullOrWhiteSpace(token))
                {
                    return new AuthenticationState(_anonymous);
                }

                // JWT Token parse karo
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);

                // Claims se identity banao
                var identity = new ClaimsIdentity(jwt.Claims, "jwt");
                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);
            }
            catch (Exception)
            {
                return new AuthenticationState(_anonymous);
            }
        

            return new AuthenticationState(_anonymous);
        }


    }

}
