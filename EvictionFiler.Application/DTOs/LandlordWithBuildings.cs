using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;

namespace EvictionFiler.Application.DTOs
{
	public class LandlordWithBuildings
	{
		public CreateLandLordDto Landlord { get; set; }
		public List<AddApartment> Buildings { get; set; } = new();
	}
}
