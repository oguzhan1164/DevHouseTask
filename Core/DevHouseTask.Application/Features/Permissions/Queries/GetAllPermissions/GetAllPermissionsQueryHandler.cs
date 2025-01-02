using DevHouseTask.Application.Interfaces.AutoMapper;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using MediatR;


namespace DevHouseTask.Application.Features.Permissions.Queries.GetAllPermissions
{
    public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQueryRequest, IList<GetAllPermissionsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetAllPermissionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllPermissionsQueryResponse>> Handle(GetAllPermissionsQueryRequest request, CancellationToken cancellationToken)
        {
            var permissions = await unitOfWork.GetReadRepository<Permission>().GetAllAsync();

            //foreach (var page in pages) 
            //{
            //   response.Add (new GetAllPagesQueryResponse
            //    {
            //        PageId = page.Id,
            //        Code = page.Code,
            //    });
            //}
            var map = mapper.Map<GetAllPermissionsQueryResponse, Permission>(permissions);
            return map;
        }
    }
}
