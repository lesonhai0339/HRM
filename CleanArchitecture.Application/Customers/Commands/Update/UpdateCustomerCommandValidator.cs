using CleanArchitecture.Application.Customers.Commands.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Commands.Update
{
    public class UpdateCustomerCommandValidator: AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is Required")
                .MinimumLength(6).WithMessage("At Least 6 Characters")
                .MaximumLength(50).WithMessage("Maximun 50 Characters");
        }
    }
}
