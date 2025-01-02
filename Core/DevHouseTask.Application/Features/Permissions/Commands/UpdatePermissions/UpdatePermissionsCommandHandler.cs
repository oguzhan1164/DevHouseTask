using DevHouseTask.Application.Features.Pages.Commands.UpdatePage;
using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Permissions.Commands.UpdatePermissions
{
    public class UpdatePermissionsCommandHandler : IRequestHandler<UpdatePermissionsCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UpdatePermissionsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Handle(UpdatePermissionsCommandRequest request, CancellationToken cancellationToken)
        {
            var permission = unitOfWork.GetReadRepository<Permission>().Find(x => x.Id == request.Id);

            var map = mapper.Map<Permission, UpdatePermissionsCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Permission>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
        }
    }
}
