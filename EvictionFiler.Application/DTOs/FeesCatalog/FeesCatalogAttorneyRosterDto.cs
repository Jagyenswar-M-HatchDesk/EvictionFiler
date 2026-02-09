namespace EvictionFiler.Application.DTOs
{
    public class FeesCatalogAttorneyRosterDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string BarNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }
        public decimal TravelWait { get; set; }
    }
}