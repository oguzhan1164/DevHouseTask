using DevHouseTask.Application.Bases;
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

namespace DevHouseTask.Application.Features.PermissionDetails.Commands.DeletePermissionDetails
{
    public class DeletePermissionDetailsCommandHandler : BaseHandler, IRequestHandler<DeletePermissionDetailsCommandRequest, Unit>
    {
        public DeletePermissionDetailsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeletePermissionDetailsCommandRequest request, CancellationToken cancellationToken)
        {
            var permissionDetail = await unitOfWork.GetReadRepository<PermissionDetail>().GetAsync(x => x.Id == request.Id);

            await unitOfWork.GetWriteRepository<PermissionDetail>().DeleteAsync(permissionDetail);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
