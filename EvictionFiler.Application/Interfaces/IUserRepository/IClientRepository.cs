using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface IClientRepository
    {
        Task<Client?> GetByIdAsync(Guid id);
        Task<List<Client>> GetAllAsync();
        Task<bool> AddAsync(CreateClientDto client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(Guid id);

        Task<List<CreateClientDto>> SearchClientByCode(string code);
    }
}
