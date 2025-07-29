using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ApartmentDto;

namespace EvictionFiler.Application.DTOs.LandLordDto
{
	public class LandlordWithBuildings
	{
		public EditToLandlordDto? Landlord { get; set; }
		public List<EditToBuildingDto> Buildings { get; set; } = new();
	}
}
