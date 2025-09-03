using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface ICasesRepository : IRepository<LegalCase>
	{

        //Task<PaginationDto<LegalCase>> GetAllCasesAsync(int pageNumber, int pageSize , string searchTerm);
        Task<PaginationDto<LegalCase>> GetAllCasesAsync(int pageNumber, int pageSize, CaseFilterDto filters);
        Task<List<LegalCase>> GetAllCasesAsync();
        Task<string> GenerateCaseCodeAsync();
        Task<List<LegalCase>> GetTodayCasesAsync();
        Task<int> GetTotalCasesCountAsync();


    }

}
