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
		private readonly ILandLordRepository _landLordRepo;
		private readonly IApartmentRepository _apartmentRepo;

		public ClientService(
	   IClientRepository clientRepo,
	   ILandLordRepository landLordRepo,
	   IApartmentRepository apartmentRepo)
		{
			_clientRepository = clientRepo;
			_landLordRepo = landLordRepo;
			_apartmentRepo = apartmentRepo;
		}

		public async Task<List<CreateClientDto>> GetAllClientsAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            return clients;
        }

		public async Task<bool> AddClientAsync(CreateClientDto dto)
		{
			

			// 2. Save Client
			var isClientSaved = await _clientRepository.AddAsync(dto);
			return true;
		
		}



		public async Task<bool> DeleteClientAsync(Guid id)
		{
			return await _clientRepository.DeleteAsync(id);
		}


	

        public async Task<List<CreateClientDto>> SearchClientByCode(string code)
        {
            var newtenant = await _clientRepository.SearchClientByCode(code);
            return newtenant;
        }
    }

}
