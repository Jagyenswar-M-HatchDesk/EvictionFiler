﻿using System;
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
				await SeedLandlordTypes(context);
				await SeedTenancyTypes(context);
				await SeedIsUnitIlligal(context);
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
			var caseTypes = context.MstCaseTypes.ToList(); 
			var subTypes = InitialDataGenerator.GetCaseSubTypes(caseTypes); 
			foreach (var subtype in subTypes)
			{
				if (context.MstCaseSubTypes.FirstOrDefault(d => d.Name == subtype.Name) == null)
				{
					await context.MstCaseSubTypes.AddAsync(subtype);
				}
			}
		}

		private static async Task SeedClientRole(MainDbContext context)
		{
		
			var clientroles = InitialDataGenerator.GetClientRole(); 
			foreach (var clientrole in clientroles)
			{
				if (context.MstClientRoles.FirstOrDefault(d => d.Name == clientrole.Name) == null)
				{
					await context.MstClientRoles.AddAsync(clientrole);
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


	}
}
