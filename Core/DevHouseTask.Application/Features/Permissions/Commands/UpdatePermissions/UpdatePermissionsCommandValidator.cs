using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Permissions.Commands.UpdatePermissions
{
    public class UpdatePermissionsCommandValidator : AbstractValidator<UpdatePermissionsCommandRequest>
    {
        public UpdatePermissionsCommandValidator() 
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Name).NotEmpty()
                .WithName("Yetki Adı");
        }
    }
}
