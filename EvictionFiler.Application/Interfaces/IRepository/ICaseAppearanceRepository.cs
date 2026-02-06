using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface ICaseAppearanceRepository : IRepository<CaseAppearance>
    {
        Task<List<CaseAppearance>> GetAlllAsync(Expression<Func<CaseAppearance, bool>>? predicate = null, params Expression<Func<CaseAppearance, object>>[]? includes);
    }
}
