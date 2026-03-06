using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.Interfaces.IRepository.Dashboard;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Infrastructure.Repositories.Dashboard
{
    public class PiplelineRepository : IPipelineRepository
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public PiplelineRepository(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
          
        }
        public async Task<List<PipeLineChartItem>> GetPipelineChartDataAsync(string userId, bool isAdmin)
        {
            await using var _context = contextFactory.CreateDbContext();
            var query = _context.LegalCases
                .Include(e => e.CaseType).Include(e => e.User)
                .Where(c => c.IsActive);

            if (!isAdmin)
            {
                var userGuid = Guid.Parse(userId);
                query = query.Where(c => c.User.FirmId == userGuid);
            }

            // 1️⃣ RAW SQL-safe query
            var raw = await query
                .GroupBy(c => new { c.CreatedOn.Year, c.CreatedOn.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    NonPayment = g.Count(x => x.CaseType.Name == "NonPayment"),
                    Holdover = g.Count(x => x.CaseType.Name == "Holdover"),
                    Other = g.Count(x => x.CaseType.Name != "NonPayment" &&
                                         x.CaseType.Name != "Holdover")
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();

            // 2️⃣ Project to your DTO in C#
            return raw
                .Select(x => new PipeLineChartItem
                {
                    Month = new DateTime(x.Year, x.Month, 1).ToString("MMM"),
                    NonPayment = x.NonPayment,
                    Holdover = x.Holdover,
                    Other = x.Other
                })
                .ToList();
        }
    }
}
