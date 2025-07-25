using EvictionFiler.Application.DTOs.ApartmentDto;

namespace EvictionFiler.Application.DTOs.TenantDto
{
	public class EditToTenantDto : CreateToTenantDto
	{
		public Guid Id { get; set; }
		

	}
}
