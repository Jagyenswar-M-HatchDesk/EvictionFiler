using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.DashboardDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface IDashBoardRepository
    {

        Task<PaginationDto<LegalCase>> Search(int pageNumber, int pageSize, CaseFilterDto filters);
        Task<List<EditToClientDto>> GetClientSuggestions(string term);
        //Task<List<EditToTenantDto>> GetTenantSuggestions(string term);
        //Task<List<EditToLandlordDto>> GetLandlordSuggestions(string term);
        //Task<List<CreateToEditLegalCaseModel>> GetCaseSuggestions(string term);
        Task<List<string>> GetReasonHoldoverSuggestions(string term);
        Task<List<EditToClientDto>> GetTopClients();
        //Task<List<EditToTenantDto>> GetTopTenants();
        //Task<List<EditToLandlordDto>> GetTopLandlords(Guid? ClientId = null);
        //Task<List<CreateToEditLegalCaseModel>> GetTopCases();

        Task<List<EditToLandlordDto>> GetLandlordSuggestions(string term, Guid? clientId);
        Task<List<EditToLandlordDto>> GetTopLandlords(Guid? clientId);

        Task<List<EditToTenantDto>> GetTenantSuggestions(string term, Guid? clientId, Guid? landlordId);
        Task<List<EditToTenantDto>> GetTopTenants(Guid? clientId, Guid? landlordId);

        Task<List<CreateToEditLegalCaseModel>> GetCaseSuggestions(string term, Guid? clientId, Guid? landlordId, Guid? tenantId);
        Task<List<CreateToEditLegalCaseModel>> GetTopCases(Guid? clientId, Guid? landlordId, Guid? tenantId);
    }
}
