using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendor.GetVendors
{
    public class GerVendorCommandValidator : AbstractValidator<GetVendorCommand>
    {
        public GerVendorCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is not empty");    
        }

    }
}
