using EvictionFiler.Application.Common.Interfaces;
using EvictionFiler.Application.Common.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace EvictionFiler.Infrastructure.Identity
{
    public sealed class LoggedInUserService : ILoggedInUserService
    {
        private readonly AuthenticationStateProvider _authStateProvider;

        public LoggedInUserService(AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task<LoggedInUser> GetAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user?.Identity?.IsAuthenticated != true)
            {
                return new LoggedInUser { IsAuthenticated = false };
            }

            return new LoggedInUser
            {
                IsAuthenticated = true,
                UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Roles = user.FindAll(ClaimTypes.Role).Select(r => r.Value).ToArray(),
                Subscription = user.FindFirst("subscription")?.Value ?? string.Empty,
                Email = user.Identity.Name ?? string.Empty,
                Name = user.FindFirst("Name")?.Value ?? string.Empty,
                Firm = user.FindFirst("Firm")?.Value ?? string.Empty,
                FirmId = user.FindFirst("FirmId")?.Value ?? string.Empty,

            };
        }
    }
}
