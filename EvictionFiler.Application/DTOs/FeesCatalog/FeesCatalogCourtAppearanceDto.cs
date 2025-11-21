
namespace EvictionFiler.Application.DTOs
{
    public class FeesCatalogCourtAppearanceDto
    {
        public Guid Id { get; set; }
        public string County { get; set; }
        public decimal CourtAppearance { get; set; }
        public decimal AttorneyHourly { get; set; }
        public decimal PerDiem { get; set; }

    }
}


