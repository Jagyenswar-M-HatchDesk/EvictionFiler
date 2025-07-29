using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Infrastructure.DataSeeding
{
	public class InitialDataGenerator
	{
		public static IEnumerable<ClientRole> GetClientRole()
		{
			return new List<ClientRole>
			{
				new ClientRole() { Name = "LandLord/Owner"},
				new ClientRole() { Name = "Tenant/Occupants"},
				new ClientRole() { Name = "Property Manager"},
				new ClientRole() { Name = "Legal Representative"},
			};
		}


		public static IEnumerable<Language> GetLangauge()
		{
			return new List<Language>
			{
				new Language() { Name = "English"},
				new Language() { Name = "Spanish"},
				new Language() { Name = "Hindi"},
				new Language() { Name = "French"},
				new Language() { Name = "Chienese"},

			};
		}


		public static IEnumerable<PremiseType> GetPremiseType()
		{
			return new List<PremiseType>
			{
				new PremiseType() { Name = "Residential"},
					new PremiseType() { Name = "Commercial"},
					new PremiseType() { Name = "Industrial"},
					new PremiseType() { Name = "Mixed Use"},
					new PremiseType() { Name = "Retail"},
					new PremiseType() { Name = "Office"},
					new PremiseType() { Name = "Warehouse"},
			};
		}

		public static IEnumerable<RegulationStatus> GetRegulationStatus()
		{
			return new List<RegulationStatus>
			{
				new RegulationStatus() { Name = "Rent Stablised"},
				new RegulationStatus() { Name = "Controlled"},
				new RegulationStatus() { Name = "Market"},
				new RegulationStatus() { Name = "Section 8"},
				new RegulationStatus() { Name = "FHEPS"},
				new RegulationStatus() { Name = "Other"},

			};
		}

		public static IEnumerable<State> GetState()
		{
			return new List<State>
			{
				new State() { Name = "Georgia"},
				new State() { Name = "Calofornia"},
				new State() { Name = "Florida"},
			};
		}

		public static IEnumerable<TypeOfOwner> GetTypeOfOwner()
		{
			return new List<TypeOfOwner>
			{
				new TypeOfOwner() { Name = "Corportaion"},
				new TypeOfOwner() { Name = "LLC"},
			    new TypeOfOwner() { Name = "Individual"},
			    new TypeOfOwner() { Name = "Other"},
			};
		}

		public static IEnumerable<CaseType> GetCaseTypes()
		{
			return new List<CaseType>
			{
				new CaseType() { Name = "Holdover"},
				new CaseType() { Name = "HP Action"},
				new CaseType() { Name = "NonPayment"},
				new CaseType() { Name = "Licence"},
			};
		}

		public static IEnumerable<LandlordType> GetLandlordTypes()
		{
			return new List<LandlordType>
			{
				new LandlordType() { Name = "OwnerOfRecord"},
				new LandlordType() { Name = "Agent"},
				new LandlordType() { Name = "RefereeOwner"},
				new LandlordType() { Name = "Other"},
			};
		}

		public static IEnumerable<TenancyType> GetTenancyTypes()
		{
			return new List<TenancyType>
			{
				new TenancyType() { Name = "Month-to-Month"},
				new TenancyType() { Name = "At Will"},
				new TenancyType() { Name = "Squatter"},
				new TenancyType() { Name = "Section-8"},
				new TenancyType() { Name = "Other"},
			};
		}

		public static IEnumerable<IsUnitIllegal> GetIsUnitIllegal()
		{
			return new List<IsUnitIllegal>
			{
				new IsUnitIllegal() { Name = "Basement Apartment"},
				new IsUnitIllegal() { Name = "Roming House "},
				new IsUnitIllegal() { Name = "Attic"},
				new IsUnitIllegal() { Name = "None"},
			
			};
		}

		public static IEnumerable<CaseSubType> GetCaseSubTypes(IEnumerable<CaseType> caseTypes)
		{
			var holdoverId = caseTypes.FirstOrDefault(x => x.Name == "Holdover")?.Id;
			return new List<CaseSubType>
	          {
		         new CaseSubType { Name = "10 Days Notice - Notice To Cure To Renew Lease"  , CaseTypeId = holdoverId},
		         new CaseSubType { Name = "10 Days Notice - Referee Deed Prior Owner" ,  CaseTypeId = holdoverId },
		         new CaseSubType { Name = "10 Days Notice - Squatter Good Cause Apply"  ,  CaseTypeId = holdoverId},
		         new CaseSubType { Name = "10 Days Notice - Squatter" ,  CaseTypeId = holdoverId },
		         new CaseSubType { Name = "10 Days Notice - Tenant Of Record Vacated"  ,  CaseTypeId = holdoverId},
		         new CaseSubType { Name = "10 Days Notice To Terminate For Lease - Good Cause Apply"  ,  CaseTypeId = holdoverId},
		         new CaseSubType { Name = "30 Days Notice - Commercial"  ,  CaseTypeId = holdoverId},
		         new CaseSubType { Name = "30 Days Notice - Month To Month Section 8" ,  CaseTypeId = holdoverId},
		         new CaseSubType { Name = "30 Days Notice - Month To Month"  ,  CaseTypeId = holdoverId},
		         new CaseSubType { Name = "30 Days Notice - Primary - Non/Primary"  ,  CaseTypeId = holdoverId},
		         new CaseSubType { Name = "60 Days Notice - Intent Not To Renew Lease Section 8" ,  CaseTypeId = holdoverId},
		         new CaseSubType { Name = "60 Days Notice - Intent Not To Renew Lease" ,  CaseTypeId = holdoverId },
		         new CaseSubType { Name = "60 Days Notice - Month To Month - City FHEPS" , CaseTypeId = holdoverId},
		         new CaseSubType { Name = "60 Days Notice - Month To Month - Oral Agreement" , CaseTypeId = holdoverId},
		         new CaseSubType { Name = "60 Days Notice - Month To Month Good Cause Apply Section 8" , CaseTypeId = holdoverId},
		         new CaseSubType { Name = "60 Days Notice - Month To Month Good Cause Apply" , CaseTypeId = holdoverId},
		         new CaseSubType { Name = "60 Days Notice - Month To Month Section 8" ,  CaseTypeId = holdoverId },
		         new CaseSubType { Name = "60 Days Notice - Primary - Non/Primary" ,  CaseTypeId = holdoverId },
		         new CaseSubType { Name = "90 Days Notice - Intent Not To Renew Lease",  CaseTypeId = holdoverId },
		         new CaseSubType { Name = "90 Days Notice - Month to Month" ,  CaseTypeId = holdoverId },
		         new CaseSubType { Name = "90 Days Notice - Month To Month Section 8"  ,  CaseTypeId = holdoverId},
		         new CaseSubType { Name = "90 Days Notice - Primary -Non/Primary" ,  CaseTypeId = holdoverId },
		         new CaseSubType { Name = "90 Days Notice - Referee Deed" ,  CaseTypeId = holdoverId},
		         new CaseSubType { Name = "90 Days Notice - Tenancy at Will" ,  CaseTypeId = holdoverId }
	         };
		}

	}
}

