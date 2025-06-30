using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IServices;

namespace EvictionFiler.Client.Services
{
    public class ClientService
    {

        private readonly IClientService _clientServices;

        public ClientService(IClientService clientServices)
        {
            _clientServices = clientServices;
        }

        public async Task<bool> AddClientAsync(CreateClientDto dto)
        {
            var result = await _clientServices.AddClientAsync(dto);
            return result;
        }
    }
}
