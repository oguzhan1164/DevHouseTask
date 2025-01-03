using DevHouseTask.Application.Features.Pages.Rules;
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
        private readonly PageRules pageRules;

        public CreatePageCommandHandler(IUnitOfWork unitOfWork,PageRules pageRules)
        {
            this.unitOfWork = unitOfWork;
            this.pageRules = pageRules;
        }
        public async Task<Unit> Handle(CreatePageCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Page> pages = await unitOfWork.GetReadRepository<Page>().GetAllAsync();

            await pageRules.PageCodeMustNotBeSame(pages,request.Code);

            Page page = new(request.Code);
            await unitOfWork.GetWriteRepository<Page>().AddAsync(page);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
