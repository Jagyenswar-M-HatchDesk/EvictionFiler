using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IClientService
    {
		Task<bool> Create(CreateToClientDto dto);
		Task<List<EditToClientDto>> GetAllClientsAsync();
		Task<bool> UpdateClientAsync(EditToClientDto dto);
		Task<List<State>> GetAllState();
		Task<EditToClientDto?> GetClientByIdAsync(Guid id);
		Task<bool> DeleteClientAsync(Guid id);
		Task<List<CreateToClientDto>> SearchClientByCode(string code);
	}
}
