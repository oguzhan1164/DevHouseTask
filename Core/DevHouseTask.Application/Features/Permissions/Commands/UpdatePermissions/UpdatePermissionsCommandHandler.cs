using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Features.Pages.Commands.UpdatePage;
using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Permissions.Commands.UpdatePermissions
{
    public class UpdatePermissionsCommandHandler : BaseHandler, IRequestHandler<UpdatePermissionsCommandRequest, Unit>
    {
        public UpdatePermissionsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdatePermissionsCommandRequest request, CancellationToken cancellationToken)
        {
            var permission = unitOfWork.GetReadRepository<Permission>().Find(x => x.Id == request.Id);

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

            var map = mapper.Map<Permission, UpdatePermissionsCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Permission>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
