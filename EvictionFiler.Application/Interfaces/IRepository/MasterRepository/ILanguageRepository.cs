using EvictionFiler.Application.Interfaces.IRepository.Base;
using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository.MasterRepository
{
	public interface ILanguageRepository : IRepository<Language>
    {
		Task<List<Language>> GetAllLanguage();
	}
}
