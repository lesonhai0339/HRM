using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Shops.Commands.Update
{
    public class UpdateShopCommandValidator : AbstractValidator<UpdateShopCommand>
    {
        public UpdateShopCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required")
                .MaximumLength(200).WithMessage("Maximum 200 Characters.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is Required")
                .MaximumLength(50).WithMessage("Maximun 50 Characters");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is Required")
                .MinimumLength(10).WithMessage("Minimum 10 characters")
                .MaximumLength(11).WithMessage("Maximun 11 Characters");
        }
    }
}
