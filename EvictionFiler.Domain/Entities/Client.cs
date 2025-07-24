using System.ComponentModel.DataAnnotations.Schema;
using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Domain.Entities
{
    public class Client : DeletableBaseEntity
	{      
        public string ClientCode { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty ;
        public string? LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; }
        public string City { get; set; } = string.Empty;
		public Guid? StateId { get; set; }
		[ForeignKey("StateId")]
		public State States { get; set; } = new State();
        public string ZipCode { get; set; } =string.Empty;
        public string? Phone { get; set; } 
        public string? CellPhone { get; set; }
        public string? Fax { get; set; } 
        public bool? GenarateOwnRd { get; set; }
		public ICollection<LandLord>? LandLords { get; set; }
	}
}
