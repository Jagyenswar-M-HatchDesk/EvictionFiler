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
				await SeedLanguage(context);
				await SeedPremiseType(context);
				await SeedCaseTypes(context);
                await SeedDateRent(context);
				await SeedTypeOfOwner(context);
                await context.SaveChangesAsync();

                await SeedRenewalStatus(context);
                await SeedRegulationStatus(context);
				await SeedState(context);
				await SeedFormTypes(context);
				await SeedLandlordTypes(context);
				await SeedReasonHolder(context);
				await SeedTenancyTypes(context);
				await SeedIsUnitIlligal(context);
				await SeedCaseprograms(context);
				await SeedClientRoles(context);

                await context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
		}


		private static async Task SeedCaseTypes(MainDbContext context)
		{
			var casetypes = InitialDataGenerator.GetCaseTypes();
			foreach (var type in casetypes)
			{
				if (context.MstCaseTypes.FirstOrDefault(d => d.Name == type.Name) == null)
				{
					await context.MstCaseTypes.AddAsync(type);
				}
			}
		}

		private static async Task SeedCaseprograms(MainDbContext context)
		{
			var casetypes = InitialDataGenerator.GetCasePrograms();
			foreach (var type in casetypes)
			{
				if (context.MstCaseProgram.FirstOrDefault(d => d.Name == type.Name) == null)
				{
					await context.MstCaseProgram.AddAsync(type);
				}
			}
		}

        private static async Task SeedClientRoles(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetClientRoles();
            foreach (var type in casetypes)
            {
                if (context.MstClientRoles.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstClientRoles.AddAsync(type);
                }
            }
        }

        private static async Task SeedDateRent(MainDbContext context)
        {
            var dateRent = InitialDataGenerator.GetDateRent();
            foreach (var date in dateRent)
            {
                if (context.MstDateRent.FirstOrDefault(d => d.Name == date.Name) == null)
                {
                    await context.MstDateRent.AddAsync(date);
                }
            }
        }


        private static async Task SeedLanguage(MainDbContext context)
		{

			var lang = InitialDataGenerator.GetLangauge();
			foreach (var l in lang)
			{
				if (context.MstLanguages.FirstOrDefault(d => d.Name == l.Name) == null)
				{
					await context.MstLanguages.AddAsync(l);
				}
			}
		}

        private static async Task SeedRenewalStatus(MainDbContext context)
        {

            var renewal = InitialDataGenerator.GetRenewalStatus();
            foreach (var r in renewal)
            {
                if (context.MstRenewalStatus.FirstOrDefault(d => d.Name == r.Name) == null)
                {
                    await context.MstRenewalStatus.AddAsync(r);
                }
            }
        }

        private static async Task SeedFormTypes(MainDbContext context)
		{
			var formTypes = InitialDataGenerator.GetFormTypes();

			foreach (var formType in formTypes)
			{
				if (context.MstFormTypes.FirstOrDefault(d => d.Name == formType.Name) == null)
				{
					var caseType = context.MstCaseTypes.FirstOrDefault(c => c.Name == formType.CaseTypeName);

					if (caseType != null)
					{
						formType.CaseTypeId = caseType.Id; 
						await context.MstFormTypes.AddAsync(formType);
					}
					else
					{
						Console.WriteLine($"[Seed Warning] CaseType '{formType.CaseTypeName}' not found for FormType '{formType.Name}'");
					}
				}
			}
		}

		private static async Task SeedPremiseType(MainDbContext context)
		{

			var type = InitialDataGenerator.GetPremiseType();
			foreach (var p in type)
			{
				if (context.MstPremiseTypes.FirstOrDefault(d => d.Name == p.Name) == null)
				{
					await context.MstPremiseTypes.AddAsync(p);
				}
			}
		}

		private static async Task SeedRegulationStatus(MainDbContext context)
		{

			var status = InitialDataGenerator.GetRegulationStatus();
			foreach (var p in status)
			{
				if (context.MstRegulationStatus.FirstOrDefault(d => d.Name == p.Name) == null)
				{
					await context.MstRegulationStatus.AddAsync(p);
				}
			}
		}

		private static async Task SeedState(MainDbContext context)
		{

			var state = InitialDataGenerator.GetState();
			foreach (var s in state)
			{
				if (context.MstStates.FirstOrDefault(d => d.Name == s.Name) == null)
				{
					await context.MstStates.AddAsync(s);
				}
			}
		}

		private static async Task SeedTypeOfOwner(MainDbContext context)
		{

			var typeOwner = InitialDataGenerator.GetTypeOfOwner();
			foreach (var t in typeOwner)
			{
				if (context.MstTypeOfOwners.FirstOrDefault(d => d.Name == t.Name) == null)
				{
					await context.MstTypeOfOwners.AddAsync(t);
				}
			}
		}




		private static async Task SeedLandlordTypes(MainDbContext context)
		{
			var landlordtypes = InitialDataGenerator.GetLandlordTypes();
			foreach (var type in landlordtypes)
			{
				if (context.MstLandlordTypes.FirstOrDefault(d => d.Name == type.Name) == null)
				{
					await context.MstLandlordTypes.AddAsync(type);
				}
			}
		}

		private static async Task SeedTenancyTypes(MainDbContext context)
		{
			var tenancytypes = InitialDataGenerator.GetTenancyTypes();
			foreach (var type in tenancytypes)
			{
				if (context.MstTenancyTypes.FirstOrDefault(d => d.Name == type.Name) == null)
				{
					await context.MstTenancyTypes.AddAsync(type);
				}
			}
		}

		private static async Task SeedIsUnitIlligal(MainDbContext context)
		{
			var units = InitialDataGenerator.GetIsUnitIllegal();
			foreach (var type in units)
			{
				if (context.MstIsUnitIllegal.FirstOrDefault(d => d.Name == type.Name) == null)
				{
					await context.MstIsUnitIllegal.AddAsync(type);
				}
			}
		}

		private static async Task SeedReasonHolder(MainDbContext context)
		{
			var Reasons = InitialDataGenerator.GetReasonHoldover();
			foreach (var type in Reasons)
			{
				if (context.MstReasonHoldover.FirstOrDefault(d => d.Name == type.Name) == null)
				{
					await context.MstReasonHoldover.AddAsync(type);
				}
			}
		}


	}
}



