using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;


namespace DevHouseTask.Application.Features.Permissions.Commands.DeletePermissions
{
    public class DeletePermissionsCommandHandler : IRequestHandler<DeletePermissionsCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        public DeletePermissionsCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeletePermissionsCommandRequest request, CancellationToken cancellationToken)
        {
            var permission = await unitOfWork.GetReadRepository<Permission>().GetAsync(x => x.Id == request.Id);

            await unitOfWork.GetWriteRepository<Permission>().DeleteAsync(permission);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
