using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;

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

            var clientDtos = clients.Select(client => new CreateClientDto
            {
                ClientCode = client.ClientCode,
                Name = client.Name,
                Email = client.Email,
                Address_1 = client.Address_1,
                Address_2 = client.Address_2,
                City = client.City,
                State = client.State,
                ZipCode = client.ZipCode,
                Fax = client.Fax,
                Phone = client.Phone,
                CellPhone = client.CellPhone,
                GenarateOwnRd = client.GenarateOwnRd
            }).ToList();

            return clientDtos;
        }

        public async Task<bool> AddClientAsync(CreateClientDto dto)
        {
            var result = await _clientRepository.AddAsync(dto);
            return result;
        }
    }
}
