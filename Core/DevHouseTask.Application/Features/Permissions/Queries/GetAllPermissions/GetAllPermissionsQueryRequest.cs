using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Permissions.Queries.GetAllPermissions
{
    public class GetAllPermissionsQueryRequest : IRequest<IList<GetAllPermissionsQueryResponse>>
    {
    }
}
