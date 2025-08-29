using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.MasterDtos.StateDto;
using EvictionFiler.Application.DTOs.PaginationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface IStateService
    {
        Task<bool> Create(EditToStateDto dto);
        Task<PaginationDto<EditToStateDto>> GetAllStateAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateStateAsync(EditToStateDto dto);

        Task<EditToStateDto?> GetStateByIdAsync(Guid? id);
        Task<bool> DeleteStateAsync(Guid id);
        
    }
}
