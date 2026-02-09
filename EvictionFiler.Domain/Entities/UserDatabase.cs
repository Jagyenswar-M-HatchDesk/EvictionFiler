using EvictionFiler.Domain.Entities.Base;

namespace EvictionFiler.Domain.Entities
{
    public class UserDatabase : AuditableGuidEntity
	{
        public string DatabaseName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty ;
    }
}
