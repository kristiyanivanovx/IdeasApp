using Application.Contracts.Persistence;
using Application.Features.Ideas.Commands.CreateIdea;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.CreateCategory
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
	{
		private readonly IMapper _mapper;
		private readonly ICategoryRepository _categoryRepository;

		public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
		{
			_mapper = mapper;
			_categoryRepository = categoryRepository;
		}

		public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = _mapper.Map<Category>(request);

			var validator = new CreateCategoryCommandValidator();
			var validationResult = await validator.ValidateAsync(request);
			if (validationResult.Errors.Count > 0)
			{
				throw new Exceptions.ValidationException(validationResult);
			}

			category = await _categoryRepository.AddAsync(category);

			return category.Id;
		}
	}
}
