
using DevHouseTask.Application.Features.PermissionDetails.Commands.CreatePermissionDetails;
using DevHouseTask.Application.Features.PermissionDetails.Commands.DeletePermissionDetails;
using DevHouseTask.Application.Features.PermissionDetails.Commands.UpdatePermissionDetails;
using DevHouseTask.Application.Features.PermissionDetails.Queries.GetAllPermissionDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevHouseTask.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PermissionDetailController : ControllerBase
    {
        private readonly IMediator mediator;
        public PermissionDetailController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllPermissionDetails()
        {
            var response = await mediator.Send(new GetAllPermissionDetailsQueryRequest());

            return Ok(response);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePermissionDetail(CreatePermissionDetailsCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdatePermissionDetail(UpdatePermissionDetailsCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeletePermissionDetail(DeletePermissionDetailsCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
    }
}
