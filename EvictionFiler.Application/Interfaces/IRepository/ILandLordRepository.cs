using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository
{
    public interface ILandLordRepository : IRepository<LandLord>
	{
		Task<string?> GetLastLandLordCodeAsync();
        Task<List<EditToLandlordDto>> SearchLandlordsAsync(string query  , Guid clientId);
		Task<LandlordWithBuildings?> GetLandlordWithBuildingsAsync(Guid landlordId);
        Task<List<EditToLandlordDto>> GetByClientIdAsync(Guid? clientId);
        Task<List<TypeOfOwner>> GetAllOwner();
        Task<string> GenerateLandlordCodeAsync();
        Task<EditToLandlordDto> GetLandlordByIdAsync(Guid landlordId);


    }
}
