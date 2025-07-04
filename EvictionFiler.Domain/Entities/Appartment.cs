using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Domain.Entities
{
    public class Appartment : Base
    {
        [Key]
        public Guid Id { get; set; }
       
        public string? ApartmentCode { get; set; }
        public string? PremiseType { get; set; }
        public string? Address_1 { get; set; }
        public string? Address_2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Zipcode { get; set; }
        public string? MDR_Number { get; set; }
        public string? PetitionerInterest { get; set; }
        public string ?Tanent { get; set; }
		public Guid? LandlordId { get; set; }
		[ForeignKey("LandlordId")]
		[DeleteBehavior(DeleteBehavior.Restrict)]
		public LandLord? Landlord { get; set; }
	}
}
