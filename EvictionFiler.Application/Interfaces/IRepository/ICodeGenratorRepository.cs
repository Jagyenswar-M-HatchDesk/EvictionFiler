using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
