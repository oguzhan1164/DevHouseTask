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

namespace DevHouseTask.Application.Features.Pages.Commands.DeletePage
{
    public class DeletePageCommandHandler :BaseHandler, IRequestHandler<DeletePageCommandRequest,Unit>
    {
        public DeletePageCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeletePageCommandRequest request, CancellationToken cancellationToken)
        {
            var page = await unitOfWork.GetReadRepository<Page>().GetAsync(x=>x.Id == request.Id);

            await unitOfWork.GetWriteRepository<Page>().DeleteAsync(page);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
