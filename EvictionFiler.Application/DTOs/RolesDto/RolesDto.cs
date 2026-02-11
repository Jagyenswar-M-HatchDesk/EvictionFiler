using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.RolesDto
{
    public class RolesDto
    {
        public Guid Id { get; set; }

        [Required (ErrorMessage = "Role is required.")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
