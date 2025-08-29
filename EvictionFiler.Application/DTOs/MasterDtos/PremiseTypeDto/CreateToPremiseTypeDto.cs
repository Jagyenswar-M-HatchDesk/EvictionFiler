using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.MasterDtos.PremiseTypeDto
{
    public class CreateToPremiseTypeDto : DeletableBaseEntity
    {
        [Required(ErrorMessage = "  Premise type  is required")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
