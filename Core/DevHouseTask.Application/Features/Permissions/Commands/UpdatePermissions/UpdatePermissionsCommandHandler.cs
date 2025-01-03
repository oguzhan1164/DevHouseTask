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

            var map = mapper.Map<Permission, UpdatePermissionsCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Permission>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
