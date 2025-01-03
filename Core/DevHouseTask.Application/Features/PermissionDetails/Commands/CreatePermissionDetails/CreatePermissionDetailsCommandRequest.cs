using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.PermissionDetails.Commands.CreatePermissionDetails
{
    public class CreatePermissionDetailsCommandRequest : IRequest<Unit>
    {
        public int PermissionId { get; set; }
        public int PageId { get; set; }
        public bool CanList { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}
