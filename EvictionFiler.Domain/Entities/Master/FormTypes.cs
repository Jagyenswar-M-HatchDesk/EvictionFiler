using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Entities.Base.Base;

namespace EvictionFiler.Domain.Entities.Master
{
	public class FormTypes : DeletableBaseEntity
	{
		[MaxLength(500)]
		public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
      
		public Guid? CaseTypeId { get; set; }
		[ForeignKey("CaseTypeId")]
		public CaseType? CaseType { get; set; }
        [MaxLength(500)]
        public Guid? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public string? HTML { get; set; }
        public string? Code { get; set; }
       
        public Guid? UnitId { get; set; }
        [ForeignKey("UnitId")]
        public Unit? Units { get; set; }
        public Guid? FirmId { get; set; }

        [ForeignKey("FirmId")]
        public Firms? Firms { get; set; }
        public string? Rate { get; set; }

		[NotMapped]
		public string CaseTypeName { get; set; }
	}
}
