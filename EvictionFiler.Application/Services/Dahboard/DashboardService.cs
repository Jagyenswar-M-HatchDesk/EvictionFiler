using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Application.Interfaces.IRepository.Dashboard;
using EvictionFiler.Application.Interfaces.IRepository.ReadRepositories;
using EvictionFiler.Application.Interfaces.IServices.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services.Dahboard
{
    public class DashboardService:IDashboardService
    {
        private readonly IDashboardReadRepository _dashboardReadRepository;
        private readonly ICaseHearingReadRepository caseHearingReadRepository;

        public DashboardService(IDashboardReadRepository dashboardReadRepository,ICaseHearingReadRepository caseHearingReadRepository)
        {
            _dashboardReadRepository = dashboardReadRepository;
            this.caseHearingReadRepository = caseHearingReadRepository;
        }
        public async Task<int> GetTotalCasesCountAsync(string userId, bool isAdmin)
        {
            return await _dashboardReadRepository.GetTotalCasesCountAsync(userId, isAdmin);
        }
        public async Task<int> GetAllTodayCaseHearingAsync(string userId, bool isAdmin)
        {
            Guid? firmId = null;

            if (!isAdmin)
            {
                firmId = Guid.Parse(userId);
            }

            return await caseHearingReadRepository.GetAllTodayCaseHearingAsync(firmId, isAdmin);
        }
    }
}
