using DevHouseTask.Application.Features.Permissions.Commands.UpdatePermissions;
using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.PermissionDetails.Commands.UpdatePermissionDetails
{
    public class UpdatePermissionDetailsCommandHandler : IRequestHandler<UpdatePermissionDetailsCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdatePermissionDetailsCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Handle(UpdatePermissionDetailsCommandRequest request, CancellationToken cancellationToken)
        {
            var permissionDetails = unitOfWork.GetReadRepository<PermissionDetail>().Find(x => x.Id == request.Id);

            var map = mapper.Map<PermissionDetail, UpdatePermissionDetailsCommandRequest>(request);

            await unitOfWork.GetWriteRepository<PermissionDetail>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
        }
    }
}
