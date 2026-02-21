using EvictionFiler.Application.DTOs.CaseDetailDtos;
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
        Task<BuildingDetailDto> GetBuildingDetailAsync(Guid caseId);
        Task<TenantDetailDto> GetTenantDetailAsync(Guid caseId);
    }
}
