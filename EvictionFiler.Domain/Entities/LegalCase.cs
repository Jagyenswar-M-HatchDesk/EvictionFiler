using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class LegalCase : Base
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? ClientId { get; set; }
        public Guid? ApartmentId { get; set; }
        public Guid? LandLordId { get; set; }
        public Guid? TenantId { get; set; }


        [ForeignKey("ClientId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Client? Clients { get; set; }

        [ForeignKey("ApartmentId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Appartment? Apartments { get; set; }

        [ForeignKey("LandLordId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual LandLord? LandLords { get; set; }

        [ForeignKey("TenantId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Tenant? Tenant { get; set; }

        public string? CaseName { get; set; }
        public string? ClientRole { get; set; }
        public string? LegalRepresentative { get; set; }
        public string? Casecode { get; set; }
        public string? CaseType { get; set; }

        //section4
        public string? Company {  get; set; } 
        public string? Contact {  get; set; } 
        public string? PhoneorEmail {  get; set; } 
        public string? MDRNo {  get; set; } 
        public string? ResidentalUnits {  get; set; } 
        public string? CommercialUnits {  get; set; } 
        public bool? AllUnitsRehistered {  get; set; } 
        public bool? HPDViolation {  get; set; } 

        //section5
        public string? Address { get; set; }
        public string? AptNo { get; set; }
        public string? Borough { get; set; }
        public string? ZIP { get; set; }
        public string? Class { get; set; }
        public string? YearBuilt { get; set; }
        public bool? HeatorHotWater { get; set; }
        public bool? RentStablized { get; set; }

        //section6

        public bool? SeekinEviction {  get; set; }
        public bool? ExemptUnit { get; set; }
        public bool? RentIncreases { get; set; }
        public int? Monthsunpaid { get; set; }
        public string? OthersGrounds { get; set; }

       public string ? Attrney { get; set; }
        public string? AttrneyContactInfo { get; set; }
        public string? Firm { get; set; }
    }
}
