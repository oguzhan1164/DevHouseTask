using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Pages.Commands.DeletePage
{
    public class DeletePageCommandHandler : IRequestHandler<DeletePageCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeletePageCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(DeletePageCommandRequest request, CancellationToken cancellationToken)
        {
            var page = await unitOfWork.GetReadRepository<Page>().GetAsync(x=>x.Id == request.Id);

            await unitOfWork.GetWriteRepository<Page>().DeleteAsync(page);
            await unitOfWork.SaveAsync();
        }
    }
}
