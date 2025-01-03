using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Application.Interfaces.AutoMapper;
using MediatR;
using DevHouseTask.Domain.Entities;
using DevHouseTask.Application.Bases;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace DevHouseTask.Application.Features.Pages.Commands.UpdatePage
{
    public class UpdatePageCommandHandler : BaseHandler, IRequestHandler<UpdatePageCommandRequest,Unit>
    {
        public UpdatePageCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdatePageCommandRequest request, CancellationToken cancellationToken)
        {
            var page =  unitOfWork.GetReadRepository<Page>().Find(x=>x.Id == request.Id);

            var userClaims = httpContextAccessor.HttpContext.User.Claims;
            var userIdClaim = userClaims.FirstOrDefault(c => c.Type == "sub" || c.Type == "userId");
            var userId = int.Parse(userIdClaim.Value);
            var user = unitOfWork.GetReadRepository<User>().Find(x => x.Id == userId);

            var roleClaims = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            var roleNameClaim = userClaims.FirstOrDefault(c => c.Type == "role" || c.Type == "roles");
            var permissionName = roleNameClaim.ToString();
            var role = unitOfWork.GetReadRepository<Permission>().Find(x => x.Name == permissionName);
            var permissionDetail = unitOfWork.GetReadRepository<PermissionDetail>().Find(x => x.PermissionId == role.Select(x => x.Id).First());
            if (user.Select(x => x.IsAdmin).FirstOrDefault() == false)
            {
                if (permissionDetail.Select(x => x.CanUpdate).FirstOrDefault() == false)
                {
                    throw new Exception("Yetkisiz işlem.");
                }
            }

            var map = mapper.Map<Page,UpdatePageCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Page>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
