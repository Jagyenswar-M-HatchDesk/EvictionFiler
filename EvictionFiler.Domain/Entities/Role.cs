using Microsoft.AspNetCore.Identity;

namespace EvictionFiler.Domain.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public bool IsActive { get; set; } = true;
        public bool? IsDeleted { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTime? CreatedOn { get; set; }
		public Guid? UpdatedBy { get; set; }
		public DateTime? UpdatedOn { get; set; }

  
    }
}
