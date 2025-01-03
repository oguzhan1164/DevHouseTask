using DevHouseTask.Application.Features.Pages.Commands.CreatePage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Application.Features.Pages.Commands.DeletePage
{
    public class DeletePageCommandValidator : AbstractValidator<DeletePageCommandRequest>
    {
        public DeletePageCommandValidator() 
        {
            RuleFor(x=>x.Id).NotEmpty();
        }
    }
}
