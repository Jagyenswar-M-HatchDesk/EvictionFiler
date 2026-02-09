using EvictionFiler.Application.DTOs.MasterDtos.CountyDto;
using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface ICountyRepository : IRepository<County>
    {



        Task<List<EditToCountyDto>> SearchCounty(string searchTerm);


    }
}
