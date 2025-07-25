using EvictionFiler.Application.DTOs.ClientDto;
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
		private readonly IBuildingRepository _buildingrepo;
		private readonly ITenantRepository _tenantRepo;
		
		public ClientServices(
	   IClientRepository clientRepo, IUnitOfWork unitOfWork,
		ILandLordRepository landLordRepo,
		IBuildingRepository buildingrepo,
		ITenantRepository tenantRepo)
		{
			_clientRepo = clientRepo;
			_unitOfWork = unitOfWork;
			_landlordrepo = landLordRepo;
			_buildingrepo = buildingrepo;
			_tenantRepo = tenantRepo;
			
		}

		public async Task<List<EditToClientDto>> GetAllClientsAsync()
		{

			var query = await _clientRepo.GetAllAsync(includes: u => u.State!);

			return query.Select(client => new EditToClientDto
				{
				
					ClientCode = client.ClientCode ?? "",
					FirstName = client.FirstName ?? "",
					LastName = client.LastName ?? "",
					Email = client.Email ?? "",
					Address1 = client.Address1 ?? "",
					Address2 = client.Address2 ?? "",
					City = client.City ?? "",
					StateName = client.State != null ? client.State.Name : "Unknown",
					StateId = client.StateId,
					ZipCode = client.ZipCode,
					Fax = client.Fax ?? "",
					Phone = client.Phone ?? "",
					CellPhone = client.CellPhone ?? "",
					
				}).ToList();
		}

		//public async Task<bool> UpdateClientAsync(EditToClientDto client)
		//{
		//	var existingClient = await _clientRepo.GetClientWithAllDetailsAsync(client.Id); // Make sure this includes LandLords, Apartments, Tenants
		//	if (existingClient == null)
		//		return false;
		//	existingClient.FirstName = client.FirstName;
		//	existingClient.LastName = client.LastName;
		//	existingClient.Email = client.Email;
		//	existingClient.Address1 = client.Address1;
		//	existingClient.Address2 = client.Address2;
		//	existingClient.City = client.City;
		//	existingClient.StateId = client.StateId;
		//	existingClient.ZipCode = client.ZipCode;
		//	existingClient.Phone = client.Phone;
		//	existingClient.CellPhone = client.CellPhone;
		//	existingClient.Fax = client.Fax;

		//	//// Remove old related data
		//	//_landlordrepo.RemoveRange(existingClient.LandLords);
		//	//_buildingrepo.RemoveRange(existingClient.B);
		//	//_tenantRepo.RemoveRange(existingClient.Tenants);

		//	// Generate new Landlords
		//	var landlords = new List<LandLord>();
		//	var lastLandlordCode = await _landlordrepo.GetLastLandLordCodeAsync();
		//	int nextLandlordNumber = 1;
		//	if (!string.IsNullOrEmpty(lastLandlordCode) && lastLandlordCode.Length > 2)
		//	{
		//		var numericPart = lastLandlordCode.Substring(2);
		//		if (int.TryParse(numericPart, out int lastNumber))
		//			nextLandlordNumber = lastNumber + 1;
		//	}

		//	foreach (var l in client.LandLords)
		//	{
		//		var code = $"LL{nextLandlordNumber.ToString().PadLeft(10, '0')}";
		//		nextLandlordNumber++;

		//		landlords.Add(new LandLord
		//		{
		//			Id = Guid.NewGuid(),
		//			ClientId = client.Id,
		//			LandLordCode = code,
		//			FirstName = l.FirstName,
		//			LastName = l.LastName,
		//			EINorSSN = l.EINorSSN,
		//			Phone = l.Phone,
		//			Email = l.Email,
		//			Address1 = l.Address1,
		//			Address2 = l.Address2,
		//			StateId = l.StateId,
		//			City = l.City,
		//			Zipcode = l.Zipcode,
		//			ContactPersonName = l.ContactPersonName,
		//			TypeOfOwnerId = l.TypeOwnerId,
					
		//		});
		//	}

		//	var apartments = new List<Building>();
		//	var lastBuildingCode = await _buildingrepo.GetLastBuildingCodeAsync();
		//	int nextBuildingNumber = 1;
		//	if (!string.IsNullOrEmpty(lastBuildingCode) && lastBuildingCode.Length > 2)
		//	{
		//		var numericPart = lastBuildingCode.Substring(2);
		//		if (int.TryParse(numericPart, out int lastNumber))
		//			nextBuildingNumber = lastNumber + 1;
		//	}

		//	foreach (var a in LandLord.)
		//	{
		//		var buildingCode = $"BB{nextBuildingNumber.ToString().PadLeft(10, '0')}";
		//		nextBuildingNumber++;

		//		apartments.Add(new Building
		//		{
		//			Id = Guid.NewGuid(),
		//			BuildingCode = buildingCode,
		//			ApartmentCode = a.ApartmentCode,
		//			City = a.City,
		//			StateId = a.StateId,
		//			PremiseTypeId = a.PremiseTypeId,
		//			Address_1 = a.Address_1,
		//			Address_2 = a.Address_2,
		//			Zipcode = a.Zipcode,
		//			MDR_Number = a.MDR_Number,
		//			PetitionerInterest = a.PetitionerInterest,
		//			RentRegulationId = a.RentRegulationId,
		//			BuildingUnits = a.BuildingUnits,
		//			DateOfRefreeDeed = a.DateOfRefreeDeed,
		//			LandlordType = a.LandlordType,
		//			LandlordId = a.LandlordId,
		//			IsActive = a.IsActive,
		//			IsDeleted = a.IsDeleted,
		//			CreatedBy = a.CreatedBy,
		//			CreatedAt = a.CreatedAt,
		//			UpdatedAt = a.UpdatedAt,
		//			UpdatedBy = a.UpdatedBy
		//		});
		//	}

		//	// Generate Tenants
		//	var tenants = new List<Tenant>();
		//	var lastTenantCode = await _tenantRepo.GetLasttenantCodeAsync();
		//	int nextTenantNumber = 1;
		//	if (!string.IsNullOrEmpty(lastTenantCode) && lastTenantCode.Length > 2)
		//	{
		//		var numericPart = lastTenantCode.Substring(2);
		//		if (int.TryParse(numericPart, out int lastNumber))
		//			nextTenantNumber = lastNumber + 1;
		//	}

		//	foreach (var t in client.Tenants)
		//	{
		//		var tenantCode = $"TT{nextTenantNumber.ToString().PadLeft(10, '0')}";
		//		nextTenantNumber++;

		//		tenants.Add(new Tenant
		//		{
		//			Id = Guid.NewGuid(),
		//			TenantCode = tenantCode,
		//			FirstName = t.FirstName,
		//			LastName = t.LastName,
		//			DOB = t.DOB,
		//			SSN = t.SSN,
		//			Phone = t.Phone,
		//			Email = t.Email,
		//			LanguageId = t.LanguageId,
		//			StateId = t.StateId,
		//			Address_1 = t.Address_1,
		//			Address_2 = t.Address_2,
		//			City = t.City,
		//			Zipcode = t.Zipcode,
		//			Apt = t.Apt,
		//			Borough = t.Borough,
		//			Rent = t.Rent,
		//			HasPossession = t.HasPossession,
		//			HasRegulatedTenancy = t.HasRegulatedTenancy,
		//			Name_Relation = t.Name_Relation,
		//			OtherOccupants = t.OtherOccupants,
		//			Registration_No = t.Registration_No,
		//			TenantRecord = t.TenantRecord,
		//			HasPriorCase = t.HasPriorCase,
		//			IsActive = t.IsActive,
		//			IsDeleted = t.IsDeleted,
		//			CreatedBy = t.CreatedBy,
		//			CreatedAt = t.CreatedAt,
		//			UpdatedAt = t.UpdatedAt,
		//			UpdatedBy = t.UpdatedBy,
		//			ApartmentId = t.ApartmentId
		//		});
		//	}

		//	await _landlordrepo.AddRangeAsync(landlords);
		//	await _apartmentrepo.AddRangeAsync(apartments);
		//	await _tenantRepo.AddRangeAsync(tenants);

		//	await _unitOfWork.SaveChangesAsync();
		//	return true;
		//}

		public async Task<EditToClientDto?> GetClientByIdAsync(Guid id)
		{
			var client = await _clientRepo.GetAsync(id);

			if (client == null) return null;
			return new EditToClientDto
			{
				
				FirstName = client.FirstName,
				LastName = client.LastName,
				Email = client.Email,
				Fax = client.Fax,
				Phone = client.Phone,
				CellPhone = client.CellPhone,
				ClientCode = client.ClientCode,
				Address1 = client.Address1,
				Address2 = client.Address2,
				City = client.City,
				StateId = client.StateId,
				StateName = client.State?.Name,
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

		public async Task<List<CreateToClientDto>> SearchClientByCode(string code)
		{
			var newtenant = await _clientRepo.SearchClientByCode(code);
			return newtenant;
		}

		public async Task<bool> Create(CreateToClientDto client)
		{
			var clientCode = await _clientRepo.GenerateClientCodeAsync();

			var newclient = new Client
			{
				ClientCode = clientCode,
				FirstName = client.FirstName,
				LastName = client.LastName,
				Email = client.Email,
				Address1 = client.Address1,
				Address2 = client.Address2,
				City = client.City,
				StateId = client.StateId,
				ZipCode = client.ZipCode,
				Phone = client.Phone,
				CellPhone = client.CellPhone,
				Fax = client.Fax,
			};

			var landlords = new List<LandLord>();
			var buildings = new List<Building>();
			var tenants = new List<Tenant>();

			// Generate landlord code
			var lastLandlordCode = await _landlordrepo.GetLastLandLordCodeAsync();
			int nextLandlordNumber = string.IsNullOrEmpty(lastLandlordCode) ? 1 : int.Parse(lastLandlordCode[2..]) + 1;

			// Generate building code
			var lastBuildingCode = await _buildingrepo.GetLastBuildingCodeAsync();
			int nextBuildingNumber = string.IsNullOrEmpty(lastBuildingCode) ? 1 : int.Parse(lastBuildingCode[2..]) + 1;

			// Generate tenant code
			var lastTenantCode = await _tenantRepo.GetLasttenantCodeAsync();
			int nextTenantNumber = string.IsNullOrEmpty(lastTenantCode) ? 1 : int.Parse(lastTenantCode[2..]) + 1;

			// Loop through landlords
			foreach (var l in client.LandLords)
			{
				var landlordCode = $"LL{nextLandlordNumber.ToString().PadLeft(10, '0')}";
				nextLandlordNumber++;

				var landlord = new LandLord
				{
					ClientId = l.ClientId,
					LandLordCode = landlordCode,
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
					TypeOfOwnerId = l.TypeOwnerId,
				};

				landlords.Add(landlord);

				if (l.Buildings != null)
				{
					foreach (var b in l.Buildings)
					{
						var buildingCode = $"BB{nextBuildingNumber.ToString().PadLeft(10, '0')}";
						nextBuildingNumber++;

						var building = new Building
						{
							Id = Guid.NewGuid(),
							BuildingCode = buildingCode,
							ApartmentCode = b.ApartmentCode,
							City = b.City,
							StateId = b.StateId,
							PremiseTypeId = b.PremiseTypeId,
							Address1 = b.Address1,
							Address2 = b.Address2,
							Zipcode = b.Zipcode,
							MDRNumber = b.MDRNumber,
							PetitionerInterest = b.PetitionerInterest,
							RegulationStatusId = b.RegulationStatusId,
							BuildingUnits = b.BuildingUnits,
							DateOfRefreeDeed = b.DateOfRefreeDeed,
							LandlordTypeId = b.LandlordTypeId,
							LandlordId = landlord.Id 
						};

						buildings.Add(building);

						if (b.Tenants != null)
						{
							foreach (var t in b.Tenants)
							{
								var tenantCode = $"TT{nextTenantNumber.ToString().PadLeft(10, '0')}";
								nextTenantNumber++;

								var tenant = new Tenant
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
									Address1 = t.Address1,
									Address2 = t.Address2,
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
								};

								tenants.Add(tenant);
							}
						}
					}
				}
			}

			await _clientRepo.AddAsync(newclient);
			await _landlordrepo.AddRangeAsync(landlords);
			await _buildingrepo.AddRangeAsync(buildings);
			await _tenantRepo.AddRangeAsync(tenants);

			var result = await _unitOfWork.SaveChangesAsync();
			return result > 0;
		}

		public Task<bool> UpdateClientAsync(EditToClientDto dto)
		{
			throw new NotImplementedException();
		}
	}
}
