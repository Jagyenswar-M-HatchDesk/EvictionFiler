using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.TenantDto;

namespace EvictionFiler.Application.DTOs.ClientDto
{
	public class EditToClientDto : CreateToClientDto
	{
		public Guid Id { get; set; }
		public List<EditToLandlordDto> editLandLords { get; set; } = new();
	}
}
