using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IClientService
    {
		Task<List<CreateClientDto>> GetAllClientsAsync();
		Task<bool> AddClientAsync(CreateClientDto dto);
		Task<bool> UpdateClientAsync(EditClientDto dto);
		Task<List<State>> GetAllState();
		Task<CreateClientDto?> GetClientByIdAsync(Guid id);
		Task<bool> DeleteClientAsync(Guid id);
		Task<List<CreateClientDto>> SearchClientByCode(string code);
	}
}
