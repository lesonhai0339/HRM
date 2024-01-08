using CleanArchitecture.Application.Authenticate.Login;
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
            RuleFor(x=> x.Name).NotEmpty().WithMessage("Name is Required")
                .MaximumLength(200).WithMessage("Maximum 200 Characters.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is Required")
                .MinimumLength(6).WithMessage("At Least 6 Characters")
                .MaximumLength(50).WithMessage("Maximun 50 Characters");
        }
    }
}
