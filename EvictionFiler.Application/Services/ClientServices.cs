using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;


namespace EvictionFiler.Application.Services
{
    public class ClientServices : IClientService
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IClientRepository _clientRepository;
		private readonly ILandLordRepository _landlordrepo;
		private readonly IApartmentRepository _apartmentrepo;

		public ClientServices(
	   IClientRepository clientRepo, IUnitOfWork unitOfWork,
		ILandLordRepository landLordRepo,
		IApartmentRepository apartmentRepo)
		{
			_clientRepository = clientRepo;
			_unitOfWork = unitOfWork;
			_landlordrepo = landLordRepo;
			_apartmentrepo = apartmentRepo;
		}

		public async Task<List<CreateClientDto>> GetAllClientsAsync()
		{

			var query = await _clientRepository.GetAllAsync(includes: u => u.States!);

			return query.Select(client => new CreateClientDto
				{
					Id = client.Id,
					ClientCode = client.ClientCode ?? "",
					FirstName = client.FirstName ?? "",
					LastName = client.LastName ?? "",
					Email = client.Email ?? "",
					Address_1 = client.Address_1 ?? "",
					Address_2 = client.Address_2 ?? "",
					City = client.City ?? "",
					StateName = client.States != null ? client.States.Name : "Unknown",
					StateId = client.StateId,
					ZipCode = client.ZipCode ?? 0,
					Fax = client.Fax ?? "",
					Phone = client.Phone ?? "",
					CellPhone = client.CellPhone ?? "",
					IsActive = client.IsActive ?? false,
					IsDeleted = client.IsDeleted ?? false,
					CreatedAt = client.CreatedAt ?? DateTime.UtcNow,
					CreatedBy = client.CreatedBy ?? "Admin",
					UpdatedAt = client.UpdatedAt ?? DateTime.UtcNow,
					UpdatedBy = client.UpdatedBy ?? "Admin"
				}).ToList();

			
		}

		public async Task<bool> UpdateClientAsync(EditClientDto client)
		{
			var existing = await _clientRepository.GetAsync(client.Id);
			if (existing == null) return false;


			existing.FirstName = client.FirstName;
			existing.LastName = client.LastName;
			existing.Email = client.Email;
			existing.Address_1 = client.Address_1;
			existing.Address_2 = client.Address_2;
			existing.City = client.City;
			existing.StateId = client.StateId;
			existing.ZipCode = client.ZipCode;
			existing.Phone = client.Phone;
			existing.CellPhone = client.CellPhone;
			existing.Fax = client.Fax;
			existing.CreatedAt = DateTime.Now;
			existing.IsActive = client.IsActive;
			existing.IsDeleted = client.IsDeleted;
			existing.CreatedBy = client.CreatedBy;
			existing.UpdatedBy = client.UpdatedBy;
			existing.UpdatedAt = DateTime.Now;

		 _clientRepository.UpdateAsync(existing);
			await _unitOfWork.SaveChangesAsync();

			return true;

		}

		public async Task<CreateClientDto?> GetClientByIdAsync(Guid id)
		{
			var client = await _clientRepository.GetAsync(id);

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
			var client = await _clientRepository.DeleteAsync(id);
			var deleterecordes = await _unitOfWork.SaveChangesAsync();
			if (deleterecordes > 0)
				return true;
			return false;
		}




		public async Task<List<CreateClientDto>> SearchClientByCode(string code)
		{
			var newtenant = await _clientRepository.SearchClientByCode(code);
			return newtenant;
		}

		public async Task<bool> Create(CreateClientDto client)
		{
			// Make sure Id is provided
			if (client.Id == Guid.Empty)
				client.Id = Guid.NewGuid();

			var newclient = new Client
			{
				Id = client.Id,
				ClientCode = await _clientRepository.GenerateClientCodeAsync(),
				FirstName = client.FirstName,
				LastName = client.LastName,
				Email = client.Email,
				Address_1 = client.Address_1,
				Address_2 = client.Address_2,
				City = client.City,
				StateId = client.StateId,
				ZipCode = client.ZipCode,
				Phone = client.Phone,
				CellPhone = client.CellPhone,
				Fax = client.Fax,
				CreatedAt = DateTime.Now,
				IsActive = true,
				IsDeleted = false,
				CreatedBy = null,
				UpdatedBy = null,
				UpdatedAt = DateTime.Now,

			};
			var landlords = client.LandLords.Select(l=> new LandLord()
			{
				ClientId = newclient.Id , 
				FirstName = l.FirstName ,
			}).ToList();
			await _clientRepository.AddAsync(newclient);
			await _landlordrepo.AddRangeAsync(new List<LandLord>());
			 var result  = await _unitOfWork.SaveChangesAsync();

			return result > 0;
		}

	}
}
