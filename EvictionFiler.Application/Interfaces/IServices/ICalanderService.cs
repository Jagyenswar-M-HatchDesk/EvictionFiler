using EvictionFiler.Application.DTOs.CalanderDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICalanderService
    {
        Task<bool> GenrateCalander(CalanderDto dto);
        Task<List<CalanderDto>> GetAllCalanderAsync();
    }
}
