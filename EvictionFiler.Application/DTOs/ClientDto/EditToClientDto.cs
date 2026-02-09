using EvictionFiler.Application.DTOs.LandLordDto;

namespace EvictionFiler.Application.DTOs.ClientDto
{
	public class EditToClientDto : CreateToClientDto
	{
		public Guid Id { get; set; }
		public List<EditToLandlordDto> editLandLords { get; set; } = new();
	}
}
