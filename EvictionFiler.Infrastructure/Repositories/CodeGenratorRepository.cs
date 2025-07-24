using System.Linq.Expressions;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

public class CodeGenratorRepository : ICodeGenratorRepository
{
	private readonly MainDbContext _context;

	public CodeGenratorRepository(MainDbContext context)
	{
		_context = context;
	}



	public async Task<string> GenerateCodeAsync<TEntity>(
		Expression<Func<TEntity, string?>> codeSelector,
		string prefix
	) where TEntity : class
	{
		var codes = await _context.Set<TEntity>()
			.Where(EntityHasPrefix(codeSelector, prefix))
			.Select(codeSelector)
			.ToListAsync();

		int maxNumber = 0;

		foreach (var code in codes)
		{
			if (!string.IsNullOrEmpty(code) && code.StartsWith(prefix))
			{
				var numericPart = code.Substring(prefix.Length);
				if (int.TryParse(numericPart, out int number))
				{
					if (number > maxNumber)
						maxNumber = number;
				}
			}
		}

		int nextNumber = maxNumber + 1;
		return $"{prefix}{nextNumber.ToString("D3")}";
	}

	// Helper method to generate Where clause
	private static Expression<Func<TEntity, bool>> EntityHasPrefix<TEntity>(
		Expression<Func<TEntity, string?>> selector,
		string prefix
	)
	{
		var parameter = selector.Parameters[0];
		var body = Expression.AndAlso(
			Expression.NotEqual(selector.Body, Expression.Constant(null, typeof(string))),
			Expression.Call(
				selector.Body!,
				typeof(string).GetMethod("StartsWith", new[] { typeof(string) })!,
				Expression.Constant(prefix)
			)
		);

		return Expression.Lambda<Func<TEntity, bool>>(body, parameter);
	}

}
