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
    }
}
