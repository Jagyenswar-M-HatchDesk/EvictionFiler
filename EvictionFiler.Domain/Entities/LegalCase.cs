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

        [ForeignKey("ClientId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Client? Clients { get; set; }

        [ForeignKey("ApartmentId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Appartment? Apartments { get; set; }

        [ForeignKey("LandLordId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual LandLord? LandLords { get; set; }

        public string? CaseName { get; set; }
    }
}
