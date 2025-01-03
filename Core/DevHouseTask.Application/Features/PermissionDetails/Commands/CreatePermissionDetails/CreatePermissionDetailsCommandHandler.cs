﻿using DevHouseTask.Application.Bases;
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

namespace DevHouseTask.Application.Features.PermissionDetails.Commands.CreatePermissionDetails
{
    public class CreatePermissionDetailsCommandHandler : BaseHandler,IRequestHandler<CreatePermissionDetailsCommandRequest,Unit>
    {
        public CreatePermissionDetailsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreatePermissionDetailsCommandRequest request, CancellationToken cancellationToken)
        {
            PermissionDetail permissionDetail = new PermissionDetail(request.PageId,request.PermissionId,request.CanDelete, request.CanCreate, request.CanUpdate, request.CanList);

            var userClaims = httpContextAccessor.HttpContext.User.Claims;
            var userIdClaim = userClaims.FirstOrDefault(c => c.Type == "sub" || c.Type == "userId");
            var userId = int.Parse(userIdClaim.Value);
            var user = unitOfWork.GetReadRepository<User>().Find(x => x.Id == userId);

            var roleClaims = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            var roleNameClaim = userClaims.FirstOrDefault(c => c.Type == "role" || c.Type == "roles");
            var permissionName = roleNameClaim.ToString();
            var role = unitOfWork.GetReadRepository<Permission>().Find(x => x.Name == permissionName);
            var permissionDetails = unitOfWork.GetReadRepository<PermissionDetail>().Find(x => x.PermissionId == role.Select(x => x.Id).First());
            if (user.Select(x => x.IsAdmin).FirstOrDefault() == false)
            {
                if (permissionDetails.Select(x => x.CanCreate).FirstOrDefault() == false)
                {
                    throw new Exception("Yetkisiz işlem.");
                }
            }

            await unitOfWork.GetWriteRepository<PermissionDetail>().AddAsync(permissionDetail);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
