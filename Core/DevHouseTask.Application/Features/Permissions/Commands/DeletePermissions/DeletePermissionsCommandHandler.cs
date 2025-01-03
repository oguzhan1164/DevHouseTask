using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace DevHouseTask.Application.Features.Permissions.Commands.DeletePermissions
{
    public class DeletePermissionsCommandHandler : BaseHandler, IRequestHandler<DeletePermissionsCommandRequest, Unit>
    {
        public DeletePermissionsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
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
