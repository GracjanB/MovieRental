using FluentValidation;
using MovieRental.Models;

namespace MovieRental.Validators
{
    public class RegisterFormValidator : AbstractValidator<RegisterFormModel>
    {
        public RegisterFormValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username field cannot be empty")
                .NotNull()
                .MinimumLength(5).WithMessage("Username must have min. 5 characters")
                .MaximumLength(64).WithMessage("Username must have max. 64 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email field cannot be empty")
                .NotNull()
                .MaximumLength(64).WithMessage("Your email address is too long, max. 64 characters");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password field cannot be empty")
                .NotNull()
                .MinimumLength(4).WithMessage("Password must have min. 4 characters")
                .MaximumLength(64).WithMessage("Password must have max. 64 characters");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm password field cannot be empty")
                .NotNull()
                .Equal(x => x.Password).WithMessage("Password does not match");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name field cannot be empty")
                .NotNull()
                .MinimumLength(2).WithMessage("First Name field must have min. 2 characters")
                .MaximumLength(64).WithMessage("First Name field must have max. 64 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name field cannot be empty")
                .NotNull()
                .MinimumLength(2).WithMessage("Last Name field must have min. 2 characters")
                .MaximumLength(64).WithMessage("Last Name field must have max. 64 characters");
        }
    }
}
