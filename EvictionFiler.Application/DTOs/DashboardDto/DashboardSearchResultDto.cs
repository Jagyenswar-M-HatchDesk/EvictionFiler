using EvictionFiler.Application.DTOs.ApartmentDto;
using EvictionFiler.Application.DTOs.ClientDto;
using EvictionFiler.Application.DTOs.LandLordDto;
using EvictionFiler.Application.DTOs.LegalCaseDto;
using EvictionFiler.Application.DTOs.TenantDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.DashboardDto
{
    public class DashboardSearchResultDto
    {
        public CreateToClientDto ClientDto { get; set; }
        public CreateToLandLordDto LandLordDto { get; set; }
        public CreateToBuildingDto BuildingDto { get; set; }
        public CreateToTenantDto TenantDto { get; set; }
        public CreateToEditLegalCaseModel  caseDto { get; set; }
    }
}
