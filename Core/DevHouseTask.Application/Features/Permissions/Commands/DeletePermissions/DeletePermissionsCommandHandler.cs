using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace DevHouseTask.Application.Features.Permissions.Commands.DeletePermissions
{
    public class DeletePermissionsCommandHandler : BaseHandler, IRequestHandler<DeletePermissionsCommandRequest, Unit>
    {
        public DeletePermissionsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeletePermissionsCommandRequest request, CancellationToken cancellationToken)
        {
            var permission = await unitOfWork.GetReadRepository<Permission>().GetAsync(x => x.Id == request.Id);

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
                if (permissionDetail.Select(x => x.CanDelete).FirstOrDefault() == false)
                {
                    throw new Exception("Yetkisiz işlem.");
                }
            }

            await unitOfWork.GetWriteRepository<Permission>().DeleteAsync(permission);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
