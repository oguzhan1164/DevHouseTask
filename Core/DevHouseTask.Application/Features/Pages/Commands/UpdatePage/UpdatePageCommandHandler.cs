using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Application.Interfaces.AutoMapper;
using MediatR;
using DevHouseTask.Domain.Entities;


namespace DevHouseTask.Application.Features.Pages.Commands.UpdatePage
{
    public class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdatePageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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
