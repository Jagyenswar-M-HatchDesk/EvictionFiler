using EvictionFiler.Domain.Entities.Base;

namespace EvictionFiler.Application.DTOs.TenantDto
{
    public class AddtionalTenantDto : DeletableGuidEntity
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UnitorApartmentNumber { get; set; }
        public Guid? BuildingId { get; set; }
        public Guid? TenantId { get; set; }
        public Guid? LegalCaseId { get; set; }
        public bool IsVisible { get; set; } = false;
    }
}
