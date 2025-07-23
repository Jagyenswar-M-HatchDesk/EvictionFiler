using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface IClientRepository
    {
        Task<Client?> GetByIdAsync(Guid id);
        Task<List<CreateClientDto>> GetAllAsync();
        Task<bool> AddAsync(CreateClientDto client);
        Task<bool> UpdateClientAsync(EditClientDto client);

        Task<List<State>> GetAllStateAsync();
		Task<bool> DeleteAsync(Guid id);

        Task<List<CreateClientDto>> SearchClientByCode(string code);
        Task<string> GenerateClientCodeAsync();
    

	}
}
