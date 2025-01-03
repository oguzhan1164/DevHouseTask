using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Features.Permissions.Commands.UpdatePermissions;
using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.PermissionDetails.Commands.UpdatePermissionDetails
{
    public class UpdatePermissionDetailsCommandHandler : BaseHandler, IRequestHandler<UpdatePermissionDetailsCommandRequest, Unit>
    {
        public UpdatePermissionDetailsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdatePermissionDetailsCommandRequest request, CancellationToken cancellationToken)
        {
            var permissionDetails = unitOfWork.GetReadRepository<PermissionDetail>().Find(x => x.Id == request.Id);

            var map = mapper.Map<PermissionDetail, UpdatePermissionDetailsCommandRequest>(request);

            await unitOfWork.GetWriteRepository<PermissionDetail>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
