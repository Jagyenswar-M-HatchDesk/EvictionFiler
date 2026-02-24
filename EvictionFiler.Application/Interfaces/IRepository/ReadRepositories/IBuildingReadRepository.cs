using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.ReadRepositories
{
    public  interface IBuildingReadRepository : IReadRepository<Building>
    {

        Task<BuildingDetailDto> GetBuildingDetailAsync(Guid caseId);

        Task<EditToBuildingDto> GetBuildingByIdAsync(Guid buildingId);

        
        Task<List<Registrationstatus>> GetAllRegistrationstatus();
        Task<string?> GetLastBuildingCodeAsync();

       Task<Guid?> UpdateCaseBuilding(IntakeModel casedetails);
        Task<List<EditToBuildingDto>> GetBuildingsByLandlordIdAsync(Guid landlordId);

        Task<List<EditToBuildingDto>> SearchBuilding(string searchText, Guid landlordId);

        Task<List<PremiseType>> GetAllPremiseType();
        Task<List<RegulationStatus>> GetAllRegulationStatus();

        Task<List<State>> GetAllState();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
