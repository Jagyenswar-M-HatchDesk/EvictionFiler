using System.Net;
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
				  Id= client.Id,
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

		//	await _clientRepo.UpdateAsync(existingClient);
		//	await _unitOfWork.SaveChangesAsync();


		//	var landlords = new List<LandLord>();
		//	var buildings = new List<Building>();
		//	var tenants = new List<Tenant>();

		//	var lastLandlordCode = await _landlordrepo.GetLastLandLordCodeAsync();
		//	int nextLandlordNumber = string.IsNullOrEmpty(lastLandlordCode) ? 1 : int.Parse(lastLandlordCode[2..]) + 1;

		//	var lastBuildingCode = await _buildingrepo.GetLastBuildingCodeAsync();
		//	int nextBuildingNumber = string.IsNullOrEmpty(lastBuildingCode) ? 1 : int.Parse(lastBuildingCode[2..]) + 1;

		//	var lastTenantCode = await _tenantRepo.GetLasttenantCodeAsync();
		//	int nextTenantNumber = string.IsNullOrEmpty(lastTenantCode) ? 1 : int.Parse(lastTenantCode[2..]) + 1;

		//	foreach (var l in client.editLandLords)
		//	{
		//		var landlordCode = $"LL{nextLandlordNumber.ToString().PadLeft(10, '0')}";
		//		nextLandlordNumber++;

		//		var landlord = new LandLord
		//		{
		//			Id = l.Id,
		//			ClientId = newclient.Id,
		//			LandLordCode = landlordCode,
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
		//		};

		//		landlords.Add(landlord);

		//		if (l.editBuildings != null)
		//		{
		//			foreach (var b in l.editBuildings)
		//			{
		//				var buildingCode = $"BB{nextBuildingNumber.ToString().PadLeft(10, '0')}";
		//				nextBuildingNumber++;

		//				var building = new Building
		//				{
		//					Id = b.Id,
		//					BuildingCode = buildingCode,
		//					ApartmentCode = b.ApartmentCode,
		//					City = b.City,
		//					StateId = b.StateId,
		//					PremiseTypeId = b.PremiseTypeId,
		//					Address1 = b.Address1,
		//					Address2 = b.Address2,
		//					Zipcode = b.Zipcode,
		//					MDRNumber = b.MDRNumber,
		//					PetitionerInterest = b.PetitionerInterest,
		//					RegulationStatusId = b.RegulationStatusId,
		//					BuildingUnits = b.BuildingUnits,
		//					DateOfRefreeDeed = b.DateOfRefreeDeed,
		//					LandlordTypeId = b.LandlordTypeId,
		//					LandlordId = landlord.Id
		//				};

		//				buildings.Add(building);

		//				if (b.editTenants != null)
		//				{
		//					foreach (var t in b.editTenants)
		//					{
		//						var tenantCode = $"TT{nextTenantNumber.ToString().PadLeft(10, '0')}";
		//						nextTenantNumber++;

		//						var tenant = new Tenant
		//						{
		//							Id = t.Id,
		//							TenantCode = tenantCode,
		//							FirstName = t.FirstName,
		//							LastName = t.LastName,
		//							DOB = t.DOB,
		//							SSN = t.SSN,
		//							Phone = t.Phone,
		//							Email = t.Email,
		//							LanguageId = t.LanguageId,
		//							StateId = t.StateId,
		//							Address1 = t.Address1,
		//							Address2 = t.Address2,
		//							City = t.City,
		//							Zipcode = t.Zipcode,
		//							Apt = t.Apt,
		//							Borough = t.Borough,
		//							Rent = t.Rent,
		//							HasPossession = t.HasPossession,
		//							HasRegulatedTenancy = t.HasRegulatedTenancy,
		//							Name_Relation = t.Name_Relation,
		//							OtherOccupants = t.OtherOccupants,
		//							Registration_No = t.Registration_No,
		//							TenantRecord = t.TenantRecord,
		//							HasPriorCase = t.HasPriorCase,
		//							BuildinId = building.Id
		//						};

		//						tenants.Add(tenant);
		//					}
		//				}
		//			}
		//		}
			
		//	}

		//	await _landlordrepo.AddRangeAsync(landlords);
		//	await _buildingrepo.AddRangeAsync(buildings);
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
				Id = client.Id,
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

		public async Task<bool> Create(EditToClientDto client)
		{
			try
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

				await _clientRepo.AddAsync(newclient);
				await _unitOfWork.SaveChangesAsync();

				var landlords = new List<LandLord>();
				var buildings = new List<Building>();
				var tenants = new List<Tenant>();

				var lastLandlordCode = await _landlordrepo.GetLastLandLordCodeAsync();
				int nextLandlordNumber = string.IsNullOrEmpty(lastLandlordCode) ? 1 : int.Parse(lastLandlordCode[2..]) + 1;

				var lastBuildingCode = await _buildingrepo.GetLastBuildingCodeAsync();
				int nextBuildingNumber = string.IsNullOrEmpty(lastBuildingCode) ? 1 : int.Parse(lastBuildingCode[2..]) + 1;

				var lastTenantCode = await _tenantRepo.GetLasttenantCodeAsync();
				int nextTenantNumber = string.IsNullOrEmpty(lastTenantCode) ? 1 : int.Parse(lastTenantCode[2..]) + 1;

				foreach (var l in client.editLandLords)
				{
					var landlordCode = $"LL{nextLandlordNumber.ToString().PadLeft(10, '0')}";
					nextLandlordNumber++;

					var landlord = new LandLord
					{
						Id = l.Id,
						ClientId = newclient.Id,
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

					if (l.editBuildings != null)
					{
						foreach (var b in l.editBuildings)
						{
							var buildingCode = $"BB{nextBuildingNumber.ToString().PadLeft(10, '0')}";
							nextBuildingNumber++;

							var building = new Building
							{
								Id = b.Id,
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

							if (b.editTenants != null)
							{
								foreach (var t in b.editTenants)
								{
									var tenantCode = $"TT{nextTenantNumber.ToString().PadLeft(10, '0')}";
									nextTenantNumber++;

									var tenant = new Tenant
									{
										Id = t.Id,
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
										BuildinId = building.Id
									};

									tenants.Add(tenant);
								}
							}
						}
					}
				}

				await _landlordrepo.AddRangeAsync(landlords);
				await _buildingrepo.AddRangeAsync(buildings);
				await _tenantRepo.AddRangeAsync(tenants);

				var result = await _unitOfWork.SaveChangesAsync();
				return result > 0;
			}
			catch (Exception ex)
			{
				// Optionally log the error
				Console.WriteLine($"Error in Create(): {ex.Message}");
				return false;
			}
		}

		public async Task<bool> UpdateClientAsync(EditToClientDto client)
		{
			var existingClient = await _clientRepo.GetClientWithAllDetailsAsync(client.Id);
			if (existingClient == null) return false;

			// 1. Update Client basic info
			existingClient.FirstName = client.FirstName;
			existingClient.LastName = client.LastName;
			existingClient.Email = client.Email;
			existingClient.Address1 = client.Address1;
			existingClient.Address2 = client.Address2;
			existingClient.City = client.City;
			existingClient.StateId = client.StateId;
			existingClient.ZipCode = client.ZipCode;
			existingClient.Phone = client.Phone;
			existingClient.CellPhone = client.CellPhone;
			existingClient.Fax = client.Fax;

			_clientRepo.UpdateAsync(existingClient);
			await _unitOfWork.SaveChangesAsync();

			var landlordsToAdd = new List<LandLord>();
			var landlordsToUpdate = new List<LandLord>();
			var buildingsToAdd = new List<Building>();
			var buildingsToUpdate = new List<Building>();
			var tenantsToAdd = new List<Tenant>();
			var tenantsToUpdate = new List<Tenant>();

			var lastLandlordCode = await _landlordrepo.GetLastLandLordCodeAsync();
			int nextLandlordNumber = string.IsNullOrEmpty(lastLandlordCode) ? 1 : int.Parse(lastLandlordCode[2..]) + 1;

			var lastBuildingCode = await _buildingrepo.GetLastBuildingCodeAsync();
			int nextBuildingNumber = string.IsNullOrEmpty(lastBuildingCode) ? 1 : int.Parse(lastBuildingCode[2..]) + 1;

			var lastTenantCode = await _tenantRepo.GetLasttenantCodeAsync();
			int nextTenantNumber = string.IsNullOrEmpty(lastTenantCode) ? 1 : int.Parse(lastTenantCode[2..]) + 1;

			foreach (var l in client.editLandLords)
			{
				bool isNewLandlord = l.Id == Guid.Empty;

				var landlord = new LandLord
				{
					Id = isNewLandlord ? Guid.NewGuid() : l.Id,
					ClientId = existingClient.Id,
					LandLordCode = isNewLandlord ? $"LL{nextLandlordNumber.ToString().PadLeft(10, '0')}" : l.LandLordCode,
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
					TypeOfOwnerId = l.TypeOwnerId
				};

				if (isNewLandlord)
				{
					landlordsToAdd.Add(landlord);
					nextLandlordNumber++;
				}
				else
				{
					landlordsToUpdate.Add(landlord);
				}

				if (l.editBuildings != null)
				{
					foreach (var b in l.editBuildings)
					{
						bool isNewBuilding = b.Id == Guid.Empty;

						var building = new Building
						{
							Id = isNewBuilding ? Guid.NewGuid() : b.Id,
							BuildingCode = isNewBuilding ? $"BB{nextBuildingNumber.ToString().PadLeft(10, '0')}" : b.BuildingCode,
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

						if (isNewBuilding)
						{
							buildingsToAdd.Add(building);
							nextBuildingNumber++;
						}
						else
						{
							buildingsToUpdate.Add(building);
						}

						if (b.editTenants != null)
						{
							foreach (var t in b.editTenants)
							{
								bool isNewTenant = t.Id == Guid.Empty;

								var tenant = new Tenant
								{
									Id = isNewTenant ? Guid.NewGuid() : t.Id,
									TenantCode = isNewTenant ? $"TT{nextTenantNumber.ToString().PadLeft(10, '0')}" : t.TenantCode,
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
									BuildinId = building.Id
								};

								if (isNewTenant)
								{
									tenantsToAdd.Add(tenant);
									nextTenantNumber++;
								}
								else
								{
									tenantsToUpdate.Add(tenant);
								}
							}
						}
					}
				}
			}

			// Save Landlords
			if (landlordsToAdd.Any())
				await _landlordrepo.AddRangeAsync(landlordsToAdd);
			if (landlordsToUpdate.Any())
				_landlordrepo.UpdateRange(landlordsToUpdate);

			// Save Buildings
			if (buildingsToAdd.Any())
				await _buildingrepo.AddRangeAsync(buildingsToAdd);
			if (buildingsToUpdate.Any())
				_buildingrepo.UpdateRange(buildingsToUpdate);

			// Save Tenants
			if (tenantsToAdd.Any())
				await _tenantRepo.AddRangeAsync(tenantsToAdd);
			if (tenantsToUpdate.Any())
				_tenantRepo.UpdateRange(tenantsToUpdate);

			await _unitOfWork.SaveChangesAsync();
			return true;
		}



	}
}
