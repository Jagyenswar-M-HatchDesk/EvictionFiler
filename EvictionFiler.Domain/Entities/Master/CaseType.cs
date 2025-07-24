using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Domain.Entities.Base.Base;

namespace EvictionFiler.Domain.Entities.Master
{
	public class CaseType : AuditableBaseEntity
	{
		
		public string  ? Name { get; set; }
	
	}
}
