using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Base;
using EvictionFiler.Domain.Entities.Master;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories.ReadRepositories
{
    public class BuildingReadRepository : ReadRepository<Building>, IBuildingReadRepository
    {
        private readonly IDbContextFactory<MainDbContext> _contextFactory;

        public BuildingReadRepository(IDbContextFactory<MainDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;

        }
        public async Task<BuildingDetailDto> GetBuildingDetailAsync(Guid caseId)
        {
            await using var context = _contextFactory.CreateDbContext();
            var l = await context.LegalCases
     .AsNoTracking()
     .Where(c => c.Id == caseId && c.IsDeleted != true)
     .Include(c => c.Buildings)
     .ThenInclude(b => b.Cities)
     .Include(c => c.Buildings)
     .ThenInclude(b => b.State)
     .Include(c => c.Buildings!.PremiseType)
     .Include(c => c.Buildings!.RegulationStatus)

     .FirstOrDefaultAsync();


            if (l == null) return null;

            return new BuildingDetailDto
            {
                BuildingId = l.Buildings?.Id,
                
                Mdr = l.Buildings?.MDRNumber,

                BuildingTyeName = l.Buildings?.PremiseType?.Name,
                BuildingAddress = l.Buildings?.Address1,
                RentRegulationType = l.Buildings?.RegulationStatus?.Name,
                Borough = l.Buildings?.Cities != null ? l.Buildings?.Cities?.Name : null,
                BuildingState = l.Buildings?.State != null ? l.Buildings?.State?.Name : string.Empty,
                BuildingZip = l.Buildings?.Zipcode,


            };
        }

        public async Task<EditToBuildingDto> GetBuildingByIdAsync(Guid buildingId)
        {
            await using var context = _contextFactory.CreateDbContext();
            var appartment = await context.Buildings
                .Include(a => a.State)
                .Include(a => a.PremiseType)
                .Include(a => a.RegulationStatus)
                .Include(a => a.TenancyTypeForBuilding)
                .Include(a => a.ExemptionReason)
                .Include(a => a.ExemptionBasis)
                 .Include(a => a.RegistrationStatus)
                .FirstOrDefaultAsync(x => x.Id == buildingId && x.IsDeleted != true);

            if (appartment == null) return null;

            return new EditToBuildingDto
            {
                Id = appartment.Id,
                BuildingCode = appartment.BuildingCode,
                ApartmentCode = appartment.ApartmentCode,
                CityId = appartment.CityId,
                StateId = appartment.StateId,
                StateName = appartment.State?.Name,
                PremiseTypeId = appartment.PremiseTypeId,
                ExemptionBasisId = appartment.ExemptionBasisId,
                ExemptionreasonId = appartment.ExemptionReasonId,
                TenancyTypeForBuildingId = appartment.TenancyTypeForBuildingId,
                GoodCause = appartment.GoodCause,
                PrimaryResidence = appartment.PrimaryResidence,
                OwnerOccupied = appartment.OwnerOccupied,
                PremiseTypeName = appartment.PremiseType?.Name,
                RegulationStatusId = appartment.RegulationStatusId,
                RegistrationStatusId = appartment.RegistrationStatusId,
                RegulationStatusName = appartment.RegulationStatus?.Name,
                RegistrationStatusName = appartment.RegistrationStatus?.Name,
                ExemptionBasisName = appartment.ExemptionBasis?.Name,
                ExemptionReasonName = appartment.ExemptionReason?.Name,
                TenancyTypeForBuildingName = appartment.TenancyTypeForBuilding?.Name,
                Address1 = appartment.Address1,
                Address2 = appartment.Address2,
                Zipcode = appartment.Zipcode,
                MDRNumber = appartment.MDRNumber,
                PetitionerInterest = appartment.PetitionerInterest,
                BuildingUnits = appartment.BuildingUnits,
                LandlordId = appartment.LandlordId,
                IsActive = appartment.IsActive,
                IsDeleted = appartment.IsDeleted,
                RentRegulationOther = appartment.RentRentRegulationOther,
                ExemptionBasisother = appartment.ExemptionBasisOther,
            };
        }


        public async Task<List<Registrationstatus>> GetAllRegistrationstatus()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.MstRegistrationstatuses.ToListAsync();
        }

        public async Task<string?> GetLastBuildingCodeAsync()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Buildings
                .OrderByDescending(l => l.BuildingCode)
                .Select(l => l.BuildingCode)
                .FirstOrDefaultAsync();
        }

        public async Task<Guid?> UpdateCaseBuilding(IntakeModel casedetails)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            var existingCase = db.LegalCases.Find(casedetails.Id);
            if (existingCase == null) return null;

            existingCase.BuildingId = casedetails.BuildingId;


            db.LegalCases.Update(existingCase);

            var result = await db.SaveChangesAsync();
            if (result > 0) return casedetails.Id;

            return null;
        }
        public async Task<List<EditToBuildingDto>> SearchBuilding(string searchText, Guid landlordId)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            searchText = searchText?.Trim() ?? "";

            return await db.Buildings
                .Where(b =>
                    b.LandlordId == landlordId &&
                    b.IsDeleted != true &&
                    (
                        // Search by BuildingCode (StartsWith = indexed & fast)
                        b.BuildingCode.StartsWith(searchText) ||
                        b.Address1.Contains(searchText) ||
                        b.Address2.Contains(searchText) ||
                        b.Cities.Name.Contains(searchText)
                    )
                )
                .Select(b => new EditToBuildingDto
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
                    LandlordId = b.LandlordId,
                    BuildingTypeId = b.BuildingTypeId,
                    RegistrationStatusId = b.RegistrationStatusId,
                    ExemptionBasisId = b.ExemptionBasisId,
                    ExemptionreasonId = b.ExemptionReasonId,
                    PrimaryResidence = b.PrimaryResidence,
                    GoodCause = b.GoodCause,
                    OwnerOccupied = b.OwnerOccupied,
                    TenancyTypeForBuildingId = b.TenancyTypeForBuildingId,

                })
                .ToListAsync();
        }

        public async Task<List<EditToBuildingDto>> GetBuildingsByLandlordIdAsync(Guid landlordId)
        {
            await using var db = await _contextFactory.CreateDbContextAsync();
            var building = await db.Buildings
        .Include(a => a.State)
        .Include(a => a.PremiseType)
        .Include(a => a.RegulationStatus)
        .Include(a => a.RegistrationStatus)
        .Include(a => a.ExemptionReason)
        .Include(a => a.ExemptionBasis)
        .Include(a => a.TenancyTypeForBuilding)
        .Where(x => x.LandlordId == landlordId && x.IsDeleted != true)
        .ToListAsync();

            return building.Select(appartment => new EditToBuildingDto
            {
                Id = appartment.Id,
                BuildingCode = appartment.BuildingCode,
                ApartmentCode = appartment.ApartmentCode,
                CityId = appartment.CityId,
                StateId = appartment.StateId,
                StateName = appartment.State?.Name,
                PremiseTypeId = appartment.PremiseTypeId,
                PremiseTypeName = appartment.PremiseType?.Name,
                RegulationStatusId = appartment.RegulationStatusId,
                RegulationStatusName = appartment.RegulationStatus?.Name,
                RegistrationStatusName = appartment.RegistrationStatus?.Name,
                RegistrationStatusId = appartment.RegistrationStatusId,
                ExemptionBasisName = appartment.ExemptionBasis?.Name,
                ExemptionBasisId = appartment.ExemptionBasisId,
                ExemptionreasonId = appartment.ExemptionReasonId,
                TenancyTypeForBuildingId = appartment.TenancyTypeForBuildingId,
                ExemptionReasonName = appartment.ExemptionReason?.Name,
                TenancyTypeForBuildingName = appartment.TenancyTypeForBuilding?.Name,
                PrimaryResidence = appartment.PrimaryResidence,
                GoodCause = appartment.GoodCause,
                OwnerOccupied = appartment.OwnerOccupied,
                RentRegulationDescription = appartment.RentRegulationDescription,
                Address1 = appartment.Address1,
                ManagingAgent = appartment.ManagingAgent,
                Address2 = appartment.Address2,
                Zipcode = appartment.Zipcode,
                MDRNumber = appartment.MDRNumber,
                PetitionerInterest = appartment.PetitionerInterest,
                BuildingUnits = appartment.BuildingUnits,
                LandlordId = appartment.LandlordId,
                IsActive = appartment.IsActive,
                IsDeleted = appartment.IsDeleted,
                RentRegulationOther = appartment.RentRentRegulationOther,
                ExemptionBasisother = appartment.ExemptionBasisOther,


            }).ToList();
        }

        public async Task<List<PremiseType>> GetAllPremiseType()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.MstPremiseTypes.ToListAsync();
        }
        public async Task<List<RegulationStatus>> GetAllRegulationStatus()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.MstRegulationStatus.ToListAsync();
        }


        public async Task<List<State>> GetAllState()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.MstStates.Where(e => !string.IsNullOrEmpty(e.Name)).ToListAsync();
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.SaveChangesAsync(cancellationToken);
        }

    }

}
