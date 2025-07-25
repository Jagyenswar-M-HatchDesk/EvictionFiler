using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Enums;

namespace EvictionFiler.Application.DTOs.ApartmentDto
{
	public class EditToBuildingDto : CreateToBuildingDto
	{
		public Guid Id { get; set; }
		public List<EditToTenantDto> editTenants { get; set; } = new();

	}
}
