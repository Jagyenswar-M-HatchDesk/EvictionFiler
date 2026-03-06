using EvictionFiler.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IRepository.Dashboard
{
   public interface IPipelineRepository
    {
        Task<List<PipeLineChartItem>> GetPipelineChartDataAsync(string userId, bool isAdmin);
    }
}
