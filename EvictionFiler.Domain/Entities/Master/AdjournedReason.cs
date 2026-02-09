using EvictionFiler.Domain.Entities.Base;

namespace EvictionFiler.Domain.Entities.Master
{
    public class AdjournedReason : DeletableGuidEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
