using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace EvictionFiler.Domain.Entities.Master
{
    public class SubCaseType : DeletableGuidEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
