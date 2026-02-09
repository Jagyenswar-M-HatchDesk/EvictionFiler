using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;
using System.Linq.Expressions;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
    public interface ICityRepository : IRepository<City>
    {
        Task<List<City>> GetAlllAsync(Expression<Func<City, bool>>? predicate = null, params Expression<Func<City, object>>[]? includes);
    }
}
