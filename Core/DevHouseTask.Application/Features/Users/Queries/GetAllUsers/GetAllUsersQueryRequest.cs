using MediatR;


namespace DevHouseTask.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryRequest : IRequest<IList<GetAllUsersQueryResponse>>
    {
    }
}
