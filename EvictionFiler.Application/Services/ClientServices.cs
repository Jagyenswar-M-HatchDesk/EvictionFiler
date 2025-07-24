using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;


namespace EvictionFiler.Application.Services
{
    public class ClientServices : IClientService
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IClientRepository _clientRepo;
		private readonly ILandLordRepository _landlordrepo;
		private readonly IApartmentRepository _apartmentrepo;
		private readonly ITenantRepository _tenantRepo;
		

		public ClientServices(
	   IClientRepository clientRepo, IUnitOfWork unitOfWork,
		ILandLordRepository landLordRepo,
		IApartmentRepository apartmentRepo ,
		ITenantRepository tenantRepo)
		{
			_clientRepo = clientRepo;
			_unitOfWork = unitOfWork;
			_landlordrepo = landLordRepo;
			_apartmentrepo = apartmentRepo;
			_tenantRepo = tenantRepo;
			
		}

		public async Task<List<CreateClientDto>> GetAllClientsAsync()
		{

			var query = await _clientRepo.GetAllAsync(includes: u => u.States!);

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

		//public async Task<bool> UpdateClientAsync(EditClientDto client)
		//{
		//	var existing = await _clientRepo.GetAsync(client.Id);
		//	if (existing == null) return false;


		//	existing.FirstName = client.FirstName;
		//	existing.LastName = client.LastName;
		//	existing.Email = client.Email;
		//	existing.Address_1 = client.Address_1;
		//	existing.Address_2 = client.Address_2;
		//	existing.City = client.City;
		//	existing.StateId = client.StateId;
		//	existing.ZipCode = client.ZipCode;
		//	existing.Phone = client.Phone;
		//	existing.CellPhone = client.CellPhone;
		//	existing.Fax = client.Fax;
		//	existing.CreatedAt = DateTime.Now;
		//	existing.IsActive = client.IsActive;
		//	existing.IsDeleted = client.IsDeleted;
		//	existing.CreatedBy = client.CreatedBy;
		//	existing.UpdatedBy = client.UpdatedBy;
		//	existing.UpdatedAt = DateTime.Now;

		// _clientRepo.UpdateAsync(existing);
		//	await _unitOfWork.SaveChangesAsync();

		//	return true;

		//}

		public async Task<bool> UpdateClientAsync(EditClientDto client)
		{
			var existingClient = await _clientRepo.GetClientWithAllDetailsAsync(client.Id); // Make sure this includes LandLords, Apartments, Tenants
			if (existingClient == null)
				return false;

			// Update Client details
			existingClient.FirstName = client.FirstName;
			existingClient.LastName = client.LastName;
			existingClient.Email = client.Email;
			existingClient.Address_1 = client.Address_1;
			existingClient.Address_2 = client.Address_2;
			existingClient.City = client.City;
			existingClient.StateId = client.StateId;
			existingClient.ZipCode = client.ZipCode;
			existingClient.Phone = client.Phone;
			existingClient.CellPhone = client.CellPhone;
			existingClient.Fax = client.Fax;
			existingClient.IsActive = client.IsActive;
			existingClient.IsDeleted = client.IsDeleted;
			existingClient.UpdatedBy = client.UpdatedBy;
			existingClient.UpdatedAt = DateTime.Now;

			// Remove old related data
			_landlordrepo.RemoveRange(existingClient.LandLords);
			_apartmentrepo.RemoveRange(existingClient.Appartments);
			_tenantRepo.RemoveRange(existingClient.Tenants);

			// Generate new Landlords
			var landlords = new List<LandLord>();
			var lastLandlordCode = await _landlordrepo.GetLastLandLordCodeAsync();
			int nextLandlordNumber = 1;
			if (!string.IsNullOrEmpty(lastLandlordCode) && lastLandlordCode.Length > 2)
			{
				var numericPart = lastLandlordCode.Substring(2);
				if (int.TryParse(numericPart, out int lastNumber))
					nextLandlordNumber = lastNumber + 1;
			}

			foreach (var l in client.LandLords)
			{
				var code = $"LL{nextLandlordNumber.ToString().PadLeft(10, '0')}";
				nextLandlordNumber++;

				landlords.Add(new LandLord
				{
					Id = Guid.NewGuid(),
					ClientId = client.Id,
					LandLordCode = code,
					FirstName = l.FirstName,
					LastName = l.LastName,
					EINorSSN = l.EINorSSN,
					Phone = l.Phone,
					Email = l.Email,
					Address1 = l.Address1,
					Address2 = l.Address2,
					StateId = l.StateId,
					City = l.City,
					Zipcode = l.Zipcode,
					ContactPersonName = l.ContactPersonName,
					TypeOfOwnerId = l.TypeOfOwnerId,
					CreatedAt = DateTime.Now,
					IsActive = true,
					IsDeleted = false,
					CreatedBy = null,
					UpdatedBy = null,
					UpdatedAt = DateTime.Now
				});
			}

			// Generate Apartments
			var apartments = new List<Appartment>();
			var lastBuildingCode = await _apartmentrepo.GetLastBuildingCodeAsync();
			int nextBuildingNumber = 1;
			if (!string.IsNullOrEmpty(lastBuildingCode) && lastBuildingCode.Length > 2)
			{
				var numericPart = lastBuildingCode.Substring(2);
				if (int.TryParse(numericPart, out int lastNumber))
					nextBuildingNumber = lastNumber + 1;
			}

			foreach (var a in client.Apartments)
			{
				var buildingCode = $"BB{nextBuildingNumber.ToString().PadLeft(10, '0')}";
				nextBuildingNumber++;

				apartments.Add(new Appartment
				{
					Id = Guid.NewGuid(),
					BuildingCode = buildingCode,
					ApartmentCode = a.ApartmentCode,
					City = a.City,
					StateId = a.StateId,
					PremiseTypeId = a.PremiseTypeId,
					Address_1 = a.Address_1,
					Address_2 = a.Address_2,
					Zipcode = a.Zipcode,
					MDR_Number = a.MDR_Number,
					PetitionerInterest = a.PetitionerInterest,
					RentRegulationId = a.RentRegulationId,
					BuildingUnits = a.BuildingUnits,
					DateOfRefreeDeed = a.DateOfRefreeDeed,
					LandlordType = a.LandlordType,
					LandlordId = a.LandlordId,
					IsActive = a.IsActive,
					IsDeleted = a.IsDeleted,
					CreatedBy = a.CreatedBy,
					CreatedAt = a.CreatedAt,
					UpdatedAt = a.UpdatedAt,
					UpdatedBy = a.UpdatedBy
				});
			}

			// Generate Tenants
			var tenants = new List<Tenant>();
			var lastTenantCode = await _tenantRepo.GetLasttenantCodeAsync();
			int nextTenantNumber = 1;
			if (!string.IsNullOrEmpty(lastTenantCode) && lastTenantCode.Length > 2)
			{
				var numericPart = lastTenantCode.Substring(2);
				if (int.TryParse(numericPart, out int lastNumber))
					nextTenantNumber = lastNumber + 1;
			}

			foreach (var t in client.Tenants)
			{
				var tenantCode = $"TT{nextTenantNumber.ToString().PadLeft(10, '0')}";
				nextTenantNumber++;

				tenants.Add(new Tenant
				{
					Id = Guid.NewGuid(),
					TenantCode = tenantCode,
					FirstName = t.FirstName,
					LastName = t.LastName,
					DOB = t.DOB,
					SSN = t.SSN,
					Phone = t.Phone,
					Email = t.Email,
					LanguageId = t.LanguageId,
					StateId = t.StateId,
					Address_1 = t.Address_1,
					Address_2 = t.Address_2,
					City = t.City,
					Zipcode = t.Zipcode,
					Apt = t.Apt,
					Borough = t.Borough,
					Rent = t.Rent,
					HasPossession = t.HasPossession,
					HasRegulatedTenancy = t.HasRegulatedTenancy,
					Name_Relation = t.Name_Relation,
					OtherOccupants = t.OtherOccupants,
					Registration_No = t.Registration_No,
					TenantRecord = t.TenantRecord,
					HasPriorCase = t.HasPriorCase,
					IsActive = t.IsActive,
					IsDeleted = t.IsDeleted,
					CreatedBy = t.CreatedBy,
					CreatedAt = t.CreatedAt,
					UpdatedAt = t.UpdatedAt,
					UpdatedBy = t.UpdatedBy,
					ApartmentId = t.ApartmentId
				});
			}

			await _landlordrepo.AddRangeAsync(landlords);
			await _apartmentrepo.AddRangeAsync(apartments);
			await _tenantRepo.AddRangeAsync(tenants);

			await _unitOfWork.SaveChangesAsync();
			return true;
		}

		public async Task<CreateClientDto?> GetClientByIdAsync(Guid id)
		{
			var client = await _clientRepo.GetAsync(id);

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

			var states = await _clientRepo.GetAllStateAsync();
			return states;
		}


		public async Task<bool> DeleteClientAsync(Guid id)
		{
			var client = await _clientRepo.DeleteAsync(id);
			var deleterecordes = await _unitOfWork.SaveChangesAsync();
			if (deleterecordes > 0)
				return true;
			return false;
		}




		public async Task<List<CreateClientDto>> SearchClientByCode(string code)
		{
			var newtenant = await _clientRepo.SearchClientByCode(code);
			return newtenant;
		}

		public async Task<bool> Create(CreateClientDto client)
		{
			// Ensure client ID and code
			if (client.Id == Guid.Empty)
				client.Id = Guid.NewGuid();

			var clientCode = await _clientRepo.GenerateClientCodeAsync();

			var newclient = new Client
			{
				Id = client.Id,
				ClientCode = clientCode,
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
				UpdatedAt = DateTime.Now
			};

			// Landlords with generated code
			var landlords = new List<LandLord>();
			var lastCode = await _landlordrepo.GetLastLandLordCodeAsync();

			int nextNumber = 1;
			if (!string.IsNullOrEmpty(lastCode) && lastCode.Length > 2)
			{
				var numericPart = lastCode.Substring(2);
				if (int.TryParse(numericPart, out int lastNumber))
				{
					nextNumber = lastNumber + 1;
				}
			}
			foreach (var l in client.LandLords)
			{
				var code = $"LL{nextNumber.ToString().PadLeft(10, '0')}";
				nextNumber++;
				landlords.Add(new LandLord
				{
					Id = l.Id == Guid.Empty ? Guid.NewGuid() : l.Id,
					ClientId = client.Id,
					LandLordCode = code,
					FirstName = l.FirstName,
					LastName = l.LastName,
					EINorSSN = l.EINorSSN,
					Phone = l.Phone,
					Email = l.Email,
					Address1 = l.Address1,
					Address2 = l.Address2,
					StateId = l.StateId,
					City = l.City,
					Zipcode = l.Zipcode,
					ContactPersonName = l.ContactPersonName,
					TypeOfOwnerId = l.TypeOfOwnerId,
					CreatedAt = DateTime.Now,
					IsActive = true,
					IsDeleted = false,
					CreatedBy = null,
					UpdatedBy = null,
					UpdatedAt = DateTime.Now
				});
			}

			// Apartments with building code
			var apartments = new List<Appartment>();
			var lastBuilingCode = await _apartmentrepo.GetLastBuildingCodeAsync();

			int nextBuilingNumber = 1;
			if (!string.IsNullOrEmpty(lastBuilingCode) && lastBuilingCode.Length > 2)
			{
				var numericPart = lastBuilingCode.Substring(2);
				if (int.TryParse(numericPart, out int lastNumber))
				{
					nextBuilingNumber = lastNumber + 1;
				}
			}
			foreach (var a in client.Apartments)
			{ 
				var  buildingcode = $"BB{nextBuilingNumber.ToString().PadLeft(10, '0')}";
			    nextBuilingNumber++; 

			apartments.Add(new Appartment
				{
					Id = a.Id == Guid.Empty ? Guid.NewGuid() : a.Id,
					BuildingCode = buildingcode,
					ApartmentCode = a.ApartmentCode,
					City = a.City,
					StateId = a.StateId,
					PremiseTypeId = a.PremiseTypeId,
					Address_1 = a.Address_1,
					Address_2 = a.Address_2,
					Zipcode = a.Zipcode,
					MDR_Number = a.MDR_Number,
					PetitionerInterest = a.PetitionerInterest,
					RentRegulationId = a.RentRegulationId,
					BuildingUnits = a.BuildingUnits,
					DateOfRefreeDeed = a.DateOfRefreeDeed,
					LandlordType = a.LandlordType,
					LandlordId = a.LandlordId,
					IsActive = a.IsActive,
					IsDeleted = a.IsDeleted,
					CreatedBy = a.CreatedBy,
					CreatedAt = a.CreatedAt,
					UpdatedAt = a.UpdatedAt,
					UpdatedBy = a.UpdatedBy
				});
			}

			// Tenants with tenant code
			var tenants = new List<Tenant>();
			var lasttenantCode = await _tenantRepo.GetLasttenantCodeAsync();

			int nexttenantNumber = 1;
			if (!string.IsNullOrEmpty(lasttenantCode) && lasttenantCode.Length > 2)
			{
				var numericPart = lasttenantCode.Substring(2);
				if (int.TryParse(numericPart, out int lastNumber))
				{
					nexttenantNumber = lastNumber + 1;
				}
			}
			foreach (var t in client.Tenants)
			{
				var tenantCode = $"TT{nexttenantNumber.ToString().PadLeft(10, '0')}";
				nexttenantNumber++;

				tenants.Add(new Tenant
				{
					Id = t.Id == Guid.Empty ? Guid.NewGuid() : t.Id,
					TenantCode = tenantCode,
					FirstName = t.FirstName,
					LastName = t.LastName,
					DOB = t.DOB,
					SSN = t.SSN,
					Phone = t.Phone,
					Email = t.Email,
					LanguageId = t.LanguageId,
					StateId = t.StateId,
					Address_1 = t.Address_1,
					Address_2 = t.Address_2,
					City = t.City,
					Zipcode = t.Zipcode,
					Apt = t.Apt,
					Borough = t.Borough,
					Rent = t.Rent,
					HasPossession = t.HasPossession,
					HasRegulatedTenancy = t.HasRegulatedTenancy,
					Name_Relation = t.Name_Relation,
					OtherOccupants = t.OtherOccupants,
					Registration_No = t.Registration_No,
					TenantRecord = t.TenantRecord,
					HasPriorCase = t.HasPriorCase,
					IsActive = t.IsActive,
					IsDeleted = t.IsDeleted,
					CreatedBy = t.CreatedBy,
					CreatedAt = t.CreatedAt,
					UpdatedAt = t.UpdatedAt,
					UpdatedBy = t.UpdatedBy,
					ApartmentId = t.ApartmentId
				});
			}

			await _clientRepo.AddAsync(newclient);
			await _landlordrepo.AddRangeAsync(landlords);
			await _apartmentrepo.AddRangeAsync(apartments);
			await _tenantRepo.AddRangeAsync(tenants);

			var result = await _unitOfWork.SaveChangesAsync();
			return result > 0;
		}


	}
}
