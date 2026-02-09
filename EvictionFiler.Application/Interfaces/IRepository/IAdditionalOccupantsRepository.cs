using EvictionFiler.Application.DTOs.OccupantDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.Interfaces.IRepository
{
	public interface IAdditionalOccupantsRepository : IRepository<AdditionalOccupants>
	{
        Task AddAdditionalOccupant(List<AdditionalOccupantDto> tenant);
        Task<List<AdditionalOccupants>> GetAllOccupantsByCaseId(Guid legalcaseId);
        Task<AdditionalOccupants> GetAllOccupantsById(Guid Id);
        Task<bool> UpdateAdditionalOccupant(List<AdditionalOccupantDto> occupant);
        Task<bool> DeleteOccupants(Guid Id);
    }
}
