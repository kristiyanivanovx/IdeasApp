﻿using Application.Contracts.Persistence;
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
	public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
	{
		private readonly IMapper _mapper;
		private readonly IAsyncRepository<Category> _categoryRepository;

		public DeleteCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
		{
			_mapper = mapper;
			_categoryRepository = categoryRepository;
		}

		public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
		{
			var ideaToDelete = await _categoryRepository.GetByIdAsync(request.CategoryId);

			await _categoryRepository.DeleteAsync(ideaToDelete);

			return Unit.Value;
		}
	}
}
