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
                await SeedBuildingTypes(context);
                await SeedCaseTypesHPD(context);
                await SeedBillingTypes(context);
                await SeedPartyRepresent(context);
                await SeedPartyRepresentPerDiem(context);
                await SeedDateRent(context);
                await SeedHarassmentType(context);
                await SeedDefenseType(context);
				await SeedAppearanceType(context);
                await SeedAppearanceTypePerDiem(context);
                await SeedReliefPetitionerType(context);
                await SeedReliefRespondentType(context);
                await SeedCaseTypePerdiem(context);
                await SeedRegistrationStatus(context);
                await  SeedDocumentInstructionsTypePerDiem(context);
                await SeedRate(context);
                await SeedPaymentMethod(context);
                await SeedReportingTypePerDiem(context);
                await SeedTenancyTypesForBuilding(context);
                await SeedExemptionReason(context);
                await SeedExemptionBasic(context);

                await SeedRemainderTypes(context);
                await SeedTypeOfOwner(context);
                await SeedAppearanceTypeforHearing(context);
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
				await SeedCaseStatus(context);
				await SeedCounty(context);
				await SeedCategory(context);
                await SeedUnitType(context);
                await SeedFilingMethod(context);
                await SeedServiceMethod(context);
                await SeedSubCaseType(context);
                await SeedCities(context);
                await SeedAppreanceMode(context);
                await SeedVirtualPlatform(context);
                await SeedCourtType(context);
                await SeedReminderCategory(context);
                await SeedReminderEscalates(context);
                await SeedDocumentType(context);
                await SeedCourtTodayTypes(context);
                await context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        private static async Task SeedAppearanceTypeforHearing(MainDbContext context)
        {
            var appearancetypes = InitialDataGenerator.GetAppearanceTypeforHearing();
            foreach (var type in appearancetypes)
            {
                if (context.MstAppearanceTypesForHearing.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstAppearanceTypesForHearing.AddAsync(type);
                }
            }
        }
        private static async Task SeedCourtTodayTypes(MainDbContext context)
        {
            var appearancetypes = InitialDataGenerator.GetCourtToday();
            foreach (var type in appearancetypes)
            {
                if (context.MstCourtTodayType.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstCourtTodayType.AddAsync(type);
                }
            }
        }
        private static async Task SeedDocumentType(MainDbContext context)
        {
            var appearancetypes = InitialDataGenerator.GetDocumentType();
            foreach (var type in appearancetypes)
            {
                if (context.MstDocumentType.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstDocumentType.AddAsync(type);
                }
            }
        }
        private static async Task SeedReminderCategory(MainDbContext context)
        {
            var appearancetypes = InitialDataGenerator.GetReminderCategory();
            foreach (var type in appearancetypes)
            {
                if (context.MstReminderCategory.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstReminderCategory.AddAsync(type);
                }
            }
        }
        private static async Task SeedReminderEscalates(MainDbContext context)
        {
            var appearancetypes = InitialDataGenerator.GetReminderEscalates();
            foreach (var type in appearancetypes)
            {
                if (context.MstReminderEscalates.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstReminderEscalates.AddAsync(type);
                }
            }
        }

        private static async Task SeedTenancyTypesForBuilding(MainDbContext context)
        {
            var tenancytypes = InitialDataGenerator.GetTenancyTypesForBuilding();
            foreach (var type in tenancytypes)
            {
                if (context.MstTenancyTypesForBuilding.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstTenancyTypesForBuilding.AddAsync(type);
                }
            }
        }

        private static async Task SeedExemptionBasic(MainDbContext context)
        {
            var eb = InitialDataGenerator.GetExemptionBasic();
            foreach (var type in eb)
            {
                if (context.MstExemptionBasic.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstExemptionBasic.AddAsync(type);
                }
            }
        }

        private static async Task SeedExemptionReason(MainDbContext context)
        {
            var er = InitialDataGenerator.GetExemptionReason();
            foreach (var type in er)
            {
                if (context.MstExemptionReason.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstExemptionReason.AddAsync(type);
                }
            }
        }

        private static async Task SeedPaymentMethod(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetPaymentMethod();
            foreach (var type in casetypes)
            {
                if (context.MstPaymentMethods.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstPaymentMethods.AddAsync(type);
                }
            }
        }
        private static async Task SeedAppreanceMode(MainDbContext context)
        {
            var modes = InitialDataGenerator.GetAppearanceMode();
            foreach (var type in modes)
            {
                if (context.MstAppearanceModes.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstAppearanceModes.AddAsync(type);
                }
            }
        }
        private static async Task SeedVirtualPlatform(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetVirtualPlatform();
            foreach (var type in casetypes)
            {
                if (context.MstVirtualPlatforms.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstVirtualPlatforms.AddAsync(type);
                }
            }
        }
        private static async Task SeedSubCaseType(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetSubCaseTypes();
            foreach (var type in casetypes)
            {
                if (context.MstSubCaseTypes.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstSubCaseTypes.AddAsync(type);
                }
            }
        }
        private static async Task SeedCourtType(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetCourtTypes();
            foreach (var type in casetypes)
            {
                if (context.MstCourtType.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstCourtType.AddAsync(type);
                }
            }
        }
        private static async Task SeedCities(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetCities();
            foreach (var type in casetypes)
            {
                if (context.MstCities.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstCities.AddAsync(type);
                }
            }
        }
        private static async Task SeedRemainderTypes(MainDbContext context)
        {
            var remainderTypes = InitialDataGenerator.GetRemainderTypes();
            foreach (var type in remainderTypes)
            {
                if (context.MstRemainderTypes.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstRemainderTypes.AddAsync(type);
                }
            }
        }

        private static async Task SeedUnitType(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetUnitTypes();
            foreach (var type in casetypes)
            {
                if (context.MstUnits.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstUnits.AddAsync(type);
                }
            }
        }

        private static async Task SeedCategory(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetCategory();
            foreach (var type in casetypes)
            {
                if (context.MstCategories.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstCategories.AddAsync(type);
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
        private static async Task SeedRate(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetRateTypes();
            foreach (var type in casetypes)
            {
                if (context.MstRateTypes.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstRateTypes.AddAsync(type);
                }
            }
        }


        private static async Task SeedReportingTypePerDiem(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetReportingTypePerDiems();
            foreach (var type in casetypes)
            {
                if (context.MstReportingTypePerDiems.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstReportingTypePerDiems.AddAsync(type);
                }
            }
        }
        private static async Task SeedCaseTypePerdiem(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetCaseTypesPerDiem();
            foreach (var type in casetypes)
            {
                if (context.MstCaseTypePerdiems.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstCaseTypePerdiems.AddAsync(type);
                }
            }
        }

        private static async Task SeedDefenseType(MainDbContext context)
        {
            var defensetypes = InitialDataGenerator.GetDefensetypes();
            foreach (var type in defensetypes)
            {
                if (context.MstDefenseTypes.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstDefenseTypes.AddAsync(type);
                }
            }
        }
        private static async Task SeedBillingTypes(MainDbContext context)
        {
            var bilingTypes = InitialDataGenerator.GetBilingTypes();
            foreach (var type in bilingTypes)
            {
                if (context.MstBilingTypes.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstBilingTypes.AddAsync(type);
                }
            }
        }

        private static async Task SeedReliefPetitionerType(MainDbContext context)
        {
            var ReliefPetitionerTypes = InitialDataGenerator.GetReliefPetitionerTypes();
            foreach (var type in ReliefPetitionerTypes)
            {
                if (context.MstReliefPetitionerTypes.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstReliefPetitionerTypes.AddAsync(type);
                }
            }
        }

        private static async Task SeedReliefRespondentType(MainDbContext context)
        {
            var ReliefRespondentTypes = InitialDataGenerator.GetReliefRespondentTypes();
            foreach (var type in ReliefRespondentTypes)
            {
                if (context.MstReliefRespondentTypes.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstReliefRespondentTypes.AddAsync(type);
                }
            }
        }

        private static async Task SeedAppearanceType(MainDbContext context)
        {
            var appearanceTypes = InitialDataGenerator.GetAppearanceTypes();
            foreach (var type in appearanceTypes)
            {
                if (context.MstAppearanceTypes.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstAppearanceTypes.AddAsync(type);
                }
            }
        }

        private static async Task SeedAppearanceTypePerDiem(MainDbContext context)
        {
            var appearanceTypes = InitialDataGenerator.GetAppearanceTypesPerDiem();
            foreach (var type in appearanceTypes)
            {
                if (context.MstAppearanceTypesPerDiems.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstAppearanceTypesPerDiems.AddAsync(type);
                }
            }
        }
        private static async Task SeedDocumentInstructionsTypePerDiem(MainDbContext context)
        {
            var appearanceTypes = InitialDataGenerator.GetDocumentTypesPerDiem();
            foreach (var type in appearanceTypes)
            {
                if (context.MstDocumentTypePerDiems.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstDocumentTypePerDiems.AddAsync(type);
                }
            }
        }


        private static async Task SeedHarassmentType(MainDbContext context)
        {
            var HarassmentTypes = InitialDataGenerator.GetHarassmentTypes();
            foreach (var type in HarassmentTypes)
            {
                if (context.MstHarassmentTypes.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstHarassmentTypes.AddAsync(type);
                }
            }
        }

        private static async Task SeedBuildingTypes(MainDbContext context)
        {
            var building = InitialDataGenerator.GetBuildingTypes();
            foreach (var type in building)
            {
                if (context.MstBuildingTypes.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstBuildingTypes.AddAsync(type);
                }
            }
        }

        private static async Task SeedRegistrationStatus(MainDbContext context)
        {
            var registrationStatus = InitialDataGenerator.GetRegistrationStatus();
            foreach (var type in registrationStatus)
            {
                if (context.MstRegistrationstatuses.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstRegistrationstatuses.AddAsync(type);
                }
            }
        }

        private static async Task SeedCaseTypesHPD(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetCaseTypesHPD();
            foreach (var type in casetypes)
            {
                if (context.MstCaseTypesHPD.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstCaseTypesHPD.AddAsync(type);
                }
            }
        }

        private static async Task SeedPartyRepresent(MainDbContext context)
        {
            var pr = InitialDataGenerator.GetPartyRepresent();
            foreach (var type in pr)
            {
                if (context.MstPartyRepresents.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstPartyRepresents.AddAsync(type);
                }
            }
        }

        private static async Task SeedPartyRepresentPerDiem(MainDbContext context)
        {
            var pr = InitialDataGenerator.GetPartyRepresentPerDiem();
            foreach (var type in pr)
            {
                if (context.MstPartyRepresentPerDiems.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstPartyRepresentPerDiems.AddAsync(type);
                }
            }
        }

        private static async Task SeedCounty(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetCounty();
            foreach (var type in casetypes)
            {
                if (context.MstCounties.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstCounties.AddAsync(type);
                }
            }
        }

       
        private static async Task SeedCaseStatus(MainDbContext context)
        {
            var casetypes = InitialDataGenerator.GetCaseStatus();
            foreach (var type in casetypes)
            {
                if (context.MstCaseStatus.FirstOrDefault(d => d.Name == type.Name) == null)
                {
                    await context.MstCaseStatus.AddAsync(type);
                }
            }
        }

        //private static async Task SeedCourtPart(MainDbContext context)
        //{
        //    var casetypes = InitialDataGenerator.GetCourtPart();
        //    foreach (var type in casetypes)
        //    {
        //        if (context.MstCourtPart.FirstOrDefault(d => d.Name == type.Name) == null)
        //        {
        //            await context.MstCourtPart.AddAsync(type);
        //        }
        //    }
        //}

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

        private static async Task SeedFilingMethod(MainDbContext context)
        {

            var renewal = InitialDataGenerator.GetFilingMethod();
            foreach (var r in renewal)
            {
                if (context.MstFilingMethod.FirstOrDefault(d => d.Name == r.Name) == null)
                {
                    await context.MstFilingMethod.AddAsync(r);
                }
            }
        }
        private static async Task SeedServiceMethod(MainDbContext context)
        {

            var renewal = InitialDataGenerator.GetServiceMethod();
            foreach (var r in renewal)
            {
                if (context.MstServiceMethod.FirstOrDefault(d => d.Name == r.Name) == null)
                {
                    await context.MstServiceMethod.AddAsync(r);
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



