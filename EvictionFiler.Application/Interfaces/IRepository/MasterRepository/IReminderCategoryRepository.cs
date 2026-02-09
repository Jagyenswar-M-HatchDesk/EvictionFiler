using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;
using System.Linq.Expressions;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
    public interface IReminderCategoryRepository : IRepository<ReminderCategory>
    {
        Task<IEnumerable<ReminderCategory>> GetAllAsync1(Expression<Func<ReminderCategory, bool>>? predicate = null, params Expression<Func<ReminderCategory, object>>[]? includes);
    }
}
