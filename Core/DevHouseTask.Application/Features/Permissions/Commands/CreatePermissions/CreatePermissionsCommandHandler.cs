using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;

namespace DevHouseTask.Application.Features.Permissions.Commands.CreatePermissions
{
    public class CreatePermissionsCommandHandler : IRequestHandler<CreatePermissionsCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreatePermissionsCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
