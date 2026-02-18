using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;


namespace EvictionFiler.Infrastructure.Identity
{
    public class ApplicationUserClaimsPrincipalFactory
    : UserClaimsPrincipalFactory<User, Role>
    {
        private readonly IUserservices _userService;
        public ApplicationUserClaimsPrincipalFactory(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<IdentityOptions> options,
            IUserservices userservice)
            : base(userManager, roleManager, options)
        {
            this._userService = userservice;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var userclaims = await _userService.GetUserByIdAsync(user.Id);

            if(userclaims == null)
            {
                return identity;
            }
            identity.AddClaim(new Claim("Name", string.Join(" ", [userclaims.FirstName, userclaims.LastName])));
            identity.AddClaim(new Claim("Firm", userclaims.Firm?.FirmName ?? string.Empty));
            identity.AddClaim(new Claim("FirmId", userclaims.Firm?.FirmId.ToString() ?? string.Empty));
            identity.AddClaim(new Claim("SubscriptionType", userclaims.Firm?.UserSubscription?.SubscriptionName ?? string.Empty));

            return identity;
        }
    }
}
