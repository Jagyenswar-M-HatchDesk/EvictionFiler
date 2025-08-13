using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface ICasesRepository
    {
        Task<List<LegalCase>> GetAllCasesAsync();
        Task<CreateToEditLegalCaseModel?> GetCaseByIdAsync(Guid id);
		Task<bool> AddCaseAsync(CreateToEditLegalCaseModel legalCase);
        Task<bool> UpdateCasesAsync(CreateToEditLegalCaseModel legalCase);
		Task DeleteCaseAsync(Guid id);
      


	}

}
