using System.Linq.Expressions;

namespace EvictionFiler.Application.Interfaces.IRepository
{
	public interface ICodeGenratorRepository
	{
		Task<string> GenerateCodeAsync<TEntity>(
		Expression<Func<TEntity, string?>> codeSelector,
		string prefix
	) where TEntity : class;
	}
}
