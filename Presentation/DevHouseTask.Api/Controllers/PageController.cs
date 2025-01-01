using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevHouseTask.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public PageController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            return Ok(await unitOfWork.GetReadRepository<Page>().GetAllAsync());
        }
    }
}
