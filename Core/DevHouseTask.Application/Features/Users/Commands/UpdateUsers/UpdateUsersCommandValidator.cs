using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Users.Commands.UpdateUsers
{
    public class UpdateUsersCommandValidator : AbstractValidator<UpdateUsersCommandRequest>
    {
        public UpdateUsersCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithName("Kullanıcı Adı");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithName("Şifre");
            RuleFor(x => x.PermissionId).NotEmpty();

        }
    }
}
