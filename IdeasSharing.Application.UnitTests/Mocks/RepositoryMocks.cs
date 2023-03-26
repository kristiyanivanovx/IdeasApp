using Application.Contracts.Persistence;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeasSharing.Application.UnitTests.Mocks
{
	public class RepositoryMocks
	{
		public static Mock<ICategoryRepository> GetCategoryRepository()
		{
			var productivityGuid = Guid.Parse("{0d5ab172-1060-4e6b-ba34-435416754b9f}");
			var sportsGuid = Guid.Parse("{f50f6ae0-ea8d-47b8-8fb9-82aa46fdc61e}");
			var medicineGuid = Guid.Parse("{c3c04a66-6017-413d-8376-9307a9cf83fd}");
			var financeGuid = Guid.Parse("{9095f861-9771-40d8-b761-9d9210ca7a26}");

			var categories = new List<Category>
			{
				new Category
				{
					CategoryId = productivityGuid,
					Name = "Productivity"
				},
				new Category
				{
					CategoryId = sportsGuid,
					Name = "Sports"
				},
				new Category
				{
					CategoryId = financeGuid,
					Name = "Finance"
				},
				 new Category
				{
					CategoryId = medicineGuid,
					Name = "Medicine"
				}
			};

			var mockCategoryRepository = new Mock<ICategoryRepository>();
			mockCategoryRepository
				.Setup(repo => repo.GetListAllAsync())
				.ReturnsAsync(categories);

			mockCategoryRepository
				.Setup(repo => repo.AddAsync(It.IsAny<Category>()))
				.ReturnsAsync((Category category) =>
					{
						categories.Add(category);
						return category;
					});

			return mockCategoryRepository;
		}
	}
}
