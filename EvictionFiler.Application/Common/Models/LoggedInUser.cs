using EvictionFiler.Application.Constants;

namespace EvictionFiler.Application.Common.Models
{
    public sealed class LoggedInUser
    {
        public bool IsAuthenticated { get; init; }
        public string? UserId { get; init; }
        public IReadOnlyCollection<string> Roles { get; init; } = Array.Empty<string>();

        public bool IsInRole(string role)
            => Roles.Contains(role, StringComparer.OrdinalIgnoreCase);

        public bool IsSuperAdmin => IsInRole(ApplicationRoles.ProductOwner);
        public bool IsAdmin => IsInRole(ApplicationRoles.Admin);
        public bool IsStaffMember => IsInRole(ApplicationRoles.StaffMember);
        public bool IsClient => IsInRole(ApplicationRoles.Client);

        public string Name { get; init; } = string.Empty;
        public string Email {get; init; } = string.Empty;
        public string Firm { get; init; } = string.Empty;
        public string FirmId { get; init; } = string.Empty;
        public string Subscription { get; init; } = string.Empty;
    }
}
