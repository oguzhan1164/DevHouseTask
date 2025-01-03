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
            await unitOfWork.GetWriteRepository<PermissionDetail>().AddAsync(permissionDetail);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
