using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.PermissionDetails.Commands.UpdatePermissionDetails
{
    public class UpdatePermissionDetailsCommandValidator : AbstractValidator<UpdatePermissionDetailsCommandRequest>
    {
        public UpdatePermissionDetailsCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x=>x.PermissionId).NotEmpty();
            RuleFor(x=>x.PageId).NotEmpty();
        }
    }
}
