using EvictionFiler.Domain.Entities.Master;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities
{

    [Table("FeesCatalog", Schema = "dbo")]
    public class FeesCatalog
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty;
       
        public string Label { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Unit { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Rate { get; set; }
        public string? Category { get; set; }
        
        public Guid? LabelId { get; set; }
        [ForeignKey("LabelId")]
        public FormTypes? Form { get; set; }
    }
}
