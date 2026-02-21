namespace EvictionFiler.Application.DTOs.CaseDetailDtos
{
    public class LandlordDetailDto
    {
        public Guid? LandlordId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }

        public string FullName =>FirstName + " " + LastName;

     
        public string LandlordAddress { get; set; } = string.Empty;

       
        public string? LawFirm { get; set; } = string.Empty;
        public string? ContactPersonName { get; set; } = string.Empty;
       
        public Guid? LandLordTypeId { get; set; }
        public string LandLordTypeName { get; set; }
    }
}
