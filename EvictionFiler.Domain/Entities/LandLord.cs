using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Domain.Entities
{
    public class LandLord : Base
    {
        [Key]
        public Guid Id { get; set; }
		public string? LandLordCode { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;
		public string? LastName { get; set; } = string.Empty;
		public Guid? TypeOfOwnerId { get; set; }
		[ForeignKey("TypeOfOwnerId")]
		public TypeOfOwner? TypeOfOwners { get; set; }
        public string? Phone { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
		public string? EINorSSN { get; set; } = string.Empty;
		public string? ContactPersonName { get; set; } = string.Empty;
		public string? Address1 { get; set; }
		public string? Address2 { get; set; }
		public string? City { get; set; }
		public Guid? StateId { get; set; }
		[ForeignKey("StateId")]
		public State? States { get; set; }
		public string? Zipcode { get; set; }
		public Guid? ClientId { get; set; }
		[ForeignKey("ClientId")]
		[DeleteBehavior(DeleteBehavior.Restrict)]
		public Client? Client { get; set; }

    }
}
