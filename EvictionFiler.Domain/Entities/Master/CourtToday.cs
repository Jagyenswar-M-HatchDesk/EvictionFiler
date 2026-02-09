using EvictionFiler.Domain.Entities.Base;

namespace EvictionFiler.Domain.Entities.Master
{
    public class CourtToday : DeletableGuidEntity
    {
        public Guid Id {  get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
