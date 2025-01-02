using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.PermissionDetails.Commands.DeletePermissionDetails
{
    public class DeletePermissionDetailsCommandHandler : IRequestHandler<DeletePermissionDetailsCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeletePermissionDetailsCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(DeletePermissionDetailsCommandRequest request, CancellationToken cancellationToken)
        {
            var permissionDetail = await unitOfWork.GetReadRepository<PermissionDetail>().GetAsync(x => x.Id == request.Id);

            await unitOfWork.GetWriteRepository<PermissionDetail>().DeleteAsync(permissionDetail);
            await unitOfWork.SaveAsync();
        }
    }
}
