using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.PermissionDetails.Commands.CreatePermissionDetails
{
    public class CreatePermissionDetailsValidator : AbstractValidator<CreatePermissionDetailsCommandRequest>
    {
        public CreatePermissionDetailsValidator() 
        {
            RuleFor(x => x.PermissionId)
                .NotEmpty();
            RuleFor(x=>x.PageId).NotEmpty();
                
        }
    }
}
