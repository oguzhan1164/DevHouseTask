using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Permissions.Commands.UpdatePermissions
{
    public class UpdatePermissionsCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
