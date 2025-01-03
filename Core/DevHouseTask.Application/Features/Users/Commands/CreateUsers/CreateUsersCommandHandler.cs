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

namespace DevHouseTask.Application.Features.Users.Commands.CreateUsers
{
    public class CreateUsersCommandHandler : BaseHandler, IRequestHandler<CreateUsersCommandRequest,Unit>
    {
        public CreateUsersCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateUsersCommandRequest request, CancellationToken cancellationToken)
        {
            User users = new User(request.UserName,request.Password,request.IsAdmin, request.PermissionId);
            await unitOfWork.GetWriteRepository<User>().AddAsync(users);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
