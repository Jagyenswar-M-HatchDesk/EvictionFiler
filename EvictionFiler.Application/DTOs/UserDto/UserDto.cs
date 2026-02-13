using EvictionFiler.Application.DTOs.FirmDtos;

namespace EvictionFiler.Application.DTOs.UserDto
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public UserRoleDto? Role { get; set; } = new();
        public UserFirmDto? Firm { get; set; } = new();
    }

    public class UserFirmDto
    {
        public Guid FirmId { get; set; }
        public string FirmName { get; set; } = string.Empty;
        public UserSubscriptionDto? UserSubscription { get; set; } = new ();
    }

    public class UserRoleDto
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;    
    }

    public class UserSubscriptionDto
    {
        public Guid SubscriptionId { get; set; }
        public string SubscriptionName { get; set; } = string.Empty;
    }
}
