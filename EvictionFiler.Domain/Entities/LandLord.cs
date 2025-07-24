using System.ComponentModel.DataAnnotations.Schema;
using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Domain.Entities
{
    public class LandLord : DeletableBaseEntity
	{
		public string LandLordCode { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
		public string? LastName { get; set; } = string.Empty;
		public Guid? TypeOfOwnerId { get; set; }
		[ForeignKey("TypeOfOwnerId")]
		public TypeOfOwner? TypeOfOwners { get; set; }
        public string? Phone { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string? EINorSSN { get; set; } = string.Empty;
		public string? ContactPersonName { get; set; } = string.Empty;
		public string Address1 { get; set; } = string.Empty;
		public string? Address2 { get; set; }
		public string City { get; set; } = string.Empty;
		public Guid? StateId { get; set; }
		[ForeignKey("StateId")]
		public State States { get; set; } = new State();
		public string Zipcode { get; set; } = string.Empty;
		public Guid? ClientId { get; set; }
		[ForeignKey("ClientId")]
		[DeleteBehavior(DeleteBehavior.Restrict)]
		public Client Client { get; set; } = new Client();

    }
}
