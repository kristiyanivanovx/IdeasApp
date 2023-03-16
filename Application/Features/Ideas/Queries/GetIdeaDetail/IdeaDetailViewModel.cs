using Application.Features.Ideas.Queries.GetIdeaDetail;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class IdeaDetailViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Guid CategoryId { get; set; }

        public CategoryDto Category { get; set; } = default!;

        public DateTime CreatedOn { get; set; }
    }
}
