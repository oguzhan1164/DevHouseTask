using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.PermissionDetails.Queries.GetAllPermissionDetails
{
    public class GetAllPermissionDetailsQueryRequest : IRequest<IList<GetAllPermissionDetailsQueryResponse>>
    {
    }
}
