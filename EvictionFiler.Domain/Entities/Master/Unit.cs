namespace EvictionFiler.Domain.Entities.Master
{
    public class Unit : DeletableGuidEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
