using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.DTOs.TenantDto;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface IDashBoardRepository
    {
        
        Task<PaginationDto<LegalCase>> Search(int pageNumber, int pageSize, CaseFilterDto filters);
        Task<List<EditToClientDto>> GetClientSuggestions(string term);
        Task<List<EditToTenantDto>> GetTenantSuggestions(string term);
        Task<List<EditToLandlordDto>> GetLandlordSuggestions(string term);
        Task<List<CreateToEditLegalCaseModel>> GetCaseSuggestions(string term);
        Task<List<string>> GetReasonHoldoverSuggestions(string term);
        Task<List<EditToClientDto>> GetTopClients();
        Task<List<EditToTenantDto>> GetTopTenants();
        Task<List<EditToLandlordDto>> GetTopLandlords();
        Task<List<CreateToEditLegalCaseModel>> GetTopCases();
    }
}
