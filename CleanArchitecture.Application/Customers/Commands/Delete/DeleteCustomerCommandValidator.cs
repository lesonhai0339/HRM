using CleanArchitecture.Application.Customers.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Customers.Commands.Delete
{
    public class DeleteCustomerCommandValidator: AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id Is Not Empty")
                .NotNull().WithMessage("Id Is Not Null");
        }
    }
}
