using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.CaseDetailDtos;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.ReadRepositories
{
    public interface ITenantReadRepository: IReadRepository<Tenant>
    {
        Task<TenantDetailDto> GetTenantDetailAsync(Guid caseId);
        Task<List<EditToTenantDto>> GetTenantsByClientIdAsync(Guid? clientId);
        Task<List<CaseType>> GetAllCaseType();
        Task<List<TenancyType>> GetAllTenancyType();

        Task<List<DateRent>> GetAllDateRent();
        Task<Guid?> UpdateCaseTenant(IntakeModel casedetails);
    }
}
