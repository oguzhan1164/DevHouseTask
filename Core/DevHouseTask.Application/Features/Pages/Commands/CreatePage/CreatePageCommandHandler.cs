using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Pages.Commands.CreatePage
{
    public class CreatePageCommandHandler : IRequestHandler<CreatePageCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreatePageCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreatePageCommandRequest request, CancellationToken cancellationToken)
        {
            Page page = new(request.Code);
            await unitOfWork.GetWriteRepository<Page>().AddAsync(page);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
