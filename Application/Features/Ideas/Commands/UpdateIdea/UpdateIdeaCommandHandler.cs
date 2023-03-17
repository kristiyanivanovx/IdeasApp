using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ideas.Commands.UpdateIdea
{
	public class UpdateIdeaCommandHandler : IRequestHandler<UpdateIdeaCommand>
	{
		private readonly IMapper _mapper;
		private readonly IAsyncRepository<Category> _ideaRepository;

		public UpdateIdeaCommandHandler(IMapper mapper, IAsyncRepository<Category> ideaRepository)
		{
			_mapper = mapper;
			_ideaRepository = ideaRepository;
		}

		public async Task<Unit> Handle(UpdateIdeaCommand request, CancellationToken cancellationToken)
		{
			var ideaToUpdate = await _ideaRepository.GetByIdAsync(request.IdeaId);

			_mapper.Map(request, ideaToUpdate, typeof(UpdateIdeaCommand), typeof(Category));

			await _ideaRepository.UpdateAsync(ideaToUpdate);

			return Unit.Value;
		}
	}
}
