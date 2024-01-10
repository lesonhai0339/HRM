using FluentValidation;
using FluentValidation.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendor.DeleteVendors
{
    public class DeleteVendorCommandValidator : AbstractValidator<DeleteVendorCommand>
    {
        public DeleteVendorCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is for empty")
                .NotNull().WithMessage("ID is not null");
        }
    }
}
