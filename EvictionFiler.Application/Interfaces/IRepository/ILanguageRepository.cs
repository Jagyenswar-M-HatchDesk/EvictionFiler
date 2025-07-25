using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Application.Interfaces.IRepository
{
	public interface ILanguageRepository
	{
		Task<List<Language>> GetAllLanguage();
	}
}
