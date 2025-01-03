using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x=>x.UserName)
                .NotEmpty()
                .MaximumLength(32)
                .MinimumLength(3)
                .WithName("Kullanıcı Adı");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(12)
                .WithName("Parola");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(12)
                .Equal(x=>x.Password)
                .WithName("Parola Tekrarı");
        }
    }
}
