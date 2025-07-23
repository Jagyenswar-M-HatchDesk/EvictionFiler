using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities.Master;


namespace EvictionFiler.Application.Services
{
    public class ClientServices : IClientService
    {
		private readonly IClientRepository _clientRepository;
		//private readonly ILandLordRepository _landLordRepo;
		//private readonly IApartmentRepository _apartmentRepo;

		public ClientServices(
	   IClientRepository clientRepo)
	   //ILandLordRepository landLordRepo,
	   //IApartmentRepository apartmentRepo)
		{
			_clientRepository = clientRepo;
			//_landLordRepo = landLordRepo;
			//_apartmentRepo = apartmentRepo;
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

		public async Task<bool> UpdateClientAsync(EditClientDto dto)
		{
			// 2. Save Client
			var isClientSaved = await _clientRepository.UpdateClientAsync(dto);
			return true;

		}

		public async Task<CreateClientDto?> GetClientByIdAsync(Guid id)
		{
			var client = await _clientRepository.GetByIdAsync(id);

			if (client == null) return null;

			// Map Entity to DTO
			return new CreateClientDto
			{
				Id = client.Id,
				FirstName = client.FirstName,
				LastName = client.LastName,
				Email = client.Email,
				Fax = client.Fax,
				Phone = client.Phone,
				CellPhone = client.CellPhone,
				ClientCode = client.ClientCode,
				Address_1 = client.Address_1,
				Address_2 = client.Address_2,
				City = client.City,
				StateId = client.StateId,
				StateName = client.States?.Name,
				ZipCode = client.ZipCode
			};
		}

		public async Task<List<State>> GetAllState()
		{

			var states = await _clientRepository.GetAllStateAsync();
			return states;
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
