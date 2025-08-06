using EvictionFiler.Domain.Entities.Master;

namespace EvictionFiler.Infrastructure.DataSeeding
{
	public class InitialDataGenerator
	{
		


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

		public static IEnumerable<ReasonHoldover> GetReasonHoldover()
		{
			return new List<ReasonHoldover>
			{
				new ReasonHoldover() { Name = "Month-to-Month"},
				new ReasonHoldover() { Name = "Licencsee  "},
				new ReasonHoldover() { Name = "Non-Primary Residence"},
				new ReasonHoldover() { Name = "Squatter"},
				new ReasonHoldover() { Name = "Tenant Vacated"},
					new ReasonHoldover() { Name = "Lease Violation "},
						new ReasonHoldover() { Name = "Commercial "},
								new ReasonHoldover() { Name = "Prior Owner "},
								new ReasonHoldover() { Name = "At Will "},
								new ReasonHoldover() { Name = "Other "},

			};
		}

	

	}
}

