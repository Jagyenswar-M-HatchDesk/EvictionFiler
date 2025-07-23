using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Entities.Master;
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
				await SeedClientRole(context);
			
				await SeedLanguage(context);
				await SeedPremiseType(context);
				await SeedRegulationStatus(context);
				await SeedState(context);
				await SeedTypeOfOwner(context);
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
			var caseTypes = context.mst_CaseTypes.ToList(); // ✅ Load case types from DB
			var subTypes = InitialDataGenerator.GetCaseSubTypes(caseTypes); // ✅ Pass as argument
			foreach (var subtype in subTypes)
			{
				if (context.mst_CaseSubTypes.FirstOrDefault(d => d.Name == subtype.Name) == null)
				{
					await context.mst_CaseSubTypes.AddAsync(subtype);
				}
			}
		}

		private static async Task SeedClientRole(MainDbContext context)
		{
		
			var clientroles = InitialDataGenerator.GetClientRole(); 
			foreach (var clientrole in clientroles)
			{
				if (context.mst_ClienrRoles.FirstOrDefault(d => d.Name == clientrole.Name) == null)
				{
					await context.mst_ClienrRoles.AddAsync(clientrole);
				}
			}
		}

		private static async Task SeedLanguage(MainDbContext context)
		{

			var lang = InitialDataGenerator.GetLangauge();
			foreach (var l in lang)
			{
				if (context.mst_Languages.FirstOrDefault(d => d.Name == l.Name) == null)
				{
					await context.mst_Languages.AddAsync(l);
				}
			}
		}

		private static async Task SeedPremiseType(MainDbContext context)
		{

			var type = InitialDataGenerator.GetPremiseType();
			foreach (var p in type)
			{
				if (context.mst_PremiseTypes.FirstOrDefault(d => d.Name == p.Name) == null)
				{
					await context.mst_PremiseTypes.AddAsync(p);
				}
			}
		}

		private static async Task SeedRegulationStatus(MainDbContext context)
		{

			var status = InitialDataGenerator.GetRegulationStatus();
			foreach (var p in status)
			{
				if (context.mst_regulationStatus.FirstOrDefault(d => d.Name == p.Name) == null)
				{
					await context.mst_regulationStatus.AddAsync(p);
				}
			}
		}

		private static async Task SeedState(MainDbContext context)
		{

			var state = InitialDataGenerator.GetState();
			foreach (var s in state)
			{
				if (context.mst_State.FirstOrDefault(d => d.Name == s.Name) == null)
				{
					await context.mst_State.AddAsync(s);
				}
			}
		}

		private static async Task SeedTypeOfOwner(MainDbContext context)
		{

			var typeOwner = InitialDataGenerator.GetTypeOfOwner();
			foreach (var t in typeOwner)
			{
				if (context.mst_TypeOfOwners.FirstOrDefault(d => d.Name == t.Name) == null)
				{
					await context.mst_TypeOfOwners.AddAsync(t);
				}
			}
		}


		private static async Task SeedCaseTypes(MainDbContext context)
		{
			var casetypes = InitialDataGenerator.GetCaseTypes();
			foreach (var type in casetypes)
			{
				if (context.mst_CaseTypes.FirstOrDefault(d => d.Name == type.Name) == null)
				{
					await context.mst_CaseTypes.AddAsync(type);
				}
			}
		}

	
	}
}
