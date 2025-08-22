using EvictionFiler.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.FormTypeDto
{
    public class FormAddEditViewModelDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid? CaseTypeId { get; set; }
        public CaseType? CaseType { get; set; }
        public string? HTML { get; set; }
    }
}
