using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CaseNoticeInfoRepository : Repository<CaseNoticeInfo>, ICaseNoticeInfoRepository
    {
        private readonly MainDbContext _mainDbContext;
        public CaseNoticeInfoRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<CaseNoticeInfo?> GetByCaseAndFormTypeAsync(Guid legalCaseId, Guid formTypeId)
        {
            return await _mainDbContext.CaseNoticeInfo
                .Where(x =>
                    x.LegalCaseId == legalCaseId &&
                    x.FormtypeId == formTypeId).FirstOrDefaultAsync();
        }
    }
}
