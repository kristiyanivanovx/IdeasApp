using Application.Contracts.Persistence;
using Application.Features.Ideas.Commands.DeleteIdea;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.DeleteCategory
{
	public class DeleteCategoryCommandHandler : IRequestHandler<DeleteIdeaCommand>
	{
		private readonly IMapper _mapper;
		private readonly IAsyncRepository<Category> _ideaRepository;

		public DeleteCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> ideaRepository)
		{
			_mapper = mapper;
			_ideaRepository = ideaRepository;
		}

		public async Task<Unit> Handle(DeleteIdeaCommand request, CancellationToken cancellationToken)
		{
			var ideaToDelete = await _ideaRepository.GetByIdAsync(request.IdeaId);

			await _ideaRepository.DeleteAsync(ideaToDelete);

			return Unit.Value;
		}
	}
}
