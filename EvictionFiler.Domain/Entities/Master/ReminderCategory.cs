namespace EvictionFiler.Domain.Entities.Master
{
    public class ReminderCategory : DeletableGuidEntity
    {
        public Guid Id { get; set; }
        public string? Name  { get; set; }
        public string? Description { get; set; }
    }
}
