using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace EvictionFiler.Application.Services
{
    public class ClientServices : IClientService
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IClientRepository _clientRepo;
		private readonly ILandLordRepository _landlordrepo;
		private readonly IBuildingRepository _buildingrepo;
		private readonly ITenantRepository _tenantRepo;
        private readonly IUserRepository _userRepo;
        private readonly IAdditionalTenantsRepository _additionalTenantsRepo;
		
		
		public ClientServices(
	   IClientRepository clientRepo, IUnitOfWork unitOfWork,
		ILandLordRepository landLordRepo,
		IBuildingRepository buildingrepo,
		ITenantRepository tenantRepo , IAdditionalTenantsRepository additionalTenantsRepo,   IUserRepository userRepo)
		{
			_clientRepo = clientRepo;
			_unitOfWork = unitOfWork;
			_landlordrepo = landLordRepo;
			_buildingrepo = buildingrepo;
			_tenantRepo = tenantRepo;
            _additionalTenantsRepo = additionalTenantsRepo;
			_userRepo = userRepo;
			
		}

        public async Task<List<EditToClientDto>> GetAllClient(string userId, bool isAdmin)
        {
            
            var query = _clientRepo.GetAllQuerable(x => x.IsDeleted != true, x => x.State);

            // ✅ Agar Admin nahi hai to sirf apne hi clients dikhaye
            if (!isAdmin && Guid.TryParse(userId, out Guid userGuid))
            {
                query = query.Where(x => x.User.FirmId == userGuid);
            }

            var landlords = await query
            .OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName)
            .Take(10)
            .ToListAsync();


            //var landlords = await query.ToListAsync();

            var result = landlords.Select(client => new EditToClientDto
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
                ZipCode = client.ZipCode,
                CreatedBy = client.CreatedBy,
                CreatedOn = client.CreatedOn,
				ClientTypeId = client.ClientTypeId,
				Reference = client.Reference,
            }).ToList();

            return result;
        }


        public async Task<PaginationDto<EditToClientDto>> GetAllClientsAsync(
    int pageNumber,
    int pageSize,
    string searchTerm,
    string userId,
    bool isAdmin)
        {
            var query = await _clientRepo.GetAllAsync(includes: [u => u.State!, u=>u.ClientType]);
            var users = await _userRepo.GetAllUser();
            var userDict = users.ToDictionary(u => u.Id, u => $"{u.FirstName} {u.MiddleName} {u.LastName}");

            if (!isAdmin)
            {
                query = query.Where(c => c.IsActive == true && c.IsDeleted == false);

                // ✅ Non-admin → Sirf apne hi clients dekhe
                if (!string.IsNullOrWhiteSpace(userId))
                {
                    var userGuid = Guid.Parse(userId);
                    query = query.Where(c => c.CreatedBy == userGuid);
                }
            }
            else
            {
                // ✅ Admin → Saare clients dikhenge, deleted + inactive bhi
                query = query.OrderByDescending(c => c.CreatedOn);
            }

            // Search filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var lowerSearch = searchTerm.ToLower();
                query = query.Where(client =>
                       (client.ClientCode ?? "").ToLower().Contains(lowerSearch) ||
                       (client.FirstName ?? "").ToLower().Contains(lowerSearch) ||
                       (client.LastName ?? "").ToLower().Contains(lowerSearch) ||
                       (client.Email ?? "").ToLower().Contains(lowerSearch) ||
                       (client.Phone ?? "").ToLower().Contains(lowerSearch) ||
                       (client.CellPhone ?? "").ToLower().Contains(lowerSearch) ||
                       (client.Fax ?? "").ToLower().Contains(lowerSearch) ||
                       (client.Address1 ?? "").ToLower().Contains(lowerSearch) ||
                       (client.Address2 ?? "").ToLower().Contains(lowerSearch) ||
                       (client.City ?? "").ToLower().Contains(lowerSearch) ||
                       (client.ZipCode ?? "").ToLower().Contains(lowerSearch) ||
                       ((client.State != null ? client.State.Name : "") ?? "").ToLower().Contains(lowerSearch) ||
                       ((client.IsActive ? "active" : "inactive").ToLower().Contains(lowerSearch))
                );
            }

            var totalCount = query.Count();

            var clients = query
                .OrderBy(c => c.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(client => new EditToClientDto
                {
                    Id = client.Id,
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
                    Status = client.IsActive,
                    CreatedBy = client.CreatedBy,
                    CreatedOn = client.CreatedOn,
					IsActive = client.IsActive,
					IsDeleted = client.IsDeleted,
                    CreatedByName = userDict.ContainsKey(client.CreatedBy)
                            ? userDict[client.CreatedBy]
                            : "Admin",
					ClientTypeName = client.ClientType !=null ? client.ClientType.Name : string.Empty,
					ClientTypeId = client.ClientTypeId ,
                })
                .ToList();

            return new PaginationDto<EditToClientDto>
            {
                Items = clients,
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = pageNumber
            };
        }

        public async Task<EditToClientDto?> GetClientByIdAsync(Guid? id)
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
				ZipCode = client.ZipCode,
                CreatedBy = client.CreatedBy,
                CreatedOn = client.CreatedOn,
				ClientTypeId = client.ClientTypeId,
				Reference = client.Reference,
            };
		}


        public async Task<bool> DeleteClientAsync(Guid id, bool isAdmin)
        {
            var client = await _clientRepo.GetAsync(id);
            if (client == null)
                return false;

            if (isAdmin)
            {
                // ✅ Get all landlords for this client
                var landlords = await _landlordrepo.GetAllAsync(l => l.ClientId == id);

                foreach (var landlord in landlords.ToList())
                {
                    // ✅ Get all buildings for this landlord
                    var buildings = await _buildingrepo.GetAllAsync(b => b.LandlordId == landlord.Id);

                    foreach (var building in buildings.ToList())
                    {
                        // ✅ Get all tenants for this building
                        var tenants = await _tenantRepo.GetAllAsync(t => t.BuildinId == building.Id);

                        foreach (var tenant in tenants.ToList())
                        {
                            // ✅ Get all additional tenants for this tenant
                            //var additionalTenants = await _additionalTenantsRepo.GetAllAsync(a => a.LegalCaseId == tenant.Id);

                            // ✅ Delete additional tenants first
                            //foreach (var additional in additionalTenants.ToList())
                            //{
                            //    await _additionalTenantsRepo.DeleteAsync(additional.Id);
                            //}

                            // ✅ Delete tenant after deleting additional tenants
                            await _tenantRepo.DeleteAsync(tenant.Id);
                        }

                        // ✅ Delete building after tenants deleted
                        await _buildingrepo.DeleteAsync(building.Id);
                    }

                    // ✅ Finally delete landlord after buildings deleted
                    await _landlordrepo.DeleteAsync(landlord.Id);
                }

                // ✅ Finally delete the client
                await _clientRepo.DeleteAsync(client.Id);
            }
            else
            {
                // ✅ Soft delete for normal user
                client.IsDeleted = true;
                client.IsActive = false;
            }

            var deletedRecords = await _unitOfWork.SaveChangesAsync();
            return deletedRecords > 0;
        }



        public async Task<List<EditToClientDto>> SearchClient(string searchTerm)
		{
			var newtenant = await _clientRepo.SearchClient(searchTerm);
			return newtenant;
		}

		public async Task<bool> Create(EditToClientDto client)
		{
			try
			{
				var clientCode = await _clientRepo.GenerateClientCodeAsync();

				var newclient = new Client
				{
					Id = Guid.NewGuid(),
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
					CreatedBy = client.CreatedBy,
					CreatedById = client.CreatedBy,
					CreatedOn = DateTime.Now,
					ClientTypeId = client.ClientTypeId,
				};

				await _clientRepo.AddAsync(newclient);
				//await _unitOfWork.SaveChangesAsync();

				var landlords = new List<LandLord>();
				var buildings = new List<Building>();
				var tenants = new List<Tenant>();
				var addtenants = new List<AdditioanlTenants>();

				//var lastLandlordCode = await _landlordrepo.GetLastLandLordCodeAsync();
				//int nextLandlordNumber = string.IsNullOrEmpty(lastLandlordCode) ? 1 : int.Parse(lastLandlordCode[2..]) + 1;

				//var lastBuildingCode = await _buildingrepo.GetLastBuildingCodeAsync();
				//int nextBuildingNumber = string.IsNullOrEmpty(lastBuildingCode) ? 1 : int.Parse(lastBuildingCode[2..]) + 1;

				//var lastTenantCode = await _tenantRepo.GetLasttenantCodeAsync();
				//int nextTenantNumber = string.IsNullOrEmpty(lastTenantCode) ? 1 : int.Parse(lastTenantCode[2..]) + 1;

				foreach (var l in client.editLandLords)
				{
					

					var landlord = new LandLord
					{
						Id = l.Id,
						ClientId = newclient.Id,
						LandLordCode = l.LandLordCode,
						FirstName = l.FirstName,
						LastName = l.LastName,
						EINorSSN = l.EINorSSN,
						Phone = l.Phone,
						Email = l.Email,
						Address1 = l.Address1,
						Address2 = l.Address2,
						StateId = l.StateId,
						CityId = l.CityId,
						Zipcode = l.Zipcode,
						ContactPersonName = l.ContactPersonName,
						LandlordTypeId = l.LandlordTypeId,
						DateOfRefreeDeed = l.DateOfRefreeDeed,
						TypeOfOwnerId = l.TypeOwnerId,
						CreatedOn = l.CreatedOn,
                        CreatedBy = l.CreatedBy,
                    };

					landlords.Add(landlord);

					if (l.editBuildings != null)
					{
						foreach (var b in l.editBuildings)
						{
							

							var building = new Building
							{
								Id = b.Id,
								BuildingCode = b.BuildingCode,
								ApartmentCode = b.ApartmentCode,
								CityId = b.CityId,
								StateId = b.StateId,
								PremiseTypeId = b.PremiseTypeId,
								Address1 = b.Address1,
								Address2 = b.Address2,
								Zipcode = b.Zipcode,
								MDRNumber = b.MDRNumber,
								PetitionerInterest = b.PetitionerInterest,
								RegulationStatusId = b.RegulationStatusId,
								BuildingUnits = b.BuildingUnits,
								ManagingAgent = b.ManagingAgent,
								RegistrationStatusId = b.RegistrationStatusId,
								ExemptionReasonId = b.ExemptionreasonId,
                                ExemptionBasisId =
        (b.RegulationStatusName == "Exempt")
            ? b.ExemptionBasisId
            : null,
                                PrimaryResidence = b.PrimaryResidence,
								OwnerOccupied = b.OwnerOccupied,
								RentRegulationDescription = b.RentRegulationDescription,
								TenancyTypeForBuildingId = b.TenancyTypeForBuildingId,
								GoodCause = b.GoodCause,
								LandlordId = landlord.Id,
								CreatedOn = landlord.CreatedOn,
                                CreatedBy = landlord.CreatedBy,
                            };

							buildings.Add(building);

							if (b.editTenants != null)
							{
								foreach (var t in b.editTenants)
								{
									var tenant = new Tenant
									{
										Id = t.Id.Value,
										TenantCode = t.TenantCode,
										FirstName = t.FirstName,
										LastName = t.LastName,
										SSN = t.SSN,
										Phone = t.Phone,
										Email = t.Email,
										LanguageId = t.LanguageId,
									
										HasPossession = t.HasPossession,
										HasRegulatedTenancy = t.HasRegulatedTenancy,
										MoveInDate = t.MoveInDate,
										OtherOccupants = t.OtherOccupants,
								        
										TenantRecord = t.TenantRecord,
										HasPriorCase = t.HasPriorCase,
										TenancyTypeId = t.TenancyTypeId,
										RenewalOffer = t.RenewalOffer,
										Additionaltenants = t.AdditionalTenant,
										RentDueEachMonthOrWeekId = t.RentDueEachMonthOrWeekId,
										SocialServices = t.SocialServices,
										MonthlyRent = t.MonthlyRent,
									
										TenantShare = t.TenantShare,
										IsERAPPaymentReceived = t.IsERAPPaymentReceived,
										ERAPPaymentReceivedDate = t.ERAPPaymentReceivedDate,
										UnitOrApartmentNumber = t.UnitOrApartmentNumber,
									
										IsUnitIllegalId = t.IsUnitIllegalId,
										BuildinId = building.Id,
										CreatedOn = building.CreatedOn,
                                        CreatedBy = building.CreatedBy,

                                    };
										if (t.AdditioalTenants != null)
									    {
										    foreach (var o in t.AdditioalTenants)
										    {
										    	var additionaltenants = new AdditioanlTenants
											       {
											       	//Id = o.Id,
											       	FirstName = o.FirstName,
											       	LastName = o.LastName,
											       	TenantId = tenant.Id,
													CreatedOn = o.CreatedOn,
													CreatedBy = o.CreatedBy,
											       };

                                            addtenants.Add(additionaltenants);
										    };

										tenants.Add(tenant);
									}
								}
							}
						}
					}
				}

				await _landlordrepo.AddRangeAsync(landlords);
				await _buildingrepo.AddRangeAsync(buildings);
				await _tenantRepo.AddRangeAsync(tenants);
				await _additionalTenantsRepo.AddRangeAsync(addtenants);

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

		public async Task<Guid> CreateOnlyClient(CreateToClientDto client)
		{
			try
			{
				var clientCode = await _clientRepo.GenerateClientCodeAsync();

				var newclient = new Client
				{
					Id = Guid.NewGuid(),
					ClientCode = clientCode,
					FirstName = client.FirstName,
					LastName = client.LastName,
					Email = client.Email,
					Address1 = client.Address1,
					Address2 = client.Address2,
					City = client.City,
					Reference= client.Reference,
					StateId = client.StateId,
					ZipCode = client.ZipCode,
					Phone = client.Phone,
					CellPhone = client.CellPhone,
					ClientTypeId = client.ClientTypeId,
					Fax = client.Fax,
					CreatedBy = client.CreatedBy,
					CreatedOn = DateTime.Now
				};

				await _clientRepo.AddAsync(newclient);
				await _unitOfWork.SaveChangesAsync();

				return newclient.Id;
			}
			catch (Exception ex)
			{
				throw new Exception();

			};
		}

		public async Task<bool> UpdateClientformCase(EditToClientDto client)
		{
			var existingClient = await _clientRepo.GetClientWithAllDetailsAsync(client.Id);
			if (existingClient == null) return false;
			//List<Guid> landlordIds = existingClient.LandLords.Select(e => e.Id).ToList();
			//List<Guid> existingBuildingIds = new List<Guid>();
			//List<Guid> existingTenantsIds = new List<Guid>();
			//foreach (var l in existingClient.LandLords)
			//{
			//	var BuildingIds = l.Buildings.Select(e => e.Id).ToList();
			//	existingBuildingIds.AddRange(BuildingIds);
			//	foreach (var j in l.Buildings)
			//	{
			//		var TenantsIds = j.Tenants.Select(e => e.Id).ToList();
			//		existingTenantsIds.AddRange(TenantsIds);
			//	}
			//}
			// 1. Update Client basic info
			if(existingClient.FirstName != client.FirstName)existingClient.FirstName = client.FirstName;
            if (existingClient.LastName != client.LastName) existingClient.LastName = client.LastName;
            if (existingClient.Email != client.Email) existingClient.Email = client.Email;
			if (existingClient.Phone != client.Phone) existingClient.Phone = client.Phone;
            if (existingClient.Reference != client.Reference) existingClient.Reference = client.Reference;
            if (existingClient.ClientTypeId != client.ClientTypeId) existingClient.ClientTypeId = client.ClientTypeId;



            var updateclient = _clientRepo.UpdateAsync(existingClient);
			if(updateclient == null) return false;

			await _unitOfWork.SaveChangesAsync();
			return true;
		}
		

        public async Task<bool> UpdateClientAsync(EditToClientDto client)
		{
			var existingClient = await _clientRepo.GetClientWithAllDetailsAsync(client.Id);
			if (existingClient == null) return false;
            List<Guid> landlordIds = existingClient.LandLords.Select(e => e.Id).ToList();
            List<Guid> existingBuildingIds = new List<Guid>();
            List<Guid> existingTenantsIds = new List<Guid>();
            foreach (var l in existingClient.LandLords)
            {
                var BuildingIds = l.Buildings.Select(e => e.Id).ToList();
				existingBuildingIds.AddRange(BuildingIds);
                foreach (var j in l.Buildings)
                {
                    var TenantsIds = j.Tenants.Select(e => e.Id).ToList();
                    existingTenantsIds.AddRange(TenantsIds);
                }
            }
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
			existingClient.UpdatedBy = client.UpdatedBy;
    
            existingClient.CreatedOn = client.CreatedOn;


            _clientRepo.UpdateAsync(existingClient);
			await _unitOfWork.SaveChangesAsync();

			var landlordsToAdd = new List<LandLord>();
			var landlordsToUpdate = new List<LandLord>();
			var buildingsToAdd = new List<Building>();
			var buildingsToUpdate = new List<Building>();
			var tenantsToAdd = new List<Tenant>();
			var tenantsToUpdate = new List<Tenant>();
			var addtenantsToAdd = new List<AdditioanlTenants>();
			var addtenantsToupdate = new List<AdditioanlTenants>();

			



			foreach (var l in client.editLandLords)
			{
				bool isNewLandlord = false;

                if (!landlordIds.Contains(l.Id))
				{
                     isNewLandlord = true;
                }
				

				var landlord = new LandLord
				{
					Id = isNewLandlord ? Guid.NewGuid() : l.Id,
					ClientId = existingClient.Id,
					LandLordCode = l.LandLordCode,
					FirstName = l.FirstName,
					LastName = l.LastName,
					EINorSSN = l.EINorSSN,
					Phone = l.Phone,
					Email = l.Email,
					Address1 = l.Address1,
					Address2 = l.Address2,
					StateId = l.StateId,
					CityId = l.CityId,
					Zipcode = l.Zipcode,
					ContactPersonName = l.ContactPersonName,
					TypeOfOwnerId = l.TypeOwnerId,
					LandlordTypeId = l.LandlordTypeId,
				
				};

				if (isNewLandlord)
				{
					landlordsToAdd.Add(landlord);
					//nextLandlordNumber++;
				}
				else
				{
					landlordsToUpdate.Add(landlord);
				}

				if (l.editBuildings != null)
				{
					
					bool isNewBuilding = false;

                    foreach (var b in l.editBuildings)
					{
						if(!existingBuildingIds.Contains(b.Id))
						{
                            isNewBuilding = true;
                        }

						var building = new Building
						{
							Id = isNewBuilding ? Guid.NewGuid() : b.Id,
							BuildingCode = b.BuildingCode,
							ApartmentCode = b.ApartmentCode,
							CityId = b.CityId,
							StateId = b.StateId,
							PremiseTypeId = b.PremiseTypeId,
							Address1 = b.Address1,
							Address2 = b.Address2,
							Zipcode = b.Zipcode,
							MDRNumber = b.MDRNumber,
							PetitionerInterest = b.PetitionerInterest,
							RegulationStatusId = b.RegulationStatusId,
							RegistrationStatusId = b.RegistrationStatusId,
							ManagingAgent = b.ManagingAgent,
							BuildingUnits = b.BuildingUnits,
						    ExemptionReasonId = b.ExemptionreasonId,
                            ExemptionBasisId = b.ExemptionBasisId,
                            PrimaryResidence = b.PrimaryResidence,
                            OwnerOccupied = b.OwnerOccupied,
							TenancyTypeForBuildingId = b.TenancyTypeForBuildingId,
                            GoodCause = b.GoodCause,
                            RentRegulationDescription = b.RentRegulationDescription,
                            LandlordId = landlord.Id
						};

						if (isNewBuilding)
						{
							buildingsToAdd.Add(building);
							//nextBuildingNumber++;
						}
						else
						{
							buildingsToUpdate.Add(building);
						}

						if (b.editTenants != null)
						{
                            bool isNewTenant = false;
							foreach (var t in b.editTenants)
							{
								if (!existingTenantsIds.Contains(t.Id.Value))
								{
									isNewTenant = true;
								}

								var tenant = new Tenant
								{
									Id = isNewTenant ? Guid.NewGuid() : t.Id.Value,
									TenantCode = t.TenantCode,
									FirstName = t.FirstName,
									LastName = t.LastName,

									SSN = t.SSN,
									Phone = t.Phone,
									Email = t.Email,
									LanguageId = t.LanguageId,
							
									RentDueEachMonthOrWeekId = t.RentDueEachMonthOrWeekId,
									HasPossession = t.HasPossession,
									HasRegulatedTenancy = t.HasRegulatedTenancy,
								
									Additionaltenants = t.AdditionalTenant,
									OtherOccupants = t.OtherOccupants,
									
									TenantRecord = t.TenantRecord,
									HasPriorCase = t.HasPriorCase,
									TenancyTypeId = t.TenancyTypeId,
									RenewalOffer = t.RenewalOffer,
									PrimaryResidence = t.PrimaryResidence,
									SocialServices = t.SocialServices,
									MonthlyRent = t.MonthlyRent,
									MoveInDate  = t.MoveInDate,
									TenantShare = t.TenantShare,
									ERAPPaymentReceivedDate = t.ERAPPaymentReceivedDate,
									UnitOrApartmentNumber = t.UnitOrApartmentNumber,
								
									IsUnitIllegalId = t.IsUnitIllegalId,
									BuildinId = building.Id
								};
								if (t.AdditioalTenants != null)
								{
									foreach (var o in t.AdditioalTenants)
									{
										if (o.Id == Guid.Empty) // New
										{
                                            var additionaltenants = new AdditioanlTenants
                                            {
                                                //Id = o.Id,
                                                FirstName = o.FirstName,
                                                LastName = o.LastName,
                                                TenantId = tenant.Id,
                                            };
                                            addtenantsToAdd.Add(additionaltenants);

										}
										else 
										{
											var existingOcc = await _additionalTenantsRepo.GetAsync(o.Id);
											if (existingOcc != null)
											{
												existingOcc.FirstName = o.FirstName;
												existingOcc.LastName = o.LastName;
												existingOcc.TenantId = tenant.Id;
                                                addtenantsToupdate.Add(existingOcc);

											}
											else
											{
												// Id sent from UI but record missing in DB
												// Either ignore or treat as new
											}
										}
									}

								}

								if (isNewTenant)
								{
									tenantsToAdd.Add(tenant);
									//nextTenantNumber++;
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

			if (addtenantsToAdd.Any())
				await _additionalTenantsRepo.AddRangeAsync(addtenantsToAdd);
			if (addtenantsToupdate.Any())
				_additionalTenantsRepo.UpdateRange(addtenantsToupdate);

			await _unitOfWork.SaveChangesAsync();
			return true;
		}

        public async Task<bool> IsEmailExists(string email)
        {
            var existemail = await _clientRepo.IsEmailExists(email);
			return existemail;
        }


    }
}
