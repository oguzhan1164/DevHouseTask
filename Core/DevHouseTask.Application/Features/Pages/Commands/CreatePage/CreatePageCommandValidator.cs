

using FluentValidation;

namespace DevHouseTask.Application.Features.Pages.Commands.CreatePage
{
    public class CreatePageCommandValidator : AbstractValidator<CreatePageCommandRequest>
    {
        public CreatePageCommandValidator() 
        {
            RuleFor(x => x.Code)
                .NotEmpty();
        } 
    }
}
//RuleFor(x=>x.CategoryIds)
    //.notEmpty()
    //.Must(categories=>categories.Any())
    //.WithName("Kategori");