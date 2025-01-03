using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Pages.Commands.UpdatePage
{
    public class UpdatePageCommandValidator : AbstractValidator<UpdatePageCommandRequest>
    {
        public UpdatePageCommandValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Code)
                .NotEmpty()
                .WithName("Sayfa Adı");
        }
    }
}
