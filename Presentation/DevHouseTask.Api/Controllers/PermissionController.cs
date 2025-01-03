using DevHouseTask.Application.Features.Permissions.Commands.CreatePermissions;
using DevHouseTask.Application.Features.Permissions.Commands.DeletePermissions;
using DevHouseTask.Application.Features.Permissions.Commands.UpdatePermissions;
using DevHouseTask.Application.Features.Permissions.Queries.GetAllPermissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevHouseTask.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator mediator;
        public PermissionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllPermissions()
        {
            var response = await mediator.Send(new GetAllPermissionsQueryRequest());

            return Ok(response);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePermission(CreatePermissionsCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdatePermission(UpdatePermissionsCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeletePermission(DeletePermissionsCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
    }
}
