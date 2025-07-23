using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities.Master
{
	public class ClientRole : Base
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
	}
}
