namespace EvictionFiler.Domain.Entities.Master
{
    public class ReminderEscalate : DeletableGuidEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
