using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        Task<bool> UpdateAdditionalOccupant(AdditionalOccupantDto occupant);

    }
}
