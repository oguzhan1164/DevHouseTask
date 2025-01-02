using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;

namespace DevHouseTask.Application.Features.PermissionDetails.Queries.GetAllPermissionDetails
{
    public class GetAllPermissionDetailsQueryHandler : IRequestHandler<GetAllPermissionDetailsQueryRequest, IList<GetAllPermissionDetailsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetAllPermissionDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllPermissionDetailsQueryResponse>> Handle(GetAllPermissionDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var permissionDetails = await unitOfWork.GetReadRepository<PermissionDetail>().GetAllAsync();

            var map = mapper.Map<GetAllPermissionDetailsQueryResponse, PermissionDetail>(permissionDetails);
            return map;
        }
    }
}
