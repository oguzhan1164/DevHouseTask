using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Users.Commands.CreateUsers
{
    public class CreateUsersCommandRequest :IRequest<Unit>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public int PermissionId { get; set; }
    }
}
