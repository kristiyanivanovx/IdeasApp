using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ideas.Commands.CreateIdea
{
	public class CreateIdeaCommand : IRequest<Guid>
	{
		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		public DateTime CreatedOn { get; set; }

		public Guid CategoryId { get; set; }
	}
}
