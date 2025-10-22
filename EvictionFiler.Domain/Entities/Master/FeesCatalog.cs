

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities.Master
{

    [Table("FeesCatalog", Schema = "dbo")]
    public class FeesCatalog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string Label { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Unit { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Rate { get; set; }
    }
}
