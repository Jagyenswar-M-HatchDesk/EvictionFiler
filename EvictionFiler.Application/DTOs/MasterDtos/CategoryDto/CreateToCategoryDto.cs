using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.MasterDtos.CategoryDto
{
    public class CreateToCategoryDto : DeletableBaseEntity
    {
        [Required(ErrorMessage = "  Category Name is required")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
