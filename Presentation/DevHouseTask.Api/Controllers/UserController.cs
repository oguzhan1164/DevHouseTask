using DevHouseTask.Application.Features.Users.Commands.CreateUsers;
using DevHouseTask.Application.Features.Users.Commands.DeleteUsers;
using DevHouseTask.Application.Features.Users.Commands.UpdateUsers;
using DevHouseTask.Application.Features.Users.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevHouseTask.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await mediator.Send(new GetAllUsersQueryRequest());

            return Ok(response);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateUser(CreateUsersCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UpdateUsersCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteUser(DeleteUsersCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
    }
}
