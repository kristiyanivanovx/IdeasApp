using Application.Features.Ideas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class IdeasController : ControllerBase
	{
		private readonly IMediator _mediator;

        public IdeasController(IMediator mediator)
        {
			_mediator = mediator;
		}

		[HttpGet(Name = "GetAllIdeas")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GetAllIdeas()
		{
			var dtos = await _mediator.Send(new GetIdeasListQuery());
			return Ok(dtos);
		}
	}
}
