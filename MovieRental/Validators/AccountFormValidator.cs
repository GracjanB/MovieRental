using FluentValidation;
using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Validators
{
    public class AccountFormValidator : AbstractValidator<UserModel>
    {
        public AccountFormValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("This field cannot be empty")
                .NotNull()
                .Length(3, 64).WithMessage("Username has to be between 3 and 64 characters");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("This field cannot be empty")
                .NotNull()
                .Length(3, 64).WithMessage("First name has to be between 3 and 64 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("This field cannot be empty")
                .NotNull()
                .Length(3, 64).WithMessage("Last name has to be between 3 and 64 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("This field cannot be empty")
                .NotNull()
                .Length(5, 64).WithMessage("Email has to be between 5 and 64 characters");
        }
    }
}
