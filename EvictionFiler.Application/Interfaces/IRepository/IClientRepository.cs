using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface IClientRepository : IRepository<Client>
	{
        Task<List<State>> GetAllStateAsync();
		Task<Client?> GetClientWithAllDetailsAsync(Guid clientId);
		Task<List<EditToClientDto>> SearchClient(string searchTerm);

		Task<string> GenerateClientCodeAsync();

	}
}
