using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Infrastructure.DataSeeding
{
	public class InitialDataGenerator
	{
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