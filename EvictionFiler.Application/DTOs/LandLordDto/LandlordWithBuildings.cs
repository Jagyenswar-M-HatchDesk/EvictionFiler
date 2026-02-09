using EvictionFiler.Application.DTOs.ApartmentDto;

namespace EvictionFiler.Application.DTOs.LandLordDto
{
	public class LandlordWithBuildings
	{
		public EditToLandlordDto? Landlord { get; set; }
		public List<EditToBuildingDto> Buildings { get; set; } = new();
	}
}
