using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.MasterDtos.DocumentInstructionPerDiemDto
{
    public class DocumentInstructionPerDiemDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
