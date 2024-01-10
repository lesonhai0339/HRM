using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Commands.Create
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator() 
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone Number is Required")
                .Length(10).WithMessage("Must Have 10 Digit")
                .Must(phone =>
                    phone.All(char.IsDigit)
                ).WithMessage("Must Digit");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is Required");
            RuleFor(x=> x.Name).NotEmpty().WithMessage("Name is Required")
                .MinimumLength(6).WithMessage("Mininum 6 Characters")
                .MaximumLength(100).WithMessage("Maximum 100 Characters.")
                .Must(name =>
                    !name.Any(char.IsWhiteSpace)
                ).WithMessage("Name Must Not Contain White Space");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is Required")
                .MinimumLength(6).WithMessage("At Least 6 Characters")
                .MaximumLength(100).WithMessage("Maximun 100 Characters")
                .Must(password =>
                    password.Any(char.IsUpper) &&
                    password.Any(char.IsLower) &&
                    password.Any(char.IsDigit) &&
                    password.Any(opt=> !char.IsLetterOrDigit(opt))
                ).WithMessage("At least one uppercase letter, one lowercase letter, one digit, and one special character");
        }
    }
}
