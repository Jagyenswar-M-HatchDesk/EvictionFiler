using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.NotesDtos
{
    public class NotesDto : DeletableBaseEntity
    {
        public Guid Id {  get; set; }
        public string Notes { get; set; } = string.Empty;
        public Guid? LegalcaseId { get; set; }
    }
}
