using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvictionFiler.Domain.Entities.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Domain.Entities
{
	public class Client : DeletableGuidEntity
	{
		[Required]
		public string ClientCode { get; set; } = string.Empty;
		[MaxLength(100)]
		[Required]
		public string FirstName { get; set; } = string.Empty;

		[MaxLength(100)]
		public string? LastName { get; set; }
		[MaxLength(250)]
		[Required]
		public string Email { get; set; } = string.Empty;
		[MaxLength(500)]
		public string? Address1 { get; set; } = string.Empty;
		[MaxLength(500)]
		public string? Address2 { get; set; }
		[MaxLength(100)]
		public string? City { get; set; } = string.Empty;
		public Guid? StateId { get; set; }
		[ForeignKey("StateId")]
		public State State { get; set; }
		[MaxLength(50)]
		public string? ZipCode { get; set; } = string.Empty;
		[MaxLength(50)]
		public string? Phone { get; set; }
		[MaxLength(50)]
		public string? CellPhone { get; set; }
		[MaxLength(50)]
		public string? Fax { get; set; }


		public ICollection<LandLord>? LandLords { get; set; }

		public Guid? ClientTypeId { get; set; } 
		[ForeignKey("ClientTypeId")]
		public ClientRole? ClientType { get; set; }

        public string? Reference { get; set; }
    }
}
