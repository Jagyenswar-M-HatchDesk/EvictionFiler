using EvictionFiler.Domain.Entities.Base;

namespace EvictionFiler.Domain.Entities.Master
{
    public class AppearanceMode : DeletableGuidEntity
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
    }
}
