using EvictionFiler.Application.DTOs.OccupantDto;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public  interface IAdditionalOccupantsService
    {
        Task AddAdditionalOccupantsAsync(List<AdditionalOccupantDto> occupant);
        Task<List<AdditionalOccupantDto>> GetAllAdditionalOccupantsAsync(Guid legalCaseId);
        Task<bool> UpdateAdditionalOccupantsAsync(List<AdditionalOccupantDto> occupant);
        Task<bool> DeleteAdditionalOccupants(List<AdditionalOccupantDto> occupant);
    }
}
