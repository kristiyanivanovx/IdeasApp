using Application.Contracts.Persistence;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Profiles;
using AutoMapper;
using Domain.Entities;
using IdeasSharing.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdeasSharing.Application.UnitTests.Categories.Commands
{
	public class CreateCategoryTests
	{
		private readonly IMapper _mapper;
		private readonly Mock<ICategoryRepository> _mockCategoryRepository;

		public CreateCategoryTests()
		{
			_mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
			var configurationProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MappingProfile>();
			});

			_mapper = configurationProvider.CreateMapper();
		}

		[Fact]
		public async Task Handle_ValidCategory_AddedToCategoriesRepo()
		{
			var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

			await handler.Handle(new CreateCategoryCommand() { Name = "TestCategory" }, CancellationToken.None);

			var allCategories = await _mockCategoryRepository.Object.GetListAllAsync();

			allCategories.Count.ShouldBe(5);
		}
	}
}
