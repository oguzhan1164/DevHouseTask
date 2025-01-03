using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.PermissionDetails.Commands.DeletePermissionDetails
{
    public class DeletePermissionDetailsCommandValidator : AbstractValidator<DeletePermissionDetailsCommandRequest>
    {
        public DeletePermissionDetailsCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
