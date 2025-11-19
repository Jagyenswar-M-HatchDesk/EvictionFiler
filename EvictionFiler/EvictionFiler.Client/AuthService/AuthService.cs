
//using Blazored.SessionStorage;
//using EvictionFiler.Application.DTOs.UserDto;
//using EvictionFiler.Application.Interfaces.IServices;
//using EvictionFiler.Client.Jwt;
//using EvictionFiler.Domain.Entities;
//using Microsoft.AspNetCore.Components.Authorization;
//using System.Security.Claims;

//namespace EvictionFiler.Client.Services
//{
//    public class AuthService
//    {
//        private readonly IUserservices _userService;
//        private readonly ISessionStorageService _sessionStorage;
//        //private readonly JwtAuthStateProviders _authProvider;
//        private AuthenticationState _cachedAuthState;
//        private ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

//        public AuthService(IUserservices userService, ISessionStorageService sessionStorage)
//        {
//            _userService = userService;
//            //_authProvider = authProvider;
//            _sessionStorage =sessionStorage;
//        }

//        public async Task<bool> LoginAsync(LoginViewModel model)
//        {
//            var token = await _userService.LoginAsync(model.Username, model.Password);
//            if (token is null) return false;

//            await _sessionStorage.SetItemAsync("jwt_token", token);
//            //await _authProvider.SetTokenAsync(token);
//            return true;
//        }


//        public Task LogoutAsync()
//        {
//            _cachedAuthState = new AuthenticationState(_anonymous);
//            NotifyAuthenticationStateChanged(Task.FromResult(_cachedAuthState));
//        }
//        public void NotifyAuthenticationStateChanged()
//        {
//            NotifyAuthenticationStateChanged(Task.FromResult(_cachedAuthState));
//        }
//        public async Task<bool> RegisterTenantAsync(RegisterDto model)
//        {
//           var result = await _userService.RegisterTenantAsync(model);
//            if(result == false) return false;
//            return true;
//        }

//        public async Task<IEnumerable<User>> GetAllUser()
//        {
//            var result = await _userService.GetAllUserAsync();
//            return result;
//        }

//    }

//}
