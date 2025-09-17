using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface ICategoryRepository : IRepository<Category>
    {
		Task<List<Category>> GetAllCategory();
	}
}
