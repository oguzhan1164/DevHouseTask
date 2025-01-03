using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Users.Commands.CreateUsers
{
    public class CreateUsersCommandValidator : AbstractValidator<CreateUsersCommandRequest>
    {
        public CreateUsersCommandValidator() 
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithName("Kullanıcı Adı");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithName("Şifre");
            RuleFor(x=>x.PermissionId).NotEmpty();
        }
    }
}
