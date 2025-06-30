using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface ILandLordRepository
    {
        Task<bool> AddLandLord(CreateLandLordDto dto);
        Task<bool> DeleteLandLordAsync(Guid id);
        Task<bool> UpdateLandLordAsync(CreateLandLordDto dto);
        Task<LandLord?> GetLandLordByIdAsync(Guid id);
        Task<List<LandLord>> GetAllLandLordsAsync();
    }
}
