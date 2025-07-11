using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Domain.Entities
{
    public class LandLord : Base
    {
        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; } = string.Empty;
        public string? LandLordCode { get; set; } = string.Empty;
		public string? TypeOfOwner { get; set; }
        public string? Phone { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
		public string? EINorSSN { get; set; } = string.Empty;
        public string? Attorney { get; set; } = string.Empty;
		public string? AttorneyContactInfo { get; set; } = string.Empty;
        public string? Firm { get; set; } = string.Empty;
		public string? ContactPersonName { get; set; } = string.Empty;
        public DateOnly DateOfRefreeDeed { get; set; }
		public string? MaillingAddress { get; set; } = string.Empty;
		public LandLordRole? LandlordType { get; set; }

		public Guid? ClientId { get; set; }
		[ForeignKey("ClientId")]
		[DeleteBehavior(DeleteBehavior.Restrict)]
		public Client? Client { get; set; }
		public bool? isCorporeateOwner { get; set; }
        public string? RegisteredAgent { get; set; } = string.Empty;
    }
}
