using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvictionFiler.Domain.Entities.Base.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Domain.Entities
{
    public class LegalCase : DeletableBaseEntity
	{
        [Required]
		public string Casecode { get; set; } = string.Empty;
		public Guid? ClientId { get; set; } 
        public Guid? BuildingId { get; set; }
        public Guid? LandLordId { get; set; }
        public Guid?TenantId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client ?Clients { get; set; }

        [ForeignKey("BuildingId")]
        public virtual Building ? Buildings { get; set; } 

        [ForeignKey("LandLordId")]
        public virtual LandLord ?LandLords { get; set; }

        [ForeignKey("TenantId")]
        public virtual Tenant? Tenants { get; set; }
		[MaxLength(100)]
		public string? CaseName { get; set; }
        public Guid? ClientRoleId { get; set; }
		[ForeignKey("ClientRoleId")]
		public ClientRole? ClientRole { get; set; }
		[MaxLength(100)]
		public string? LegalRepresentative { get; set; }
		public Guid ?CaseTypeId { get; set; }
		[ForeignKey("CaseTypeId")]
		public CaseType? CaseType { get; set; }
		public Guid? CaseSubTypeId { get; set; }
		[ForeignKey("CaseSubTypeId")]
		public CaseSubType? CaseSubType { get; set; }
		[MaxLength(100)]
		public string Attrney { get; set; } = string.Empty;
		[MaxLength(100)]
		public string AttrneyContactInfo { get; set; } = string.Empty;
		[MaxLength(50)]
		public string Firm { get; set; } = string.Empty;
	}
}
