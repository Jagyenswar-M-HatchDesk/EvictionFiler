using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IClientService
    {
		Task<bool> Create(EditToClientDto dto);
		//Task<List<EditToClientDto>> GetAllClientsAsync();
		Task<PaginationDto<EditToClientDto>> GetAllClientsAsync(int pageNumber, int pageSize , string searchTerm);
		Task<bool> UpdateClientAsync(EditToClientDto dto);

		Task<EditToClientDto?> GetClientByIdAsync(Guid? id);
		Task<bool> DeleteClientAsync(Guid id);
		Task<List<CreateToClientDto>> SearchClient(string searchTerm);



	}
}
