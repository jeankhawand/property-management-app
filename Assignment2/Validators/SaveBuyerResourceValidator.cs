using Assignment2.Resources;
using FluentValidation;

namespace Assignment2.Validators
{
    public class SaveBuyerResourceValidator : AbstractValidator<SaveBuyerResource>
    {
        public SaveBuyerResourceValidator()
        {
            RuleFor(b=> b.Credits)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
            RuleFor(b => b.FullName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}