using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.RemainderCenterDto
{
    public class EditToRemainderCenterDto : CreateToRemainderCenterDto
    {
        public Guid Id { get; set; }
    }
}
