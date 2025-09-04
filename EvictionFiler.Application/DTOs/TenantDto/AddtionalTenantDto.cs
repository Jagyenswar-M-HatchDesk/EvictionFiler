using EvictionFiler.Domain.Entities.Base.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.TenantDto
{
    public class AddtionalTenantDto : DeletableBaseEntity
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public Guid? TenantId { get; set; }
        public bool IsVisible { get; set; } = false;
    }
}
