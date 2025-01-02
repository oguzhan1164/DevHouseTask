using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.PermissionDetails.Commands.CreatePermissionDetails
{
    public class CreatePermissionDetailsCommandHandler : IRequestHandler<CreatePermissionDetailsCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreatePermissionDetailsCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(CreatePermissionDetailsCommandRequest request, CancellationToken cancellationToken)
        {
            PermissionDetail permissionDetail = new PermissionDetail(request.PageId,request.PermissionId,request.CanDelete, request.CanCreate, request.CanUpdate, request.CanList);
            await unitOfWork.GetWriteRepository<PermissionDetail>().AddAsync(permissionDetail);
            await unitOfWork.SaveAsync();
        }
    }
}
