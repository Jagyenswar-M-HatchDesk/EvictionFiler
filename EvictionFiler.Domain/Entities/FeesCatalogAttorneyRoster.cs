using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvictionFiler.Domain.Entities
{

    [Table("FeesCatalog_AttorneyRoster", Schema = "dbo")]
    public class FeesCatalogAttorneyRoster
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string BarNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal HourlyRate { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? TravelWait { get; set; } // NULLable in DB, so use decimal?
    }
}