using DevHouseTask.Application.DTOs;
using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevHouseTask.Application.Features.Pages.Queries.GetAllPages
{
    public class GetAllPagesQueryHandler : IRequestHandler<GetAllPagesQueryRequest, IList<GetAllPagesQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllPagesQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllPagesQueryResponse>> Handle(GetAllPagesQueryRequest request, CancellationToken cancellationToken)
        {
            var pages = await unitOfWork.GetReadRepository<Page>().GetAllAsync();

            var map = mapper.Map<GetAllPagesQueryResponse,Page>(pages);
            return map;
        }
    }
}
