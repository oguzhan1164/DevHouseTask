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

namespace DevHouseTask.Application.Features.Users.Commands.DeleteUsers
{
    public class DeleteUsersCommandHandler : BaseHandler, IRequestHandler<DeleteUsersCommandRequest,Unit>
    {
        public DeleteUsersCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteUsersCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(x => x.Id == request.Id);

            await unitOfWork.GetWriteRepository<User>().DeleteAsync(user);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
