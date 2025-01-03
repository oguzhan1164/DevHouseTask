using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Application.Interfaces.AutoMapper;
using MediatR;
using DevHouseTask.Domain.Entities;
using DevHouseTask.Application.Bases;
using Microsoft.AspNetCore.Http;


namespace DevHouseTask.Application.Features.Pages.Commands.UpdatePage
{
    public class UpdatePageCommandHandler : BaseHandler, IRequestHandler<UpdatePageCommandRequest,Unit>
    {
        public UpdatePageCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdatePageCommandRequest request, CancellationToken cancellationToken)
        {
            var page =  unitOfWork.GetReadRepository<Page>().Find(x=>x.Id == request.Id);

            var map = mapper.Map<Page,UpdatePageCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Page>().UpdateAsync(map);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
