using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.PaginationDto;

namespace EvictionFiler.Application.Interfaces.IServices
{
	public interface IClientService
	{
		Task<bool> Create(EditToClientDto dto);
		//Task<List<EditToClientDto>> GetAllClientsAsync();
		Task<PaginationDto<EditToClientDto>> GetAllClientsAsync(int pageNumber, int pageSize, string searchTerm, string userId, bool isAdmin);
		Task<bool> UpdateClientAsync(EditToClientDto dto);

		Task<EditToClientDto?> GetClientByIdAsync(Guid? id);
		Task<bool> DeleteClientAsync(Guid id, bool isAdmin);
		Task<List<EditToClientDto>> SearchClient(string searchTerm);
		Task<List<EditToClientDto>> GetAllClient(string userId, bool isAdmin);

		Task<Guid> CreateOnlyClient(CreateToClientDto client);
		Task<bool> UpdateClientformCase(EditToClientDto client);
		Task<bool> IsEmailExists(string email);




        }
}
