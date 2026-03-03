using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices.Dashboard
{
    public interface IDashboardService
    {
        Task<int> GetTotalCasesCountAsync(string userId, bool isAdmin);
        Task<int> GetAllTodayCaseHearingAsync(string userId, bool isAdmin);
        
    }
}
