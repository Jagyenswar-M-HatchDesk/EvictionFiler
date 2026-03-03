using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.RemainderCenterDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IRepository.Dashboard;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories.Dashboard
{
    public class DashboardReadRepository : IDashboardReadRepository
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public DashboardReadRepository(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public async Task<int> GetTotalCasesCountAsync(string userId, bool isAdmin)
        {
            await using var _context = contextFactory.CreateDbContext();
            if (isAdmin)
            {
                var today = DateTime.Today;
                var startOfWeek = today.AddDays(-(int)today.DayOfWeek + 1); // Monday
                var endOfWeek = startOfWeek.AddDays(7);

                var count = await _context.LegalCases
                    .Where(e => e.CreatedOn >= startOfWeek && e.CreatedOn < endOfWeek)
                    .CountAsync();

                return count;
            }
            else
            {

                var userGuid = Guid.Parse(userId);

                var today = DateTime.Today;
                var startOfWeek = today.AddDays(-(int)today.DayOfWeek + 1); // Monday
                var endOfWeek = startOfWeek.AddDays(7);

                var count = await _context.LegalCases.Include(e => e.User)
                    .Where(e => e.CreatedOn >= startOfWeek && e.CreatedOn < endOfWeek && e.User.FirmId == userGuid)
                    .CountAsync();
                return count;

            }
        }
        public async Task<List<EditToRemainderCenterDto>?> GetAllInCompleteRemainder(bool isSuperAdmin, Guid? userId = null)
        {
            try
            {
                await using var db = await contextFactory.CreateDbContextAsync();

                var query = db.TblRemainderCenter
                    .Include(x => x.RemainderType)
                    .Include(x => x.County)
                    .Include(x => x.Tenant)
                    .Include(x => x.Case)
                    .Include(x => x.ReminderEscalates)
                    .Include(x => x.User)
                    .Include(x => x.ReminderCategory)
                    .Where(x => x.IsDeleted != true &&
                                x.IsComplete != true &&
                                x.When <= DateTime.Now);

                if (userId != null && !isSuperAdmin)
                {
                    query = query.Where(e => e.User.FirmId == userId);
                }

                var calanders = await query.ToListAsync();

                var result = calanders.Select(dto => new EditToRemainderCenterDto
                {
                    Id = dto.Id,
                    When = dto.When,
                    CaseId = dto.CaseId,
                    CountyId = dto.CountyId,
                    TenantId = dto.TenantId,
                    RemainderTypeId = dto.RemainderTypeId,
                    Index = dto.Index,
                    Notes = dto.Notes,
                    RemainderTypeName = dto.RemainderType?.Name ?? "Unknown",
                    CountyName = dto.County?.Name ?? "Unknown",
                    TenantName = dto.Tenant?.FirstName ?? "Unknown",
                    CaseCode = dto.Case?.Casecode ?? "Unknown",
                    ReminderName = dto.ReminderName,
                    ReminderCategoryId = dto.ReminderCategoryId,
                    ReminderEscalateId = dto.ReminderEscalateId,
                    ReminderCategoryName = dto.ReminderCategory?.Name ?? "",
                    ReminderEscalateName = dto.ReminderEscalates?.Name ?? "",
                    IsComplete = dto.IsComplete
                }).ToList();

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
