namespace EvictionFiler.Application.DTOs.LandLordDto
{
    public class Landloard
    {
        public Guid? LandlordId { get; set; }
        public string LandlordAddress { get; set; } = string.Empty;

        public string landlordName { get; set; }
        public string AttorneyOfRecord { get; set; } = string.Empty;
        public string? LawFirm { get; set; } = string.Empty;
        public string? ContactPersonName { get; set; } = string.Empty;
        
    }
}
