using EvictionFiler.Application.DTOs.OccupantDto;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class AdditionalOccupantsService : IAdditionalOccupantsService
    {
        private readonly IAdditionalOccupantsRepository _additionalOccupantsRepository;

        public AdditionalOccupantsService(IAdditionalOccupantsRepository additionalOccupantsRepository)
        {
            _additionalOccupantsRepository = additionalOccupantsRepository;
        }

        public async Task AddAdditionalOccupantsAsync(List<AdditionalOccupantDto> occupant)
        {

            await _additionalOccupantsRepository.AddAdditionalOccupant(occupant);
        }

        public async Task<List<AdditionalOccupantDto>> GetAllAdditionalOccupantsAsync(Guid legalCaseId)
        {
            var occupants = await _additionalOccupantsRepository.GetAllOccupantsByCaseId(legalCaseId);
            return occupants.Select(e => new AdditionalOccupantDto
            {
                Id = e.Id,
                LegalCaseId = legalCaseId,
                Name = e.Name
            }).ToList();
        }

        public async Task<bool> UpdateAdditionalOccupantsAsync(AdditionalOccupantDto occupant)
        {

            return await _additionalOccupantsRepository.UpdateAdditionalOccupant(occupant);
        }
    }
}
