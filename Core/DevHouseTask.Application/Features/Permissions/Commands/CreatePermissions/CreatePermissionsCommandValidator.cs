using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Permissions.Commands.CreatePermissions
{
    public class CreatePermissionsCommandValidator : AbstractValidator<CreatePermissionsCommandRequest>
    {
        public CreatePermissionsCommandValidator() 
        {
            RuleFor(x=>x.Name).NotEmpty();
        }
    }
}
