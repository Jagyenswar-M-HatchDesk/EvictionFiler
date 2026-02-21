using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Application.Interfaces.IServices;
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

        public CaseDetailService(ILandlordReadRepository landlordReadRepository,IBuildingReadRepository buildingReadRepository,ITenantReadRepository tenantReadRepository)
        {
            _landlordReadRepository = landlordReadRepository;
            _buildingReadRepository = buildingReadRepository;
            _tenantReadRepository = tenantReadRepository;
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

    }
}
