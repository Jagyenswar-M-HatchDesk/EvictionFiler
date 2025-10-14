using EvictionFiler.Application.DTOs.OccupantDto;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public  interface IAdditionalOccupantsService
    {
        Task AddAdditionalOccupantsAsync(List<AdditionalOccupantDto> occupant);
        Task<List<AdditionalOccupants>> GetAllAdditionalOccupantsAsync(Guid legalCaseId);
        Task<bool> UpdateAdditionalOccupantsAsync(AdditionalOccupantDto occupant);
    }
}
