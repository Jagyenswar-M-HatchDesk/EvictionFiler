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
        Task<bool> AddLandLord(List<CreateLandLordDto> dtoList);

		Task<bool> DeleteLandLordAsync(Guid id);
        Task<bool> UpdateLandLordAsync(CreateLandLordDto dto);
        Task<CreateLandLordDto?> GetLandLordByIdAsync(Guid id);
        Task<List<CreateLandLordDto>> GetAllLandLordsAsync();
        Task<List<CreateLandLordDto>> SearchLandlordByCode(string code);
        Task<List<CreateLandLordDto>> SearchLandlordsAsync(string query);

	}
}
