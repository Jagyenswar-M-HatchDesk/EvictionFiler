//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EvictionFiler.Domain.Entities.Master;
//using EvictionFiler.Infrastructure.DbContexts;
//using Microsoft.EntityFrameworkCore;

//namespace EvictionFiler.Infrastructure.DataSeeding
//{
//	public class DbInitalizer
//	{
//		public static async Task Seed(MainDbContext context)
//		{
//			try
//			{
//				await context.Database.MigrateAsync();
//				await SeedLanguage(context);
//				await SeedPremiseType(context);
//				await SeedRegulationStatus(context);
//				await SeedState(context);
//				await SeedTypeOfOwner(context);
//				await SeedLandlordTypes(context);
//				await SeedReasonHolder(context);
//				await SeedTenancyTypes(context);
//				await SeedIsUnitIlligal(context);
//				await context.SaveChangesAsync();
//			}
//			catch (Exception ex)
//			{
//				throw;
//			}
//		}





//		private static async Task SeedLanguage(MainDbContext context)
//		{

//			var lang = InitialDataGenerator.GetLangauge();
//			foreach (var l in lang)
//			{
//				if (context.MstLanguages.FirstOrDefault(d => d.Name == l.Name) == null)
//				{
//					await context.MstLanguages.AddAsync(l);
//				}
//			}
//		}

//		private static async Task SeedPremiseType(MainDbContext context)
//		{

//			var type = InitialDataGenerator.GetPremiseType();
//			foreach (var p in type)
//			{
//				if (context.MstPremiseTypes.FirstOrDefault(d => d.Name == p.Name) == null)
//				{
//					await context.MstPremiseTypes.AddAsync(p);
//				}
//			}
//		}

//		private static async Task SeedRegulationStatus(MainDbContext context)
//		{

//			var status = InitialDataGenerator.GetRegulationStatus();
//			foreach (var p in status)
//			{
//				if (context.MstRegulationStatus.FirstOrDefault(d => d.Name == p.Name) == null)
//				{
//					await context.MstRegulationStatus.AddAsync(p);
//				}
//			}
//		}

//		private static async Task SeedState(MainDbContext context)
//		{

//			var state = InitialDataGenerator.GetState();
//			foreach (var s in state)
//			{
//				if (context.MstStates.FirstOrDefault(d => d.Name == s.Name) == null)
//				{
//					await context.MstStates.AddAsync(s);
//				}
//			}
//		}

//		private static async Task SeedTypeOfOwner(MainDbContext context)
//		{

//			var typeOwner = InitialDataGenerator.GetTypeOfOwner();
//			foreach (var t in typeOwner)
//			{
//				if (context.MstTypeOfOwners.FirstOrDefault(d => d.Name == t.Name) == null)
//				{
//					await context.MstTypeOfOwners.AddAsync(t);
//				}
//			}
//		}




//		private static async Task SeedLandlordTypes(MainDbContext context)
//		{
//			var landlordtypes = InitialDataGenerator.GetLandlordTypes();
//			foreach (var type in landlordtypes)
//			{
//				if (context.MstLandlordTypes.FirstOrDefault(d => d.Name == type.Name) == null)
//				{
//					await context.MstLandlordTypes.AddAsync(type);
//				}
//			}
//		}

//		private static async Task SeedTenancyTypes(MainDbContext context)
//		{
//			var tenancytypes = InitialDataGenerator.GetTenancyTypes();
//			foreach (var type in tenancytypes)
//			{
//				if (context.MstTenancyTypes.FirstOrDefault(d => d.Name == type.Name) == null)
//				{
//					await context.MstTenancyTypes.AddAsync(type);
//				}
//			}
//		}

//		private static async Task SeedIsUnitIlligal(MainDbContext context)
//		{
//			var units = InitialDataGenerator.GetIsUnitIllegal();
//			foreach (var type in units)
//			{
//				if (context.MstIsUnitIllegal.FirstOrDefault(d => d.Name == type.Name) == null)
//				{
//					await context.MstIsUnitIllegal.AddAsync(type);
//				}
//			}
//		}

//		private static async Task SeedReasonHolder(MainDbContext context)
//		{
//			var Reasons = InitialDataGenerator.GetReasonHoldover();
//			foreach (var type in Reasons)
//			{
//				if (context.MstReasonHoldover.FirstOrDefault(d => d.Name == type.Name) == null)
//				{
//					await context.MstReasonHoldover.AddAsync(type);
//				}
//			}
//		}


//	}
//}


using System;
using System.Linq;
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
				await SeedLanguage(context);
				await SeedPremiseType(context);
				await SeedRegulationStatus(context);
				await SeedState(context);
				await SeedTypeOfOwner(context);
				await SeedLandlordTypes(context);
				await SeedReasonHolder(context);
				await SeedTenancyTypes(context);
				await SeedIsUnitIllegal(context);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Seeding Error: {ex.Message}");
				throw;
			}
		}

		private static async Task SeedLanguage(MainDbContext context)
		{
			var existing = await context.MstLanguages.Select(x => x.Name).ToListAsync();
			var newItems = InitialDataGenerator.GetLangauge().Where(x => !existing.Contains(x.Name)).ToList();

			if (newItems.Any())
			{
				await context.MstLanguages.AddRangeAsync(newItems);
				await context.SaveChangesAsync();
			}
		}

		private static async Task SeedPremiseType(MainDbContext context)
		{
			var existing = await context.MstPremiseTypes.Select(x => x.Name).ToListAsync();
			var newItems = InitialDataGenerator.GetPremiseType().Where(x => !existing.Contains(x.Name)).ToList();

			if (newItems.Any())
			{
				await context.MstPremiseTypes.AddRangeAsync(newItems);
				await context.SaveChangesAsync();
			}
		}

		private static async Task SeedRegulationStatus(MainDbContext context)
		{
			var existing = await context.MstRegulationStatus.Select(x => x.Name).ToListAsync();
			var newItems = InitialDataGenerator.GetRegulationStatus().Where(x => !existing.Contains(x.Name)).ToList();

			if (newItems.Any())
			{
				await context.MstRegulationStatus.AddRangeAsync(newItems);
				await context.SaveChangesAsync();
			}
		}

		private static async Task SeedState(MainDbContext context)
		{
			var existing = await context.MstStates.Select(x => x.Name).ToListAsync();
			var newItems = InitialDataGenerator.GetState().Where(x => !existing.Contains(x.Name)).ToList();

			if (newItems.Any())
			{
				await context.MstStates.AddRangeAsync(newItems);
				await context.SaveChangesAsync();
			}
		}

		private static async Task SeedTypeOfOwner(MainDbContext context)
		{
			var existing = await context.MstTypeOfOwners.Select(x => x.Name).ToListAsync();
			var newItems = InitialDataGenerator.GetTypeOfOwner().Where(x => !existing.Contains(x.Name)).ToList();

			if (newItems.Any())
			{
				await context.MstTypeOfOwners.AddRangeAsync(newItems);
				await context.SaveChangesAsync();
			}
		}

		private static async Task SeedLandlordTypes(MainDbContext context)
		{
			var existing = await context.MstLandlordTypes.Select(x => x.Name).ToListAsync();
			var newItems = InitialDataGenerator.GetLandlordTypes().Where(x => !existing.Contains(x.Name)).ToList();

			if (newItems.Any())
			{
				await context.MstLandlordTypes.AddRangeAsync(newItems);
				await context.SaveChangesAsync();
			}
		}

		private static async Task SeedTenancyTypes(MainDbContext context)
		{
			var existing = await context.MstTenancyTypes.Select(x => x.Name).ToListAsync();
			var newItems = InitialDataGenerator.GetTenancyTypes().Where(x => !existing.Contains(x.Name)).ToList();

			if (newItems.Any())
			{
				await context.MstTenancyTypes.AddRangeAsync(newItems);
				await context.SaveChangesAsync();
			}
		}

		private static async Task SeedIsUnitIllegal(MainDbContext context)
		{
			var existing = await context.MstIsUnitIllegal.Select(x => x.Name).ToListAsync();
			var newItems = InitialDataGenerator.GetIsUnitIllegal().Where(x => !existing.Contains(x.Name)).ToList();

			if (newItems.Any())
			{
				await context.MstIsUnitIllegal.AddRangeAsync(newItems);
				await context.SaveChangesAsync();
			}
		}

		private static async Task SeedReasonHolder(MainDbContext context)
		{
			var existing = await context.MstReasonHoldover.Select(x => x.Name).ToListAsync();
			var newItems = InitialDataGenerator.GetReasonHoldover().Where(x => !existing.Contains(x.Name)).ToList();

			if (newItems.Any())
			{
				await context.MstReasonHoldover.AddRangeAsync(newItems);
				await context.SaveChangesAsync();
			}
		}
	}
}
