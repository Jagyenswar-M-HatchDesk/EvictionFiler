using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IUserRepository
{
    public interface ILandLordRepository : IRepository<LandLord>
	{
		Task<string?> GetLastLandLordCodeAsync();
		//Task AddRangeAsync(List<LandLord> landlords);


        Task<List<CreateLandLordDto>> SearchLandlordByCode(string code);
        Task<List<CreateLandLordDto>> SearchLandlordsAsync(string query, Guid clientId);
		Task<LandlordWithBuildings?> GetLandlordWithBuildingsAsync(Guid landlordId);
        Task<List<EditLandlordDto>> GetByClientIdAsync(Guid clientId);
        Task<List<TypeOfOwner>> GetAllOwner();
		//Task<string> GenerateLandlordCodeAsync();
	}
}
