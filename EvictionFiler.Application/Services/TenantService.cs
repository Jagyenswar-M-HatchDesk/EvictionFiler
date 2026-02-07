using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.MasterDtos.CountyDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Application.Interfaces.IUserRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EvictionFiler.Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public TenantService(ITenantRepository services, IUnitOfWork unitOfWork)
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

                    HasPossession = t.HasPossession,
                    HasRegulatedTenancy = t.HasRegulatedTenancy,
                    //Name_Relation = t.Name_Relation,
                    OtherOccupants = t.OtherOccupants,

                    TenantRecord = t.TenantRecord,
                    HasPriorCase = t.HasPriorCase,
                    TenancyTypeId = t.TenancyTypeId,
                    RenewalOffer = t.RenewalOffer,
                    //RentDueEachMonthOrWeek = t.RentDueEachMonthOrWeek,
                    SocialServices = t.SocialServices,
                    MonthlyRent = t.MonthlyRent,

                    TenantShare = t.TenantShare,
                    ERAPPaymentReceivedDate = t.ERAPPaymentReceivedDate,
                    UnitOrApartmentNumber = t.UnitOrApartmentNumber,

                    IsUnitIllegalId = t.IsUnitIllegalId,
                    BuildinId = t.BuildingId,
                };

                newtenant.Add(tenant);
            }

            await _repo.AddRangeAsync(newtenant);
            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }


        public async Task<Guid?> AddTenantfromCase(CreateToTenantDto e)
        {
            //var newtenant = new List<Tenant>();

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


            var code = $"TT{nextNumber.ToString().PadLeft(10, '0')}";
            nextNumber++; // ✅ increment locally

            var tenant = new Tenant
            {

                TenantCode = code,
                FirstName = e.FirstName,
                LastName = e.LastName,
                UnitOrApartmentNumber = e.UnitOrApartmentNumber,
                BuildinId = e.BuildingId,
                PrimaryResidence = e.PrimaryResidence,
                TenancyTypeId = e.TenancyTypeId,
                MonthlyRent = e.MonthlyRent,
                TenantShare = e.TenantShare,
                RentDueEachMonthOrWeekId = e.RentDueEachMonthOrWeekId,


            };
            //newtenant.Add(tenant);


            var addedtenant = await _repo.AddAsync(tenant);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0) return addedtenant.Id;

            return null;
        }

        public async Task<List<EditToTenantDto>> SearchTenantbyname(string name)
        {
            var newtenant = await _repo.SearchTenantByname(name);
            return newtenant;
        }

        public async Task<List<EditToTenantDto>> SearchTenantsAsync(string query, Guid buildingId)
        {
            return await _repo.SearchTenantAsync(query, buildingId);
        }

        public async Task<EditToTenantDto> GetByIdAsync(Guid id)
        {
            var t = await _repo
                .GetAllQuerable(
                    x => x.Id == id,
                    x => x.IsUnitIllegal,

                    x => x.Building,
                    x => x.Building.State,
                    x => x.Building.PremiseType,

                    x => x.Building.RegulationStatus,
                    x => x.TenancyType,
                    x => x.Building.Landlord,
                    x => x.Building.Landlord.State,
                    x => x.Building.Landlord.LandlordType,
                    x => x.Building.Landlord.TypeOfOwner
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

                HasPossession = t.HasPossession,
                HasRegulatedTenancy = t.HasRegulatedTenancy,
                //Name_Relation = t.Name_Relation,
                OtherOccupants = t.OtherOccupants,

                TenantRecord = t.TenantRecord,
                HasPriorCase = t.HasPriorCase,
                TenancyTypeId = t.TenancyTypeId,
                TenancyTypeName = t.TenancyType?.Name,
                RenewalOffer = t.RenewalOffer,
                RentDueEachMonthOrWeekId = t.RentDueEachMonthOrWeekId,
                SocialServices = t.SocialServices,
                MonthlyRent = t.MonthlyRent,
                
                TenantShare = t.TenantShare,
                ERAPPaymentReceivedDate = t.ERAPPaymentReceivedDate,
                UnitOrApartmentNumber = t.UnitOrApartmentNumber,

                IsUnitIllegalId = t.IsUnitIllegalId,
                IsUnitIllegalName = t.IsUnitIllegal?.Name,
                BuildingId = t.BuildinId,
                PrimaryResidence = t.PrimaryResidence,
                


                //Building = new EditToBuildingDto
                //{
                //    Id = t.Building.Id,
                //    BuildingCode = t.Building.BuildingCode,
                //    ApartmentCode = t.Building.ApartmentCode,
                //    PremiseTypeId = t.Building.PremiseTypeId,
                //    PremiseTypeName = t.Building.PremiseType.Name,
                //    RegulationStatusId = t.Building.RegulationStatusId,
                //    PetitionerInterest = t.Building.PetitionerInterest,
                //    LandlordId = t.Building.LandlordId,
                //    Address1 = t.Building.Address1,
                //    Address2 = t.Building.Address2,
                //    StateId = t.Building.StateId,
                //    StateName = t.Building.State?.Name,
                //    City = t.Building.City,
                //    Zipcode = t.Building.Zipcode,
                //    MDRNumber = t.Building.MDRNumber,
                //    BuildingUnits = t.Building.BuildingUnits,
                //    RegulationStatusName = t.Building.RegulationStatus?.Name,
                //},

                //Landlord = new EditToLandlordDto
                //{
                //    Id = t.Building.Landlord.Id,
                //    LandLordCode = t.Building.Landlord.LandLordCode,
                //    FirstName = t.Building.Landlord.FirstName,
                //    LastName = t.Building.Landlord.LastName,
                //    TypeOwnerId = t.Building.Landlord.TypeOfOwnerId,
                //    TypeOwnerName = t.Building.Landlord.TypeOfOwner.Name,
                //    Email = t.Building.Landlord.Email,
                //    ContactPersonName = t.Building.Landlord.ContactPersonName,
                //    EINorSSN = t.Building.Landlord.EINorSSN,
                //    Address1 = t.Building.Landlord.Address1,
                //    Address2 = t.Building.Landlord.Address2,
                //    StateId = t.Building.Landlord.StateId,
                //    StateName = t.Building.Landlord.State?.Name,
                //    City = t.Building.Landlord.City,
                //    Zipcode = t.Building.Landlord.Zipcode,
                //    Phone = t.Building.Landlord.Phone,
                //    ClientId = t.Building.Landlord.ClientId,
                //    LandlordTypeId = t.Building.Landlord.LandlordTypeId,
                //    LandlordTypeName = t.Building.Landlord.LandlordType?.Name,
                //    DateOfRefreeDeed = t.Building.Landlord.DateOfRefreeDeed,
                //},
            };
        }

        public async Task<List<EditToTenantDto>> GetTenantsByClientIdAsync(Guid? clientId)
        {
            var tenants = await _repo.GetTenantsByClientIdAsync(clientId);
            return tenants;


        }

        public async Task<Guid?> AddOnlyTenantfromCase(CreateToTenantDto dto)
        {
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


            var code = $"TT{nextNumber.ToString().PadLeft(10, '0')}";
            nextNumber++;

            var tenant = new Tenant
            {
                Id = Guid.NewGuid(),
                TenantCode = code,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BuildinId = dto.BuildingId,

            };




            var result = await _repo.AddAsync(tenant);
            if (result == null) return null;

            await _unitOfWork.SaveChangesAsync();
            return tenant.Id;
        }

        public async Task<bool> UpdateTenantfromCase(EditToTenantDto tenants)

        {

            var entity = await _repo.GetAsync(tenants.Id);
            if (entity != null)
            {

                if (entity.FirstName != tenants.FirstName) entity.FirstName = tenants.FirstName;
                if (entity.UnitOrApartmentNumber != tenants.UnitOrApartmentNumber) entity.UnitOrApartmentNumber = tenants.UnitOrApartmentNumber;
                if (entity.LastName != tenants.LastName) entity.LastName = tenants.LastName;
                if (entity.BuildinId != tenants.BuildingId) entity.BuildinId = tenants.BuildingId;
                if (entity.PrimaryResidence != tenants.PrimaryResidence) entity.PrimaryResidence = tenants.PrimaryResidence;
                if (entity.TenancyTypeId != tenants.TenancyTypeId) entity.TenancyTypeId = tenants.TenancyTypeId;
                if (entity.MonthlyRent != tenants.MonthlyRent) entity.MonthlyRent = tenants.MonthlyRent;
                if (entity.RentDueEachMonthOrWeekId != tenants.RentDueEachMonthOrWeekId) entity.RentDueEachMonthOrWeekId = tenants.RentDueEachMonthOrWeekId;

            }

            _repo.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;


        }

        public async Task<List<EditToTenantDto>> GetAlltenant()
        {
            var tenants = await _repo.GetAllAsync();

            var result = tenants.Select(x => new EditToTenantDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                TenantCode = x.TenantCode,
                LastName = x.LastName,
            })
             .ToList();

            return result;


        }
        public async Task<bool> UpdateTenantAsync(EditToTenantDto t)
        {
            try
            {
                var entity = await _repo.GetAsync(t.Id);
                if (entity != null)
                {
                    entity.FirstName = t.FirstName;
                    entity.LastName = t.LastName;

                    entity.HasRegulatedTenancy = t.HasRegulatedTenancy;
                    //entity.Additionaltenants = t.Additionaltenants;

                    entity.TenancyTypeId = t.TenancyTypeId;
                    entity.PrimaryResidence = t.PrimaryResidence;
                    //entity.RentDueEachMonthOrWeek = t.RentDueEachMonthOrWeek;
                    entity.MonthlyRent = t.MonthlyRent;

                    entity.TenantShare = t.TenantShare;
                    entity.UnitOrApartmentNumber = t.UnitOrApartmentNumber;
                    entity.RentDueEachMonthOrWeekId = t.RentDueEachMonthOrWeekId;
                    entity.BuildinId = t.BuildingId;
                }

                var result =await _repo.UpdateAsync(entity);
                if (result != null) return true;

                return false;

            }
            catch (Exception ex)
            {
                return false;

            }


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


                HasPossession = t.HasPossession,
                HasRegulatedTenancy = t.HasRegulatedTenancy,
                //add = t.Additionaltenants,
                OtherOccupants = t.OtherOccupants,

                TenantRecord = t.TenantRecord,
                HasPriorCase = t.HasPriorCase,
                TenancyTypeId = t.TenancyTypeId,
                RenewalOffer = t.RenewalOffer,
                //RentDueEachMonthOrWeek = t.RentDueEachMonthOrWeek,
                SocialServices = t.SocialServices,
                MonthlyRent = t.MonthlyRent,

                TenantShare = t.TenantShare,
                ERAPPaymentReceivedDate = t.ERAPPaymentReceivedDate,
                UnitOrApartmentNumber = t.UnitOrApartmentNumber,

                IsUnitIllegalId = t.IsUnitIllegalId,
                BuildingId = t.BuildinId,
            }).ToList();
        }

        public async Task<string> GetLastTenantCode()
        {
            var lastTenantCode = await _repo.GetLasttenantCodeAsync();
            return lastTenantCode!;
        }

        public async Task<(EditToLandlordDto landlord, EditToBuildingDto building)>
    GetLandlordBuildingByTenantAsync(Guid tenantId)
        {

            var lastTenant = await _repo.GetLandlordBuildingByTenantAsync(tenantId);
            return lastTenant;

        }
        public async Task<EditToLandlordDto>
    GetLandlordByBuildingAsync(Guid buildingId)
        {

            var Landlord = await _repo.GetLandlordByBuildingAsync(buildingId);
            return Landlord;

        }

        public async Task<List<EditToTenantDto>> GetTenantsByLandlordIdAsync(Guid landlordId)
        {
            var lastTenant = await _repo.GetTenantsByLandlordIdAsync(landlordId);
            return lastTenant;
        }

        public async Task<List<EditToTenantDto>> GetTenantsByBuildingIdAsync(Guid buildingId)
        {
            var tenants = await _repo.GetTenantsByBuildingIdAsync(buildingId);
            return tenants;
        }
    }
}
