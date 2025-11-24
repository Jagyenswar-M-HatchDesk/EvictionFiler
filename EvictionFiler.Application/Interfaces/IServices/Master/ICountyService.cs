
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.MasterDtos.CaseTypeDto;
using EvictionFiler.Application.DTOs.MasterDtos.CountyDto;
using EvictionFiler.Application.DTOs.PaginationDto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EvictionFiler.Application.Interfaces.IServices.Master
{
    public interface ICountyService
    {
        Task<bool> Create(EditToCountyDto dto);
        Task<PaginationDto<EditToCountyDto>> GetAllCountyAsync(int pageNumber, int pageSize, string searchTerm);
        Task<bool> UpdateCountyAsync(EditToCountyDto dto);

        Task<EditToCountyDto?> GetCountyByIdAsync(Guid? id);
        Task<bool> DeleteCountyAsync(Guid id);
        Task<List<EditToCountyDto>> GetAllCounty();


    }
}
