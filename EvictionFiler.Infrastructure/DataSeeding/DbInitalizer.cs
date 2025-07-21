using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EvictionFiler.Infrastructure.DataSeeding
{
	public class DbInitalizer
	{
		public static async Task Seed(MainDbContext context)
		{
			try
			{
				await context.Database.MigrateAsync();
				await SeedCaseTypes(context);
				await context.SaveChangesAsync();

				await SeedCaseSubTypes(context);
				await context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		private static async Task SeedCaseSubTypes(MainDbContext context)
		{
			var caseTypes = context.CaseTypes.ToList(); // ✅ Load case types from DB
			var subTypes = InitialDataGenerator.GetCaseSubTypes(caseTypes); // ✅ Pass as argument
			foreach (var subtype in subTypes)
			{
				if (context.CaseSubTypes.FirstOrDefault(d => d.Name == subtype.Name) == null)
				{
					await context.CaseSubTypes.AddAsync(subtype);
				}
			}
		}

		private static async Task SeedCaseTypes(MainDbContext context)
		{
			var casetypes = InitialDataGenerator.GetCaseTypes();
			foreach (var type in casetypes)
			{
				if (context.CaseTypes.FirstOrDefault(d => d.Name == type.Name) == null)
				{
					await context.CaseTypes.AddAsync(type);
				}
			}
		}

	
	}
}
