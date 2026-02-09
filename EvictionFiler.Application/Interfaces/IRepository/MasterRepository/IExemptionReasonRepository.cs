using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;
using System.Linq.Expressions;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
    public interface IExemptionReasonRepository : IRepository<ExemptionReason>
    {
        Task<IEnumerable<ExemptionReason>> GetAllAsync5(Expression<Func<ExemptionReason, bool>>? predicate = null, params Expression<Func<ExemptionReason, object>>[]? includes);
    }
}
