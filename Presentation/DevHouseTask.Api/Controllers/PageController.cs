using DevHouseTask.Application.Features.Pages.Commands.CreatePage;
using DevHouseTask.Application.Features.Pages.Commands.DeletePage;
using DevHouseTask.Application.Features.Pages.Commands.UpdatePage;
using DevHouseTask.Application.Features.Pages.Queries.GetAllPages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevHouseTask.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IMediator mediator;

        public PageController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllPages() 
        {
            var response = await mediator.Send(new GetAllPagesQueryRequest());

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePage(CreatePageCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdatePage(UpdatePageCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeletePage(DeletePageCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
    }
}
