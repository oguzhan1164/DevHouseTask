using MediatR;

namespace DevHouseTask.Application.Features.Pages.Queries.GetAllPages
{
    public class GetAllPagesQueryRequest : IRequest<IList<GetAllPagesQueryResponse>>
    {
    }
}
