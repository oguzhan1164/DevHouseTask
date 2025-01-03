using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DevHouseTask.Application.Features.Permissions.Commands.CreatePermissions
{
    public class CreatePermissionsCommandHandler : BaseHandler, IRequestHandler<CreatePermissionsCommandRequest,Unit>
    {
        public CreatePermissionsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreatePermissionsCommandRequest request, CancellationToken cancellationToken)
        {
            Permission permission = new(request.Name);
            await unitOfWork.GetWriteRepository<Permission>().AddAsync(permission);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
