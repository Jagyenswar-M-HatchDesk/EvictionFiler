using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Multi_Talent_Architect.Services
{
    //public class JwtAuthStateProvider : AuthenticationStateProvider
    //{
    //    private readonly ProtectedSessionStorage _storage;
    //    private ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

    //    public JwtAuthStateProvider(ProtectedSessionStorage storage)
    //    {
    //        _storage = storage;
    //    }

    //    public async Task SetTokenAsync(string token)
    //    {
    //        await _storage.SetAsync("jwt_token", token);
    //        NotifyAuthenticationStateChanged(Task.FromResult(GetAuthState(token)));
    //    }

    //    public async Task ClearTokenAsync()
    //    {
    //        await _storage.DeleteAsync("jwt_token");
    //        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
    //    }

    //    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    //    {
    //        var result = await _storage.GetAsync<string>("jwt_token");
    //        if (result.Success && result.Value is string token)
    //            return GetAuthState(token);
    //        return new AuthenticationState(_anonymous);
    //    }

    //    private AuthenticationState GetAuthState(string token)
    //    {
    //        var handler = new JwtSecurityTokenHandler();
    //        var jwt = handler.ReadJwtToken(token);
    //        var identity = new ClaimsIdentity(jwt.Claims, "jwt");
    //        return new AuthenticationState(new ClaimsPrincipal(identity));
    //    }
    //}

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

    //public class JwtAuthStateProvider : AuthenticationStateProvider
    //{
    //    private readonly ProtectedSessionStorage _sessionStorage;
    //    private readonly ILogger<JwtAuthStateProvider> _logger;
    //    private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

    //    public JwtAuthStateProvider(ProtectedSessionStorage sessionStorage, ILogger<JwtAuthStateProvider> logger)
    //    {
    //        _sessionStorage = sessionStorage;
    //        _logger = logger;
    //    }

    //    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    //    {
    //        try
    //        {
    //            var result = await _sessionStorage.GetAsync<string>("jwt_token");
    //            if (result.Success && !string.IsNullOrWhiteSpace(result.Value))
    //            {
    //                var handler = new JwtSecurityTokenHandler();
    //                var jwt = handler.ReadJwtToken(result.Value);
    //                var identity = new ClaimsIdentity(jwt.Claims, "jwt");
    //                var user = new ClaimsPrincipal(identity);

    //                return new AuthenticationState(user);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "Error reading JWT token from session.");
    //        }

    //        return new AuthenticationState(_anonymous);
    //    }

    //    public async Task SetTokenAsync(string token)
    //    {
    //        await _sessionStorage.SetAsync("jwt_token", token);
    //        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    //    }

    //    public async Task ClearTokenAsync()
    //    {
    //        await _sessionStorage.DeleteAsync("jwt_token");
    //        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
    //    }

    //    public async Task InitializeAsync()
    //    {
    //        try
    //        {
    //            var result = await _sessionStorage.GetAsync<string>("jwt_token");
    //            if (result.Success && !string.IsNullOrWhiteSpace(result.Value))
    //            {
    //                var handler = new JwtSecurityTokenHandler();
    //                var jwt = handler.ReadJwtToken(result.Value);
    //                var identity = new ClaimsIdentity(jwt.Claims, "jwt");
    //                _cachedAuthState = new AuthenticationState(new ClaimsPrincipal(identity));
    //            }
    //            else
    //            {
    //                _cachedAuthState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    //            }

    //            NotifyAuthenticationStateChanged(Task.FromResult(_cachedAuthState));
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "Failed to read JWT from session storage.");
    //        }
    //    }
    //}



}
