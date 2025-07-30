using System.Numerics;
using System.Runtime.Intrinsics.X86;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Application.Services
{
    public class TenantService : ITenantService
    {
		private readonly ITenantRepository _repo;
		private readonly IUnitOfWork _unitOfWork;

		public TenantService(ITenantRepository services , IUnitOfWork unitOfWork)
		{
			_repo = services;
			_unitOfWork = unitOfWork;
		}
	public async Task<bool> AddTenantAsync(List<CreateToTenantDto> dtoList)
		{
			var newtenant = new List<Tenant>();

			var lastCode = await _repo.GetLasttenantCodeAsync();

			int nextNumber = 1;
			if (!string.IsNullOrEmpty(lastCode) && lastCode.Length > 2)
			{
				var numericPart = lastCode.Substring(2);
				if (int.TryParse(numericPart, out int lastNumber))
				{
					nextNumber = lastNumber + 1;
				}
			}

			foreach (var t in dtoList)
			{
				var code = $"TT{nextNumber.ToString().PadLeft(10, '0')}";
				nextNumber++; // ✅ increment locally

				var tenant = new Tenant
				{
					
					TenantCode = code,
					FirstName = t.FirstName,
					LastName = t.LastName,
					SSN = t.SSN,
					Phone = t.Phone,
					Email = t.Email,
					LanguageId = t.LanguageId,
					Borough = t.Borough,
					HasPossession = t.HasPossession,
					HasRegulatedTenancy = t.HasRegulatedTenancy,
					Name_Relation = t.Name_Relation,
					OtherOccupants = t.OtherOccupants,
					Registration_No = t.Registration_No,
					TenantRecord = t.TenantRecord,
					HasPriorCase = t.HasPriorCase,
					TenancyTypeId = t.TenancyTypeId,
					RenewalOffer = t.RenewalOffer,
					RentDueEachMonthOrWeek = t.RentDueEachMonthOrWeek,
					SocialServices = t.SocialServices,
					MonthlyRent = t.MonthlyRent,
					LastMonthWeekRentPaid = t.LastMonthWeekRentPaid,
					TenantShare = t.TenantShare,
					ERAPPaymentReceivedDate = t.ERAPPaymentReceivedDate,
					UnitOrApartmentNumber = t.UnitOrApartmentNumber,
					TotalRentOwed = t.TotalRentOwed,
					IsUnitIllegalId = t.IsUnitIllegalId,
					BuildinId = t.BuildingId,
				};

				newtenant.Add(tenant);
			}

			await _repo.AddRangeAsync(newtenant);
			var result = await _unitOfWork.SaveChangesAsync();

			return result > 0;
		}

		public async Task<List<CreateToTenantDto>> SearchTenantbyCode(string code)
		{
			var newtenant = await _repo.SearchTenantByCode(code);
			return newtenant;
		}

		public async Task<List<EditToTenantDto>> SearchTenantsAsync(string query, Guid clientId)
		{
			return await _repo.SearchTenantAsync(query, clientId);
		}

		public async Task<EditToTenantDto> GetByIdAsync(Guid id)
		{
			var t = await _repo
				.GetAllQuerable(
					x => x.Id == id,
					x => x.TenancyType,
					x => x.IsUnitIllegal,
					x => x.Building, // Include Building
					x => x.Building.State,
					x  => x.Building.PremiseType, // Include State of Building
					x => x.Building.RegulationStatus, // Include RegulationStatus of Building
					x => x.Building.Landlord, // Include Landlord
					x => x.Building.Landlord.State, // Include State of Landlord
					x => x.Building.Landlord.LandlordType ,
					x=>x.Building.Landlord.TypeOfOwner// Include Landlord Type
				)
				.FirstOrDefaultAsync();

			if (t == null)
				return null;

			return new EditToTenantDto
			{
				Id = t.Id,
				TenantCode = t.TenantCode,
				FirstName = t.FirstName,
				LastName = t.LastName,
				SSN = t.SSN,
				Phone = t.Phone,
				Email = t.Email,
				LanguageId = t.LanguageId,
				Borough = t.Borough,
				HasPossession = t.HasPossession,
				HasRegulatedTenancy = t.HasRegulatedTenancy,
				Name_Relation = t.Name_Relation,
				OtherOccupants = t.OtherOccupants,
				Registration_No = t.Registration_No,
				TenantRecord = t.TenantRecord,
				HasPriorCase = t.HasPriorCase,
				TenancyTypeId = t.TenancyTypeId,
				TenancyTypeName = t.TenancyType?.Name,
				RenewalOffer = t.RenewalOffer,
				RentDueEachMonthOrWeek = t.RentDueEachMonthOrWeek,
				SocialServices = t.SocialServices,
				MonthlyRent = t.MonthlyRent,
				LastMonthWeekRentPaid = t.LastMonthWeekRentPaid,
				TenantShare = t.TenantShare,
				ERAPPaymentReceivedDate = t.ERAPPaymentReceivedDate,
				UnitOrApartmentNumber = t.UnitOrApartmentNumber,
				TotalRentOwed = t.TotalRentOwed,
				IsUnitIllegalId = t.IsUnitIllegalId,
				IsUnitIllegalName = t.IsUnitIllegal?.Name,
				BuildingId = t.BuildinId,

				Building = new EditToBuildingDto
				{
					Id = t.Building.Id,
					BuildingCode = t.Building.BuildingCode,
					ApartmentCode = t.Building.ApartmentCode,
					PremiseTypeId = t.Building.PremiseTypeId,
					PremiseTypeName = t.Building.PremiseType.Name,
					RegulationStatusId = t.Building.RegulationStatusId,
					PetitionerInterest = t.Building.PetitionerInterest,
					LandlordId = t.Building.LandlordId,
					Address1 = t.Building.Address1,
					Address2 = t.Building.Address2,
					StateId = t.Building.StateId,
					StateName = t.Building.State?.Name,
					City = t.Building.City,
					Zipcode = t.Building.Zipcode,
					MDRNumber = t.Building.MDRNumber,
					BuildingUnits = t.Building.BuildingUnits,
					RegulationStatusName = t.Building.RegulationStatus?.Name,
				},

				Landlord = new EditToLandlordDto
				{
					Id = t.Building.Landlord.Id,
					LandLordCode = t.Building.Landlord.LandLordCode,
					FirstName = t.Building.Landlord.FirstName,
					LastName = t.Building.Landlord.LastName,
					TypeOwnerId= t.Building.Landlord.TypeOfOwnerId,
					TypeOwnerName = t.Building.Landlord.TypeOfOwner.Name,
					Email = t.Building.Landlord.Email,
					ContactPersonName = t.Building.Landlord.ContactPersonName,
					EINorSSN = t.Building.Landlord.EINorSSN,
					Address1 = t.Building.Landlord.Address1,
					Address2 = t.Building.Landlord.Address2,
					StateId = t.Building.Landlord.StateId,
					StateName = t.Building.Landlord.State?.Name,
					City = t.Building.Landlord.City,
					Zipcode = t.Building.Landlord.Zipcode,
					Phone = t.Building.Landlord.Phone,
					ClientId = t.Building.Landlord.ClientId,
					LandlordTypeId = t.Building.Landlord.LandlordTypeId,
					LandlordTypeName = t.Building.Landlord.LandlordType?.Name,
					DateOfRefreeDeed = t.Building.Landlord.DateOfRefreeDeed,
				},
			};
		}




		public async Task<List<EditToTenantDto>> GetTenantsByClientIdAsync(Guid clientId)
		{
			var tenants = await _repo.GetTenantsByClientIdAsync(clientId);
			return tenants;


		}
		public async Task<bool> UpdateTenantAsync(List<EditToTenantDto> dtoList)

		{
			foreach (var t in dtoList)
			{
				var entity = await _repo.GetAsync(t.Id);
				if (entity != null)
				{
					entity.TenantCode = t.TenantCode;
					entity.FirstName = t.FirstName;
					entity.LastName = t.LastName;
					entity.SSN = t.SSN;
					entity.Phone = t.Phone;
					entity.Email = t.Email;
					entity.LanguageId = t.LanguageId;
					entity.Borough = t.Borough;
					entity.HasPossession = t.HasPossession;
					entity.HasRegulatedTenancy = t.HasRegulatedTenancy;
					entity.Name_Relation = t.Name_Relation;
					entity.OtherOccupants = t.OtherOccupants;
					entity.Registration_No = t.Registration_No;
					entity.TenantRecord = t.TenantRecord;
					entity.HasPriorCase = t.HasPriorCase;
					entity.TenancyTypeId = t.TenancyTypeId;
					entity.RenewalOffer = t.RenewalOffer;
					entity.RentDueEachMonthOrWeek = t.RentDueEachMonthOrWeek;
					entity.SocialServices = t.SocialServices;
					entity.MonthlyRent = t.MonthlyRent;
					entity.LastMonthWeekRentPaid = t.LastMonthWeekRentPaid;
					entity.TenantShare = t.TenantShare;
					entity.ERAPPaymentReceivedDate = t.ERAPPaymentReceivedDate;
					entity.UnitOrApartmentNumber = t.UnitOrApartmentNumber;
					entity.TotalRentOwed = t.TotalRentOwed;
					entity.IsUnitIllegalId = t.IsUnitIllegalId;
					entity.BuildinId = t.BuildingId;
				}

				_repo.UpdateAsync(entity);
				await _unitOfWork.SaveChangesAsync();
			}
			return true;
	}
	
		public async Task<List<CreateToTenantDto>> GetAll()
		{
			var query = await _repo.GetAllAsync();
			return query.Select(t => new CreateToTenantDto
			{
				TenantCode = t.TenantCode,
				FirstName = t.FirstName,
				LastName = t.LastName,
			
				SSN = t.SSN,
				Phone = t.Phone,
				Email = t.Email,
				LanguageId = t.LanguageId,
				Borough = t.Borough,
				
				HasPossession = t.HasPossession,
				HasRegulatedTenancy = t.HasRegulatedTenancy,
				Name_Relation = t.Name_Relation,
				OtherOccupants = t.OtherOccupants,
				Registration_No = t.Registration_No,
				TenantRecord = t.TenantRecord,
				HasPriorCase = t.HasPriorCase,
				TenancyTypeId = t.TenancyTypeId,
				RenewalOffer = t.RenewalOffer,
				RentDueEachMonthOrWeek = t.RentDueEachMonthOrWeek,
				SocialServices = t.SocialServices,
				MonthlyRent = t.MonthlyRent,
				LastMonthWeekRentPaid = t.LastMonthWeekRentPaid,
				TenantShare = t.TenantShare,
				ERAPPaymentReceivedDate = t.ERAPPaymentReceivedDate,
				UnitOrApartmentNumber = t.UnitOrApartmentNumber,
				TotalRentOwed = t.TotalRentOwed,
				IsUnitIllegalId = t.IsUnitIllegalId,
				BuildingId = t.BuildinId,
			}).ToList();
		}
	}
}
