using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs.PaginationDto
{
	public class PaginationDto<T>
	{

			public List<T> Items { get; set; } = new();
			public int TotalCount { get; set; }
			public int PageSize { get; set; }
			public int CurrentPage { get; set; }

	}
}
