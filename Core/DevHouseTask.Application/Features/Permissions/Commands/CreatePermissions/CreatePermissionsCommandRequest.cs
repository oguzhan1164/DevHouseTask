using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Permissions.Commands.CreatePermissions
{
    public class CreatePermissionsCommandRequest :IRequest
    {
        public string Name { get; set; }
    }
}
