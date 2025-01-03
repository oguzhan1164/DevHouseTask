using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Features.Permissions.Commands.UpdatePermissions;
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

namespace DevHouseTask.Application.Features.Users.Commands.UpdateUsers
{
    public class UpdateUsersCommandHandler : BaseHandler, IRequestHandler<UpdateUsersCommandRequest,Unit>
    {
        public UpdateUsersCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdateUsersCommandRequest request, CancellationToken cancellationToken)
        {
            var user = unitOfWork.GetReadRepository<User>().Find(x => x.Id == request.Id);

            var map = mapper.Map<User, UpdateUsersCommandRequest>(request);

            await unitOfWork.GetWriteRepository<User>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
