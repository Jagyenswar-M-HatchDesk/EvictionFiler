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
    public class Tenant : Base
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? TenantCode { get; set; } = string.Empty;
        
        public DateTime DOB  { get; set; }
        public string? SSN { get; set; } = string.Empty ;
        public string? Phone {  get; set; } = string.Empty ;
        public string? Email { get; set; } = string .Empty ;
        public string? Language {  get; set; } = string .Empty ;
        public string? Address {  get; set; } = string .Empty ;
        public string? Apt { get; set; } = string.Empty ;
        public string? Borough { get; set; } = string.Empty;
        public double Rent {  get; set; }
        public string? LeaseStatus {  get; set; } = string.Empty ;
		public Guid? ApartmentId { get; set; }
		[ForeignKey("ApartmentId")]
		[DeleteBehavior(DeleteBehavior.Restrict)]
		public Appartment? Apartments { get; set; }
	}
}
