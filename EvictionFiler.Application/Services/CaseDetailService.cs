using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.CaseAppearanceDtos;
using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.DTOs.CaseHearing;
using EvictionFiler.Application.DTOs.CaseWarrantDtos;
using EvictionFiler.Application.DTOs.FormTypeDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.MarshalsDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Application.Interfaces.IRepository.MasterRepository;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class CaseDetailService:ICaseDetailService
    {
        private readonly ILandlordReadRepository _landlordReadRepository;
        private readonly IBuildingReadRepository _buildingReadRepository;
        private readonly ITenantReadRepository _tenantReadRepository;
        private readonly ICitiesRepository _cityRepository;
        private readonly IClientReadRepository _clientReadRepository;
        private readonly IMarshalAndWarrantRepository _marshalAndWarrantRepository;
        private readonly IWarrantRepository _warrantRepository;
        private readonly ICaseAppearanceReadRepository _caseAppearanceReadRepository;
        private readonly ICaseHearingReadRepository _caseHearingReadRepository;
        private readonly ICourtReadRepository _courtReadRepository;
        private readonly ICaseFormReadRepository _caseFormReadRepository;

        public CaseDetailService(ILandlordReadRepository landlordReadRepository,IBuildingReadRepository buildingReadRepository,ITenantReadRepository tenantReadRepository,ICitiesRepository cityRepository,IClientReadRepository clientReadRepository,
                                    IMarshalAndWarrantRepository marshalAndWarrantRepository,IWarrantRepository warrantRepository,ICaseAppearanceReadRepository caseAppearanceReadRepository,ICaseHearingReadRepository caseHearingReadRepository,
                                        ICourtReadRepository courtReadRepository,ICaseFormReadRepository caseFormReadRepository)
        {
            _landlordReadRepository = landlordReadRepository;
            _buildingReadRepository = buildingReadRepository;
            _tenantReadRepository = tenantReadRepository;
            _cityRepository = cityRepository;
            _clientReadRepository = clientReadRepository;
            _marshalAndWarrantRepository = marshalAndWarrantRepository;
            _warrantRepository = warrantRepository;
            _caseAppearanceReadRepository = caseAppearanceReadRepository;
            _caseHearingReadRepository = caseHearingReadRepository;
            _courtReadRepository = courtReadRepository;
            _caseFormReadRepository = caseFormReadRepository;
        }
        public async Task<LandlordDetailDto> GetLandlordDetailAsync(Guid caseId)
        {
            return await _landlordReadRepository.GetLandlordDetailAsync(caseId);
        }
        public async Task<BuildingDetailDto> GetBuildingDetailAsync(Guid caseId)
        {
            return await _buildingReadRepository.GetBuildingDetailAsync(caseId);
        }
        public async Task<TenantDetailDto> GetTenantDetailAsync(Guid caseId)
        {
            return await _tenantReadRepository.GetTenantDetailAsync(caseId);
        }
        public async Task<ClientDetailDto> GetClientDetailAsync(Guid casId)
        {
            return await _clientReadRepository.GetClientsDetailAsync(casId);
        }
        public async Task<MarshalAndWarrantDetailDto> GetMarshalDetailAsync(Guid caseId)
        {
            return await _marshalAndWarrantRepository.GetMarshalDetailAsync(caseId);
        }
        public async Task<EditToLandlordDto> GetLandlordByIdAsync(Guid landlordId)
        {
            return await _landlordReadRepository.GetLandlordByIdAsync(landlordId);
        }
        public async Task<List<EditToLandlordDto>> GetLandlordsByClientIdAsync(Guid? clientId)
        {
            var landlords = await _landlordReadRepository.GetByClientIdAsync(clientId);
            return landlords;


        }

        public async Task<List<EditToLandlordDto>> SearchLandlordsAsync(string query, Guid clientId)
        {
            return await _landlordReadRepository.SearchLandlordsAsync(query, clientId);
        }

        public async Task<IEnumerable<City>> GetAllCitiesList()
        {
            var list = await _cityRepository.GetAllAsync();
            return list
                .OrderBy(e => e.Name).ToList();

        }
        public async Task<Guid?> AddOnlyLandLordfromCase(CreateToLandLordDto dto)
        {
            var lastCode = await _landlordReadRepository.GetLastLandLordCodeAsync();

            int nextNumber = 1;
            if (!string.IsNullOrEmpty(lastCode) && lastCode.Length > 2)
            {
                var numericPart = lastCode.Substring(2);
                if (int.TryParse(numericPart, out int lastNumber))
                {
                    nextNumber = lastNumber + 1;
                }
            }


            var code = $"LL{nextNumber.ToString().PadLeft(10, '0')}";
            nextNumber++;

            var landlord = new LandLord
            {
                Id = Guid.NewGuid(),
                LandLordCode = code,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                EINorSSN = dto.EINorSSN,
                Phone = dto.Phone,
                Email = dto.Email,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                StateId = dto.StateId,
                CityId = dto.CityId,
                Zipcode = dto.Zipcode,
                ContactPersonName = dto.ContactPersonName,
                DateOfRefreeDeed = dto.DateOfRefreeDeed,
                LandlordTypeId = dto.LandlordTypeId,
                TypeOfOwnerId = dto.TypeOwnerId,
                ClientId = dto.ClientId,
                CreatedOn = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                UpdatedBy = null,
                UpdatedOn = DateTime.Now,
                LawFirm = dto.LawFirm,
                AttorneyOfRecord = dto.AttorneyOfRecord
            };




            var result = await _landlordReadRepository.AddAsync(landlord);
            if (result == null) return null;

            await _landlordReadRepository.SaveChangesAsync();
            return landlord.Id;
        }
        public async Task<bool> UpdateLandLordsfromCase(EditToLandlordDto landlords)

        {

            var entity = await _landlordReadRepository.GetAsync(landlords.Id);
            if (entity != null)
            {
                // Manually map updated values
                if (entity.ContactPersonName != landlords.ContactPersonName) entity.ContactPersonName = landlords.ContactPersonName;
                if (entity.LawFirm != landlords.LawFirm) entity.LawFirm = landlords.LawFirm;
                if (entity.AttorneyOfRecord != landlords.AttorneyOfRecord) entity.AttorneyOfRecord = landlords.AttorneyOfRecord;
                if (entity.Address1 != landlords.Address1) entity.Address1 = landlords.Address1;
                if (!string.IsNullOrWhiteSpace(landlords.FirstName))
                    entity.FirstName = landlords.FirstName;

                if (!string.IsNullOrWhiteSpace(landlords.LastName))
                    entity.LastName = landlords.LastName;

            }

            _landlordReadRepository.UpdateAsync(entity);
            await _landlordReadRepository.SaveChangesAsync();
            return true;


        }
        public async Task<Guid?> UpdateCaseForLandlordAsync(IntakeModel legalCase)
        {
            try
            {


                var result = await _landlordReadRepository.UpdateCaseLandlord(legalCase);
                return result;

            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<Guid?> AddOnlyApartmentfromCase(CreateToBuildingDto appartment)
        {

            var lastCode = await _buildingReadRepository.GetLastBuildingCodeAsync();

            int nextNumber = 1;
            if (!string.IsNullOrEmpty(lastCode) && lastCode.Length > 2)
            {
                var numericPart = lastCode.Substring(2);
                if (int.TryParse(numericPart, out int lastNumber))
                {
                    nextNumber = lastNumber + 1;
                }
            }


            var code = $"BB{nextNumber.ToString().PadLeft(10, '0')}";
            nextNumber++;

            var newapartment = new Building
            {
                Id = Guid.NewGuid(),
                BuildingCode = code,
                ApartmentCode = appartment.ApartmentCode,
                CityId = appartment.CityId,
                StateId = appartment.StateId,
                RegulationStatusId = appartment.RegulationStatusId,
                PremiseTypeId = appartment.PremiseTypeId,
                Address1 = appartment.Address1,
                Address2 = appartment.Address2,
                Zipcode = appartment.Zipcode,
                MDRNumber = appartment.MDRNumber,
                PetitionerInterest = appartment.PetitionerInterest,
                BuildingUnits = appartment.BuildingUnits,
                BuildingTypeId = appartment.BuildingTypeId,
                RegistrationStatusId = appartment.RegistrationStatusId,
                ExemptionBasisId = appartment.ExemptionBasisId,
                ExemptionReasonId = appartment.ExemptionreasonId,
                PrimaryResidence = appartment.PrimaryResidence,
                GoodCause = appartment.GoodCause,
                OwnerOccupied = appartment.OwnerOccupied,
                TenancyTypeForBuildingId = appartment.TenancyTypeForBuildingId,
                ManagingAgent = appartment.ManagingAgent,
                RentRentRegulationOther = appartment.RentRegulationOther,
                ExemptionBasisOther = appartment.ExemptionBasisother,

                LandlordId = appartment.LandlordId,
            };



            var result=await _buildingReadRepository.AddAsync(newapartment);
           

            if (result!= null) return result.Id;

            return null;
        }


        public async Task<List<EditToBuildingDto>> SearchBuilding(string query, Guid landlordId)
        {
            return await _buildingReadRepository.SearchBuilding(query, landlordId);
        }
        public async Task<bool> UpdateonlyBuildingfromCase(EditToBuildingDto appartment)

        {

            var entity = await _buildingReadRepository.GetAsync(appartment.Id);
            if (entity != null)
            {



                if (entity.ApartmentCode != appartment.ApartmentCode) entity.ApartmentCode = appartment.ApartmentCode;
                if (entity.CityId != appartment.CityId) entity.CityId = appartment.CityId;
                if (entity.Address1 != appartment.Address1) entity.Address1 = appartment.Address1;
                if (entity.Address2 != appartment.Address2) entity.Address2 = appartment.Address2;
                if (entity.StateId != appartment.StateId) entity.StateId = appartment.StateId;
                if (entity.MDRNumber != appartment.MDRNumber) entity.MDRNumber = appartment.MDRNumber;
                if (entity.RegulationStatusId != appartment.RegulationStatusId) entity.RegulationStatusId = appartment.RegulationStatusId;
                if (entity.BuildingUnits != appartment.BuildingUnits) entity.BuildingUnits = appartment.BuildingUnits;
                if (entity.BuildingTypeId != appartment.BuildingTypeId) entity.BuildingTypeId = appartment.BuildingTypeId;
                if (entity.PremiseTypeId != appartment.PremiseTypeId) entity.PremiseTypeId = appartment.PremiseTypeId;
                if (entity.RegistrationStatusId != appartment.RegistrationStatusId) entity.RegistrationStatusId = appartment.RegistrationStatusId;
                if (entity.PrimaryResidence != appartment.PrimaryResidence) entity.PrimaryResidence = appartment.PrimaryResidence;
                if (entity.GoodCause != appartment.GoodCause) entity.GoodCause = appartment.GoodCause;
                if (entity.OwnerOccupied != appartment.OwnerOccupied) entity.OwnerOccupied = appartment.OwnerOccupied;
                if (entity.ExemptionReasonId != appartment.ExemptionreasonId) entity.ExemptionReasonId = appartment.ExemptionreasonId;
                if (entity.ExemptionBasisId != appartment.ExemptionBasisId) entity.ExemptionBasisId = appartment.ExemptionBasisId;
                if (entity.TenancyTypeForBuildingId != appartment.TenancyTypeForBuildingId) entity.TenancyTypeForBuildingId = appartment.TenancyTypeForBuildingId;
                if (entity.RentRentRegulationOther != appartment.RentRegulationOther) entity.RentRentRegulationOther = appartment.RentRegulationOther;
                if (entity.ExemptionBasisOther != appartment.ExemptionBasisother) entity.ExemptionBasisOther = appartment.ExemptionBasisother;

                _buildingReadRepository.UpdateAsync(entity);
                await _buildingReadRepository.SaveChangesAsync();
            }
            return true;
        }
        public async Task<List<EditToBuildingDto>> GetBuildingsByLandlordIdAsync(Guid landlordId)
        {
            var buildings = await _buildingReadRepository.GetBuildingsByLandlordIdAsync(landlordId);
            return buildings;


        }

        public async Task<Guid?> UpdateCaseForBuildingAsync(IntakeModel legalCase)
        {
            try
            {


                var result = await _buildingReadRepository.UpdateCaseBuilding(legalCase);
                return result;

            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<Guid?> UpdateCaseForTenantAsync(IntakeModel legalCase)
        {
            try
            {


                var result = await _tenantReadRepository.UpdateCaseTenant(legalCase);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<CaseWarrantDto> GetWarrantDetails(Guid caseId)
        {
            var existing = await _warrantRepository.FindAsync(predicate: e => e.LegalCaseId == caseId);
            if (existing == null) return new CaseWarrantDto();
            var result = new CaseWarrantDto
            {
                ReFileDate = existing.ReFileDate,
                WarrantRequested = existing.WarrantRequested,
                WarrantIssued = existing.WarrantIssued,
                WarrantRejected = existing.WarrantRejected,
                EvictionExecuted = existing.EvictionExecuted,
                ExecutionEligible = existing.ExecutionEligible,
                NoticeServed = existing.NoticeServed,
                MarshalId = existing.MarshalId,
                LegalcaseId = existing.LegalCaseId,

            };

            return result;
        }


        public async Task<Guid?> UpdateCaseForClientAsync(IntakeModel legalCase)
        {
            try
            {

                var result = await _clientReadRepository.UpdateClient(legalCase);
                return result;

            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<CaseWarrantDto> GetWarrantsDetails(Guid caseId)
        {
            var existing = await _warrantRepository.FindAsync(predicate: e => e.LegalCaseId == caseId);
            if (existing == null) return new CaseWarrantDto();
            var result = new CaseWarrantDto
            {
                ReFileDate = existing.ReFileDate,
                WarrantRequested = existing.WarrantRequested,
                WarrantIssued = existing.WarrantIssued,
                WarrantRejected = existing.WarrantRejected,
                EvictionExecuted = existing.EvictionExecuted,
                ExecutionEligible = existing.ExecutionEligible,
                NoticeServed = existing.NoticeServed,
                MarshalId = existing.MarshalId,
                LegalcaseId = existing.LegalCaseId,

            };

            return result;
        }

        public async Task<MarshalDto> GetMarshalByIdAsync(Guid id)
        {
            var entity = await _marshalAndWarrantRepository.GetMarshalByIdAsync(id);
            if (entity == null)
                return null;

            return new MarshalDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                BadgeNumber = entity.BadgeNumber,
                Telephone = entity.Telephone,
                Fax = entity.Fax,
                OfficeAddress = entity.OfficeAddress,
                DocketNo = entity.DocketNo,
            };

        }

        //Motion
        public async Task<List<CaseAppearanceDto>> GetAllCaseAppreance(Guid caseId)
        {
            var appreaaces = await _caseAppearanceReadRepository.GetAllAsync(predicate: x => x.LegalCaseId == caseId, includes: a => a.CourtToday!);
            var result = appreaaces.Select(e => new CaseAppearanceDto
            {
                Id = e.Id,
                AdjournDate = e.AdjournDate,
                AdjournReasonId = e.AdjournReasonId,
                AdjournTime = e.AdjournTime,
                MotionDue = e.MotionDue,
                ReminderPayments = e.ReminderPayments,
                ReminderDeadlines = e.ReminderDeadlines,
                ReplyDue = e.ReplyDue,
                ReturnDate = e.ReturnDate,
                CourtTodayId = e.CourtTodayId,
                OppositionDue = e.OppositionDue,
                JurisdictionWaived = e.JurisdictionWaived,
                StayUntil = e.StayUntil,
                WarrantDate = e.WarrantDate,
                WarrantIssued = e.WarrantIssued,
                MilitaryAffidavit = e.MilitaryAffidavit,
                LegalCaseId = e.LegalCaseId,
                CourtTodayName = e.CourtToday != null ? e.CourtToday.Name : string.Empty,


            }).ToList();
            return result;
        }


        public async Task<List<CaseHearingDto>> GetAllCaseHeariingByCaseIdAsync(Guid id)
        {
            var calanders = await _caseHearingReadRepository
                  .GetAllQuerable(x => x.IsDeleted != true && x.LegalCaseId == id, x => x.LegalCase, x => x.Courts)
                  ;

            var result = calanders.Select(dto => new CaseHearingDto
            {
                Id = dto.Id,

                HearingDate = dto.HearingDate ?? DateTime.Today,

                HearingTime = (dto.HearingTime == default || dto.HearingTime == TimeOnly.MinValue)
    ? TimeOnly.FromTimeSpan(TimeSpan.FromHours(9.5))
    : dto.HearingTime.Value,


                CourtId = dto.CourtId,
                LegalCaseId = dto.LegalCaseId,
                IndexNo = dto.IndexNo,
                Caption = dto.Caption,

                // CaseType name — safe whether CaseTypeId or LegalCaseId is null
                CaseTypeName =
        dto.CaseTypeId != null
            ? dto.CaseTypes.Name
            : dto.LegalCase.CaseType.Name ?? string.Empty,

                //        // Judge — prefer Hearing Judge, fallback to Court Judge
                //        Judge = dto.Judge
                //?? dto.Courts?.Judge
                //?? string.Empty,

                //        // Court part — from CourtPart or fallback to Court.Part
                //        CourtPart =
                //dto.CourtPartId != null
                //    ? dto.CourtParts?.Part
                //    : dto.Courts?.Part ?? string.Empty,

                // Case status name — only if present
                CaseStatusName =
        dto.CaseStatusId != null
            ? dto.CaseStatus.Name
            : string.Empty,

                //        // Room number — prefer explicit RoomNo, fallback to Court’s RoomNo
                //        RoomNo = dto.RoomNo
                //?? dto.Courts?.RoomNo
                //?? string.Empty,

                // County name — safe for null CountyId
                CountyName =
        dto.CountyId != null
            ? dto.Counties.Name
            : string.Empty,

                CreatedOn = dto.CreatedOn,
                LastAction = dto.LastAction,

            }).OrderBy(e => e.HearingDate).ToList();



            return result;
        }


        //Court

        public async Task<CourtDetailDto> GetCourtDetailsAsync(Guid caseId)
        {
            return await _courtReadRepository.GetCourtDetailsAsync(caseId);
        }


        //Case forms

        public async Task<List<GenrateNoticeModel>> GetCaseFormsByCaseId(Guid caseId, string userId, bool isAdmin)
        {
            var data = await _caseFormReadRepository
    .GetAllAsync(x => x.IsDeleted != true && x.LegalCaseId == caseId,
                 x => x.FormType!, x => x.User!);

            var query = data.AsQueryable();

            if (!isAdmin)
            {
                query = query.Where(c => c.IsActive == true && c.IsDeleted == false);

                if (!string.IsNullOrWhiteSpace(userId))
                {
                    var userGuid = Guid.Parse(userId);
                    query = query.Where(c => c.CreatedBy == userGuid);
                }
            }
            else
            {
                query = query.OrderByDescending(c => c.CreatedOn);
            }

            var result = query
                .OrderBy(e => e.CreatedOn)
                .Select(dto => new GenrateNoticeModel
                {
                    Id = dto.Id,
                    FormTypeName = dto.FormType.Name ?? "",
                    FormTypeId = dto.FormTypeId,
                    File = dto.File,
                    HTML = dto.HTML,
                    CreatedOn = dto.CreatedOn,
                    CreatedByName = dto.User != null ? dto.User.FirstName : string.Empty,
                })
                .ToList();

            return result;
        }
    }
}
