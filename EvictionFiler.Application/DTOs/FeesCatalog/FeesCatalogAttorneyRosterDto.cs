
namespace EvictionFiler.Application.DTOs
{
    public class FeesCatalogAttorneyRosterDto
    {
        public int Id { get; set; }
        public int FeesCatalogId { get; set; }
        public int AttorneyId { get; set; }
        public decimal Rate { get; set; } = decimal.Zero;
        public decimal TravelWait { get; set; } = 0;
    }
}