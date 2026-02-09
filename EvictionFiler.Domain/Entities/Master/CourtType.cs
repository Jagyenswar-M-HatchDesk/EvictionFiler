using EvictionFiler.Domain.Entities.Base;

namespace EvictionFiler.Domain.Entities.Master
{
    public class CourtType : DeletableGuidEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
