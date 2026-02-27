using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.DTOs.CaseWarrantDtos;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.MarshalsDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
      public  interface ICaseDetailService
    {
        Task<LandlordDetailDto> GetLandlordDetailAsync(Guid caseId);
        Task<List<EditToLandlordDto>> GetLandlordsByClientIdAsync(Guid? clientId);
        Task<List<EditToLandlordDto>> SearchLandlordsAsync(string query, Guid clientId);
        Task<EditToLandlordDto> GetLandlordByIdAsync(Guid landlordId);
        Task<BuildingDetailDto> GetBuildingDetailAsync(Guid caseId);
        Task<TenantDetailDto> GetTenantDetailAsync(Guid caseId);
        Task<Guid?> AddOnlyLandLordfromCase(CreateToLandLordDto dto);
        Task<bool> UpdateLandLordsfromCase(EditToLandlordDto landlords);
     Task<Guid?> UpdateCaseForLandlordAsync(IntakeModel legalCase);
        Task<IEnumerable<City>> GetAllCitiesList();
        Task<Guid?> AddOnlyApartmentfromCase(CreateToBuildingDto appartment);
        Task<bool> UpdateonlyBuildingfromCase(EditToBuildingDto appartment);
        Task<Guid?> UpdateCaseForBuildingAsync(IntakeModel legalCase);
        Task<List<EditToBuildingDto>> GetBuildingsByLandlordIdAsync(Guid landlordId);

        Task<List<EditToBuildingDto>> SearchBuilding(string query, Guid landlordId);


        Task<Guid?> UpdateCaseForTenantAsync(IntakeModel legalCase);

        Task<ClientDetailDto> GetClientDetailAsync(Guid casId);
        Task<MarshalAndWarrantDetailDto> GetMarshalDetailAsync(Guid caseId);

        Task<CaseWarrantDto> GetWarrantDetails(Guid caseId);

        Task<Guid?> UpdateCaseForClientAsync(IntakeModel legalCase);
        Task<CaseWarrantDto> GetWarrantsDetails(Guid caseId);
        Task<MarshalDto> GetMarshalByIdAsync(Guid id);
    }
}
