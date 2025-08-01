﻿using EvictionFiler.Application.DTOs.ApartmentDto;

namespace EvictionFiler.Application.DTOs.LandLordDto
{
	public class EditToLandlordDto : CreateToLandLordDto
	{
		public Guid Id { get; set; }
		public List<EditToBuildingDto> editBuildings { get; set; } = new();
	}
}
