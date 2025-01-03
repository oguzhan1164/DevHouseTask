using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Users.Commands.DeleteUsers
{
    public class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteUsersCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
