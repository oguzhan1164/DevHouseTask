using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Users.Commands.CreateUsers
{
    public class CreateUsersCommandHandler : IRequestHandler<CreateUsersCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateUsersCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateUsersCommandRequest request, CancellationToken cancellationToken)
        {
            User users = new User(request.UserName,request.Password,request.IsAdmin, request.PermissionId);
            await unitOfWork.GetWriteRepository<User>().AddAsync(users);
            await unitOfWork.SaveAsync();
        }
    }
}
