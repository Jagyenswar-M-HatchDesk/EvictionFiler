using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
		[MaxLength(100)]
		public string FirstName {  get; set; } = string.Empty;
        public string? MiddleName {  get; set; } = string.Empty;
		[MaxLength(100)]
		public string? LastName { get; set; } = string.Empty;
        public Guid? TenantId { get; set; }
        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Role? Role { get; set; }

        public Guid? FirmId { get; set; }

        [ForeignKey("FirmId")]
        public virtual Firms? Firms { get; set; }

        [ForeignKey("TenantId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual UserDatabase? Tenants { get; set; }
		public bool IsActive { get; set; } = true;
        public bool? IsDeleted { get; set; } = false;
		public Guid CreatedBy { get; set; }
		public DateTime? CreatedOn { get; set; }
		public Guid? UpdatedBy { get; set; }
		public DateTime? UpdatedOn { get; set; }
	}
}
