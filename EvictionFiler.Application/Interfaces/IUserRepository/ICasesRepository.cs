using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface ICasesRepository
    {
        Task<List<LegalCase>> GetAllCasesAsync();
        Task<LegalCase?> GetCaseByIdAsync(Guid id);
        Task AddCaseAsync(LegalCase legalCase);
        Task UpdateCaseAsync(LegalCase legalCase);
        Task DeleteCaseAsync(Guid id);

    }

}
