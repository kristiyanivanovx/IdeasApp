using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Queries.GetCategoriesList;
using Application.Features.Categories.Queries.GetCategoriesListWithIdeas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
			_mediator = mediator;
        }

		[HttpGet("all", Name = "GetAllCategories")]
		[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories()
		{
			var dtos = await _mediator.Send(new GetCategoriesListQuery());
			return Ok(dtos);
		}

		[HttpGet("allwithideas", Name = "GetCategoriesWithIdeas")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetCategoriesWithIdeas()
		{
			var dtos = await _mediator.Send(new GetCategoriesListWithIdeasQuery());
			return Ok(dtos);
		}

		[HttpPost("create", Name = "CreateCategory")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
		{
			var response = await _mediator.Send(createCategoryCommand);
			return Ok(response);
		}
	}
}
