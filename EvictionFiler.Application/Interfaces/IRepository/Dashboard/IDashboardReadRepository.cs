using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.RemainderCenterDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.Dashboard
{
    public interface IDashboardReadRepository
    {
        Task<int> GetTotalCasesCountAsync(string userId, bool isAdmin);
        Task<List<EditToRemainderCenterDto>?> GetAllInCompleteRemainder(bool isSuperAdmin, Guid? userId = null);
    }
}
