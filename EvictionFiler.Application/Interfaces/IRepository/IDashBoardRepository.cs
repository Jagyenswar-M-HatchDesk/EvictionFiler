using EvictionFiler.Application.DTOs.DashboardDto;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
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
        Task<List<string>> GetClientSuggestions(string term);
        Task<List<string>> GetTenantSuggestions(string term);
        Task<List<string>> GetLandlordSuggestions(string term);
        Task<List<string>> GetCaseSuggestions(string term);
        Task<List<string>> GetReasonHoldoverSuggestions(string term);
    }
}
