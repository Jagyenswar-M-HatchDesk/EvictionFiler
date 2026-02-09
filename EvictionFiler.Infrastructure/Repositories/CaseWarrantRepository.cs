using EvictionFiler.Application.DTOs.CaseWarrantDtos;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Infrastructure.DbContexts;
using EvictionFiler.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.Repositories
{
    public class CaseWarrantRepository : Repository<CaseWarrant>, ICaseWarrantRepository
    {
        private readonly MainDbContext _maindbcontext; private readonly IDbContextFactory<MainDbContext> _contextFactory;

        public CaseWarrantRepository(MainDbContext maindbcontext, IDbContextFactory<MainDbContext> contextFactory) : base(maindbcontext, contextFactory)
        {
            _maindbcontext = maindbcontext;
            _contextFactory = contextFactory;
        }

        public async Task<bool> AddEditCaseWarrant(CaseWarrantDto dto)
        {
            await using var context = _contextFactory.CreateDbContext(); 
            try
            {
                var existing = await context.CaseWarrants.Where(e => e.LegalCaseId == dto.LegalcaseId).FirstOrDefaultAsync();
                if (existing != null)
                {
                    existing.ReFileDate = dto.ReFileDate;
                    existing.WarrantRequested = dto.WarrantRequested;
                    existing.WarrantIssued = dto.WarrantIssued;
                    existing.WarrantRejected = dto.WarrantRejected;
                    existing.EvictionExecuted = dto.EvictionExecuted;
                    existing.ExecutionEligible = dto.ExecutionEligible;
                    existing.NoticeServed = dto.NoticeServed;
                    existing.MarshalId = dto.MarshalId;
                    existing.LegalCaseId = dto.LegalcaseId;
                    existing.UpdatedOn = DateTime.Now;

                    var result = await context.SaveChangesAsync();
                    return result > 0 ? true : false;
                }
                else
                {
                    var addeddata = new CaseWarrant
                    {
                        ReFileDate = dto.ReFileDate,
                        WarrantRequested = dto.WarrantRequested,
                        WarrantIssued = dto.WarrantIssued,
                        WarrantRejected = dto.WarrantRejected,
                        EvictionExecuted = dto.EvictionExecuted,
                        ExecutionEligible = dto.ExecutionEligible,
                        NoticeServed = dto.NoticeServed,
                        MarshalId = dto.MarshalId,
                        LegalCaseId = dto.LegalcaseId,
                        CreatedOn = DateTime.Now,
                    };

                    var added = await context.CaseWarrants.AddAsync(addeddata);
                    var result = await context.SaveChangesAsync();
                    return result > 0 ? true : false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
