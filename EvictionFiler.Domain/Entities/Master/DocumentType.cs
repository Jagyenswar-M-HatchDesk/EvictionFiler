namespace EvictionFiler.Domain.Entities.Master
{
    public class DocumentType : DeletableGuidEntity
    {
        public Guid Id {  get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsProcessServer { get; set; }  
    }
}
