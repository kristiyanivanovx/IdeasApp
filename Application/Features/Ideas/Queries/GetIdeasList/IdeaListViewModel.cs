using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ideas
{
	public class IdeaListViewModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public Category Category { get; set; } = default!;

		public DateTime CreatedOn { get; set; }
	}
}
