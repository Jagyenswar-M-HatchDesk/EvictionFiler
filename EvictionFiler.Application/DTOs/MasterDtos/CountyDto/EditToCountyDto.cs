using EvictionFiler.Domain.Entities;

namespace EvictionFiler.Application.DTOs.MasterDtos.CountyDto
{
    public class EditToCountyDto :CreateToCountyDto
    {
        public ICollection<Courts> courts = new List<Courts>();
    }
}
