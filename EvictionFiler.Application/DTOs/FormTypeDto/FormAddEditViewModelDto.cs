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
        [Required(ErrorMessage = "Form Name is Required")]
        public string Name { get; set; } = string.Empty;
 
        public Guid? CaseTypeId { get; set; }
        [Required(ErrorMessage = "Category is Required")]
        public Guid? CategoryId { get; set; }
        public CaseType? CaseType { get; set; }
        public string? CaseTypeName { get; set; }
        public string? CategoryName { get; set; }
        public Category? Category { get; set; }
        public string? HTML { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
