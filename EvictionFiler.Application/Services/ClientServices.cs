using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class ClientServices : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientServices(IClientRepository clientRepository) 
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> AddClientAsync(CreateClientDto client)
        {
            var addclient = await _clientRepository.AddAsync(client);
            return addclient;
        }
    }
}
