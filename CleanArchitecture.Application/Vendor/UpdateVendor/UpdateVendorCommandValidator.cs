using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendor.UpdateVendor
{
    public class UpdateVendorCommandValidator : AbstractValidator<UpdateVendorCommand>
    {
        public UpdateVendorCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is not null");
            RuleFor(x => x.NameUpdated)
                .MinimumLength(15)
                .MaximumLength(25)
                .WithMessage("The name must around 15 to 25 characters.");
        }
    }
}
