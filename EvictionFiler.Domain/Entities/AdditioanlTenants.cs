using EvictionFiler.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities
{
    public class AdditioanlTenants : DeletableGuidEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? LastName { get; set; }
        public Guid? TenantId { get; set; }
        [ForeignKey("TenantId")]
        public virtual Tenant? Tenants { get; set; }

        
    }
}
