using DevHouseTask.Application.Features.Permissions.Commands.UpdatePermissions;
using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Users.Commands.UpdateUsers
{
    public class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateUsersCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Handle(UpdateUsersCommandRequest request, CancellationToken cancellationToken)
        {
            var user = unitOfWork.GetReadRepository<User>().Find(x => x.Id == request.Id);

            var map = mapper.Map<User, UpdateUsersCommandRequest>(request);

            await unitOfWork.GetWriteRepository<User>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
        }
    }
}
