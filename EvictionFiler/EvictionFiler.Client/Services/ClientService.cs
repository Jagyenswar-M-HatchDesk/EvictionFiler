using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Infrastructure.Repositories;

namespace EvictionFiler.Client.Services
{
    public class ClientService
    {

        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientServices)
        {
            _clientRepository = clientServices;
        }

        public async Task<List<CreateClientDto>> GetAllClientsAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            return clients;
        }

        public async Task<bool> AddClientAsync(CreateClientDto dto)
        {
            var result = await _clientRepository.AddAsync(dto);
            return result;
        }

        public async Task<List<CreateClientDto>> SearchClientByCode(string code)
        {
            var newtenant = await _clientRepository.SearchClientByCode(code);
            return newtenant;
        }
    }
}
