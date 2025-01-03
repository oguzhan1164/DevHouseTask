﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.PermissionDetails.Commands.DeletePermissionDetails
{
    public class DeletePermissionDetailsCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
