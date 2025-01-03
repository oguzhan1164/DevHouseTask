using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Permissions.Commands.DeletePermissions
{
    public class DeletePermissionsCommandValidator : AbstractValidator<DeletePermissionsCommandRequest>
    {
        public DeletePermissionsCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
