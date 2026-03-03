using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories.ReadRepositories
{
    public  class CaseHearingReadRepository : ReadRepository<CaseHearing>, ICaseHearingReadRepository
    {
        private readonly IDbContextFactory<MainDbContext> _dbContextFactory;

        public CaseHearingReadRepository(IDbContextFactory<MainDbContext> dbContextFactory): base(dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<int> GetAllTodayCaseHearingAsync(Guid? firmId, bool isAdmin)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();

            var query = db.CaseHearings
                .Include(e => e.User)
                .Where(x => x.HearingDate.HasValue &&
                            x.HearingDate.Value.Date == DateTime.Today);

            if (!isAdmin && firmId.HasValue)
            {
                query = query.Where(c => c.User.FirmId == firmId);
            }

            return await query.CountAsync();
        }
    }
}
