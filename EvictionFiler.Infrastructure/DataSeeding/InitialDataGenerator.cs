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

		public static IEnumerable<CaseType> GetCaseTypes()
		{

			return new List<CaseType>
		{
			new CaseType() { Name = "Holdover"},
			new CaseType() { Name = "NonPayment"},
		};
		}

        public static IEnumerable<RenewalStatus> GetRenewalStatus()
        {

            return new List<RenewalStatus>
        {
            new RenewalStatus() { Name = "Renewed"},
            new RenewalStatus() { Name = "Not Renewed"},
        };
        }


        
        public static IEnumerable<PremiseType> GetPremiseType()
		{
			return new List<PremiseType>
			{
				new PremiseType() { Name = "One Family"},
					new PremiseType() { Name = "Two Family"},
					new PremiseType() { Name = "Three Family"},
					new PremiseType() { Name = "Four Family"},
				
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

        public static IEnumerable<DateRent> GetDateRent()
        {
            return Enumerable.Range(1, 31)  
                             .Select(i => new DateRent { Name = i.ToString() })
                             .ToList();
        }


        public static IEnumerable<State> GetState()
		{
			return new List<State>
			{
				new State() { Name = "Georgia"},
				new State() { Name = "Calofornia"},
				new State() { Name = "Florida"},
                new State() { Name = "New York"},
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

		public static IEnumerable<FormTypes> GetFormTypes()
		{
			
			return new List<FormTypes>
			{
				new FormTypes() { Name = "90 Days Notice" , CaseTypeName = "HoldOver" , HTML=""},
				new FormTypes() { Name = "5 Days Notice" , CaseTypeName = "HoldOver" , HTML=""},
				new FormTypes() { Name = "30 Days Notice" , CaseTypeName = "NonPayment", HTML=""},
				
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

