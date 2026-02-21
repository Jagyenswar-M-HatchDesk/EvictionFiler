using EvictionFiler.Application.DTOs.CaseDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.ReadRepositories
{
    public interface ITenantReadRepository
    {
        Task<TenantDetailDto> GetTenantDetailAsync(Guid caseId);
    }
}
