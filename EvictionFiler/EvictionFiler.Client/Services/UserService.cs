using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Client.Services
{
    public class UserServiceClient
    {
        private readonly IUserservices _userService;
        

        public UserServiceClient(IUserservices userService)
        {
            _userService = userService;
           
        }

        

       

        public async Task<bool> RegisterTenantAsync(RegisterDto model)
        {
            var result = await _userService.RegisterTenantAsync(model);
            if (result == false) return false;
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            var result = await _userService.GetAllUserAsync();
            return result;
        }

    }
}
