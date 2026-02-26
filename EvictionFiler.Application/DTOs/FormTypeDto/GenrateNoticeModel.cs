


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.DTOs.FormTypeDto
{
	public class GenrateNoticeModel
	{
		public Guid Id { get; set; }
		public string? HTML { get; set; }
		public string? File { get; set; }
		public Guid? LegalCaseId { get; set; }
		[Required]
		public Guid? FormTypeId { get; set; }
		public Guid? FirmId { get; set; }
		public Guid? CreatedBy { get; set; }
		public string? FormTypeName { get; set; }
		public DateTime? CreatedOn { get; set; }

		public string? CreatedByName { get; set; }
		[Required]
		public decimal? BillAmount { get; set; }

	}
}
