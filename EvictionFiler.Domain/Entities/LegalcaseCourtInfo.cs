using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class LegalcaseCourtInfo
    {
        [Key]
        public Guid Id { get; set; }
        public string? Court { get; set; }
        public string? RoomNo { get; set; }
        public string? Part { get; set; }
        public string? Judge { get; set; }
        public string? Marshal { get; set; }
        public string? DocketNo { get; set; }
        public string? IndexNo { get; set; }
    }
}
