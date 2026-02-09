namespace EvictionFiler.Domain.Entities.Master
{
    public class VirtualPlatform : DeletableGuidEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
