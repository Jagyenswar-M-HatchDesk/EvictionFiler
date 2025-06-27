using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? FirstName {  get; set; } = string.Empty;
        public string? MiddleName {  get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public Guid? TenantId { get; set; }
        //public string? ConnectionString { get; set; }
        public Guid RoleId { get; set; }
        //public string? SubscriptionId { get; set; }


        [ForeignKey("RoleId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Role? Roles { get; set; }

        [ForeignKey("TenantId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual UserDatabase? Tenants { get; set; }

        //[ForeignKey("SubscriptionId")]
        //[DeleteBehavior(DeleteBehavior.Restrict)]
        //public virtual Subscription? Subscriptions { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
