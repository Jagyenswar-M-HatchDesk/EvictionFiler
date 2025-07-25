using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.TenantDto;

namespace EvictionFiler.Application.DTOs.BuildingDto
{
	public class BuildingWithTenant
	{
		public EditToBuildingDto ?Building { get; set; } 
		public List<EditToTenantDto> Tenants { get; set; } = new();
	}
}
