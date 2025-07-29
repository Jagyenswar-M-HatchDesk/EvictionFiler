
using EvictionFiler.Application.DTOs.TenantDto;


namespace EvictionFiler.Application.DTOs.ApartmentDto
{
	public class EditToBuildingDto : CreateToBuildingDto
	{
		public Guid Id { get; set; }
		public List<EditToTenantDto> editTenants { get; set; } = new();

	}
}
