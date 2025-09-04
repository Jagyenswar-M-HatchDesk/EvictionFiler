
using Blazored.SessionStorage;
using EvictionFiler.Application.DTOs.UserDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Server.Services
{
    public class AuthService
    {
        private readonly IUserservices _userService;
        private readonly ISessionStorageService _sessionStorage;
        private readonly JwtAuthStateProvider _authProvider;

        public AuthService(IUserservices userService, JwtAuthStateProvider authProvider, ISessionStorageService sessionStorage)
        {
            _userService = userService;
            _authProvider = authProvider;
            _sessionStorage =sessionStorage;
        }

        public async Task<bool> LoginAsync(LoginViewModel model)
        {
            var token = await _userService.LoginAsync(model.Username, model.Password);
            if (token is null) return false;

            await _sessionStorage.SetItemAsync("jwt_token", token);
            return true;
        }


        public Task LogoutAsync() => _authProvider.ClearTokenAsync();

        public async Task<bool> RegisterTenantAsync(RegisterDto model)
        {
           var result = await _userService.RegisterTenantAsync(model);
            if(result == false) return false;
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            var result = await _userService.GetAllUserAsync();
            return result;
        }

    }

}
