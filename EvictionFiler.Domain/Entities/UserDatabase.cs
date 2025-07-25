using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Entities.Base.Base;

namespace EvictionFiler.Domain.Entities
{
    public class UserDatabase : AuditableBaseEntity
	{
        public string DatabaseName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty ;
    }
}
