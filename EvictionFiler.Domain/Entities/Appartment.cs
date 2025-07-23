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
    public class Appartment : Base
    {
        [Key]
        public Guid Id { get; set; }
		public string? BuildingCode { get; set; } = string.Empty;
		public string? ApartmentCode { get; set; }
		public string? MDR_Number { get; set; }
		public int? BuildingUnits { get; set; }

		public Guid? PremiseTypeId { get; set; }
		[ForeignKey("PremiseTypeId")]
		public PremiseType? premiseTypes { get; set; }
		public Guid? RentRegulationId { get; set; }
		[ForeignKey("RentRegulationId")]
		public RegulationStatus? regulationStatus { get; set; }
		public string? PetitionerInterest { get; set; }

		public string? Address_1 { get; set; }
        public string? Address_2 { get; set; }
		public string? City { get; set; }
		public Guid? StateId { get; set; }
		[ForeignKey("StateId")]
		public State? States { get; set; }
		public string? Zipcode { get; set; }
		public DateOnly DateOfRefreeDeed { get; set; } 
		public LandLordRole? LandlordType { get; set; }
		
		public Guid? LandlordId { get; set; }
		[ForeignKey("LandlordId")]
		[DeleteBehavior(DeleteBehavior.Restrict)]
		
		public LandLord? Landlord { get; set; }
	}
}
