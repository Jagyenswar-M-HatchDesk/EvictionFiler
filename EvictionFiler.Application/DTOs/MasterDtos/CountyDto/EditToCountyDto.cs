using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.MasterDtos.CountyDto
{
    public class EditToCountyDto :CreateToCountyDto
    {
        public ICollection<Courts> courts = new List<Courts>();
    }
}
