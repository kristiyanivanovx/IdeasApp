using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetCategoriesListWithIdeas
{
	public class CategoryIdeaDto
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public Guid CategoryId { get; set; }
    }
}
