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
    public class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteUsersCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteUsersCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(x => x.Id == request.Id);

            await unitOfWork.GetWriteRepository<User>().DeleteAsync(user);
            await unitOfWork.SaveAsync();
        }
    }
}
