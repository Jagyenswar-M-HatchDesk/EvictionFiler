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
    public class User : IdentityUser
    {
        public string? FirstName {  get; set; }
        public string? MiddleName {  get; set; }
        public string? LastName {  get; set; }
       
        public string? ConnectionString { get; set; }
        public string? RoleId { get; set; }
        //public string? SubscriptionId { get; set; }


        [ForeignKey("RoleId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Role? Roles { get; set; }

        //[ForeignKey("SubscriptionId")]
        //[DeleteBehavior(DeleteBehavior.Restrict)]
        //public virtual Subscription? Subscriptions { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }
}
