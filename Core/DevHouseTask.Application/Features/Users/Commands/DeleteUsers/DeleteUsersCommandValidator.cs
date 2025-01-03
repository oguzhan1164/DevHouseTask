using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Users.Commands.DeleteUsers
{
    public class DeleteUsersCommandValidator : AbstractValidator<DeleteUsersCommandRequest>
    {
        public DeleteUsersCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
