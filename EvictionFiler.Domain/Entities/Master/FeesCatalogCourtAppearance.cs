
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities.Master
{

    [Table("FeesCatalog_CourtAppearance", Schema = "dbo")]
    public class FeesCatalogCourtAppearance
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string County { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal AttorneyHourly { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal CourtAppearance { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PerDiem { get; set; }
    }
}