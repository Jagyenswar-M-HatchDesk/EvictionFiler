using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using System.Linq.Expressions;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface ICaseAppearanceRepository : IRepository<CaseAppearance>
    {
        Task<List<CaseAppearance>> GetAlllAsync(Expression<Func<CaseAppearance, bool>>? predicate = null, params Expression<Func<CaseAppearance, object>>[]? includes);
    }
}
