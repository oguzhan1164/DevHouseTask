using DevHouseTask.Application.Bases;
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

namespace DevHouseTask.Application.Features.Users.Commands.DeleteUsers
{
    public class DeleteUsersCommandHandler : BaseHandler, IRequestHandler<DeleteUsersCommandRequest,Unit>
    {
        public DeleteUsersCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteUsersCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(x => x.Id == request.Id);

            var userClaims = httpContextAccessor.HttpContext.User.Claims;
            var userIdClaim = userClaims.FirstOrDefault(c => c.Type == "sub" || c.Type == "userId");
            var userId = int.Parse(userIdClaim.Value);
            var users = unitOfWork.GetReadRepository<User>().Find(x => x.Id == userId);

            var roleClaims = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            var roleNameClaim = userClaims.FirstOrDefault(c => c.Type == "role" || c.Type == "roles");
            var permissionName = roleNameClaim.ToString();
            var role = unitOfWork.GetReadRepository<Permission>().Find(x => x.Name == permissionName);
            var permissionDetail = unitOfWork.GetReadRepository<PermissionDetail>().Find(x => x.PermissionId == role.Select(x => x.Id).First());
            if (users.Select(x => x.IsAdmin).FirstOrDefault() == false)
            {
                if (permissionDetail.Select(x => x.CanDelete).FirstOrDefault() == false)
                {
                    throw new Exception("Yetkisiz işlem.");
                }
            }

            await unitOfWork.GetWriteRepository<User>().DeleteAsync(user);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
