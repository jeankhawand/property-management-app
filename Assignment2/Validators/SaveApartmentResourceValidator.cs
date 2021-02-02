using Assignment2.Resources;
using FluentValidation;

namespace Assignment2.Validators
{
    public class SaveApartmentResourceValidator : AbstractValidator<SaveApartmentResource>
    {
        public SaveApartmentResourceValidator()
        {
            RuleFor(a => a.Address)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(a => a.Title)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(a => a.NbOfRooms)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .LessThanOrEqualTo(8);
        }
    }
}