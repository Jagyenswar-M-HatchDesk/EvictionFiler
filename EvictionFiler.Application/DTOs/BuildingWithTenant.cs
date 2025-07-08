using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;

namespace EvictionFiler.Application.DTOs
{
	public class BuildingWithTenant
	{
		public AddApartment Building { get; set; }
		public List<CreateTenantDto> Tenants { get; set; } = new();
	}
}
